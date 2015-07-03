using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;
using NIIPP.ComputerVision;

namespace ViewCulling
{
    public partial class FormAnalyze : Form
    {
        public static FormAnalyze Instance { get; private set; }

        private readonly Dictionary<string, int> _columns = new Dictionary<string, int>()
        {
            {"Номер", 0},
            {"Название файла", 1},
            {"Вердикт", 2},
            {"Просмотрено", 3},
            {"Коэффициент (кластер)", 4},
            {"Коэффициент (пыль)", 5},
            {"Время обработки, с", 6}
        };

        private readonly StatisticInfo _statInfo = new StatisticInfo();
        
        private CullingProject _cullingProject;
        private string _pathToTestingChipsFolder;
        private string _pathToWaferMap;

        private Thread[] _workThreads;
        private DateTime _dtStartOfCalculation;
        private DispatcherTimer _mainTimer;

        private List<string> _pathesToImageFiles = new List<string>();
        private int _currFileIndex;

        private WaferMap _waferMap;

        public FormAnalyze()
        {
            InitializeComponent();
            Instance = this;
        }

        private void RefreshWaferMap()
        {
            lock (_waferMap)
            {
                if (Utils.FormIsOpen("FormWaferMap"))
                {
                    _waferMap.SetChipsStatus(GetChipVerdictsMap());
                    _waferMap.SetCurrProgramProccessedChip(_statInfo.CurrFile);
                    FormWaferMap.Instance.SetWaferMap(_waferMap);
                }
            }
        }

        private void RefreshStatisticControls()
        {
            BeginInvoke(new MethodInvoker(
                delegate
                {
                    lock (_statInfo)
                    {
                        lblCountOfFiles.Text = _statInfo.CountOfFiles.ToString();
                        lblCountOfCalced.Text = _statInfo.CountOfCalced.ToString();
                        if (_statInfo.CountOfGood + _statInfo.CountOfBad > 0)
                            lblPercentOfOut.Text = String.Format("{0:P}",
                                ((double)_statInfo.CountOfGood) /
                                (_statInfo.CountOfGood + _statInfo.CountOfBad));
                        lblCountOfGood.Text = _statInfo.CountOfGood.ToString();
                        lblCountOfBad.Text = _statInfo.CountOfBad.ToString();
                        if (_statInfo.CountOfFiles > 0)
                            lblPercentOfProgress.Text = String.Format("{0:P}",
                                ((double)_statInfo.CountOfCalced) / _statInfo.CountOfFiles);
                        pbProgress.Value = _statInfo.CountOfCalced <= pbProgress.Maximum
                            ? _statInfo.CountOfCalced
                            : pbProgress.Maximum;
                        RefreshTime();

                        RefreshWaferMap();
                    }
                }
                ));
        }

        private string GetPathToWaferMapFileMain()
        {
            string dir = Path.GetDirectoryName(_pathToTestingChipsFolder);
            string dirName = Path.GetFileName(_pathToTestingChipsFolder);
            string path = String.Format("{0}\\{1} ({2}) after_VC.map", dir, dirName, _dtStartOfCalculation.ToString("dd-MM-yyyy HH-mm-ss"));

            return path;
        }

        private string GetPathToWaferMapFileBackup()
        {
            string dirName = Path.GetFileName(_pathToTestingChipsFolder);
            string path = String.Format("wafer_maps_backup\\{0} ({1}) after_VC.map", dirName, _dtStartOfCalculation.ToString("dd-MM-yyyy HH-mm-ss"));

            return path;
        }

        private void AsyncSaveWaferMap()
        {
            Thread saveThread = new Thread(SaveWaferMapFile);
            saveThread.Start();
        }

        private void SaveWaferMapFile()
        {
            if (_waferMap != null)
            {
                lock (_waferMap)
                {
                    _waferMap.SetChipsStatus(GetChipVerdictsMap());
                    _waferMap.SaveWaferMapFile(GetPathToWaferMapFileMain());
                    FileInfo fi = new FileInfo(GetPathToWaferMapFileMain());

                    fi.CopyTo(GetPathToWaferMapFileBackup(), true);
                }
            }
        }

        private void EndOfCalculation()
        {
            _mainTimer.Stop();

            BeginInvoke(new MethodInvoker(delegate
            {
                pbLoading.Image = new Bitmap("assets\\done.png");
                _statInfo.CurrFile = null;
                RefreshStatisticControls();

                SaveWaferMapFile();
            }));
        }

        private void ScrollToRow(int currRow)
        {
            if (!автопрокруткаToolStripMenuItem.Checked)
                return;
            BeginInvoke(new MethodInvoker(delegate
            {
                dgvTestingOfChips.FirstDisplayedScrollingRowIndex = Math.Max(0, currRow - 15);
            }));
        }

        public void SetUserCorrectedStatus(string nameOfChip, Verdict.VerdictStructure verdict)
        {
            int indexOfName = _columns["Название файла"];
            int indexOfVerdict = _columns["Вердикт"];
            DataGridViewCell dgvcVerdict = null;
            for (int i = 0; i < dgvTestingOfChips.Rows.Count - 1; i++)
            {
                if (dgvTestingOfChips.Rows[i].Cells[indexOfName].Value.ToString() == nameOfChip)
                {
                    dgvcVerdict = dgvTestingOfChips.Rows[i].Cells[indexOfVerdict];
                    break;
                }
            }

            // если найден соответствующий чип и установлен новый вердикт
            if (dgvcVerdict != null && dgvcVerdict.Value.ToString() != verdict.Name)
            {
                if (dgvcVerdict.Value.ToString() == Verdict.Good.Name && verdict.Name == Verdict.Bad.Name)
                {
                    _statInfo.CountOfGood--;
                    _statInfo.CountOfBad++;
                }
                if (dgvcVerdict.Value.ToString() == Verdict.Bad.Name && verdict.Name == Verdict.Good.Name)
                {
                    _statInfo.CountOfGood++;
                    _statInfo.CountOfBad--;
                }
                Verdict.SetVerdictCell(dgvcVerdict, verdict);
                RefreshStatisticControls();
                AsyncSaveWaferMap();
            }
        }

        private void InitDgvTestingOfChips()
        {
            dgvTestingOfChips.ColumnCount = _columns.Count;
            foreach (string name in _columns.Keys)
            {
                dgvTestingOfChips.Columns[_columns[name]].Name = name;
            }

            dgvTestingOfChips.ReadOnly = true;
            dgvTestingOfChips.Font = new Font("Microsoft Sans Serif", 9);
            dgvTestingOfChips.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
            dgvTestingOfChips.BackgroundColor = SystemColors.Control;
            dgvTestingOfChips.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTestingOfChips.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTestingOfChips.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvTestingOfChips.AutoResizeColumns();
            dgvTestingOfChips.Visible = false;
        }

        private void LoadInfoAboutTestingSet()
        {
            dgvTestingOfChips.Visible = true;

            foreach (string path in _pathesToImageFiles)
            {
                string name = Path.GetFileName(path);
                if (Path.GetExtension(name) != ".bmp")
                    continue;

                dgvTestingOfChips.RowCount++;
                int currRow = dgvTestingOfChips.RowCount - 2;

                dgvTestingOfChips.Rows[currRow].Cells[_columns["Номер"]].Value = (currRow + 1).ToString();
                dgvTestingOfChips.Rows[currRow].Cells[_columns["Название файла"]].Value = name;
                Verdict.SetVerdictCell(dgvTestingOfChips.Rows[currRow].Cells[_columns["Вердикт"]], Verdict.Queue);
                dgvTestingOfChips.Rows[currRow].Cells[_columns["Просмотрено"]].Value = "Недоступно";
                dgvTestingOfChips.Rows[currRow].Cells[_columns["Просмотрено"]].Style.BackColor = Color.White;
            }
            dgvTestingOfChips.ClearSelection();
        }

        private void PrepareImageMas()
        {
            DirectoryInfo di = new DirectoryInfo(_pathToTestingChipsFolder);
            _pathesToImageFiles =
                di.GetFiles()
                    .Select(fileName => fileName.FullName)
                    .Where(fileName => Path.GetExtension(fileName) == ".bmp")
                    .ToList();

            _pathesToImageFiles.Sort();
            pbProgress.Maximum = _pathesToImageFiles.Count;
            _statInfo.CountOfFiles = _pathesToImageFiles.Count;
            _currFileIndex = 0;
        }

        private int FindDgvRowByFileName(string nameOfFile)
        {
            int indexOfColumn = _columns["Название файла"];

            int res = -1;
            for (int i = 0; i < dgvTestingOfChips.Rows.Count - 1; i++)
                if (dgvTestingOfChips.Rows[i].Cells[indexOfColumn].Value.ToString() == nameOfFile)
                    res = i;

            return res;
        }

        private int FindDgvRowByPrefixOfFileName(string prefix)
        {
            int indexOfColumn = _columns["Название файла"];

            int res = -1;
            for (int i = 0; i < dgvTestingOfChips.Rows.Count - 1; i++)
                if (dgvTestingOfChips.Rows[i].Cells[indexOfColumn].Value.ToString().IndexOf(prefix) != -1)
                    res = i;

            return res;
        }

        private void ReleaseTesting()
        {
            VisualInspect vi = new VisualInspect(_cullingProject, Settings.CountOfPixelsInClaster, Settings.SumOfPixelsInClusters)
            {
                EdgeRadius = Settings.EdgeNearArea, 
                ImpositionAcceptablePercent = Settings.ImpositionAcceptablePercent, 
                SegmentationRadiusOfStartFilling = Settings.RadiusOfStartFilling
            };

            do
            {
                // синхронизируем получение доступа к файлам для обработки
                String currFileName;
                lock (_pathesToImageFiles)
                {
                    if (_currFileIndex >= _pathesToImageFiles.Count)
                        return;
                    currFileName = _pathesToImageFiles[_currFileIndex];
                    _currFileIndex++;
                }

                int currRow = FindDgvRowByFileName(Path.GetFileName(currFileName));
                var dgvcVerdict = dgvTestingOfChips.Rows[currRow].Cells[_columns["Вердикт"]];
                bool isError = false;

                // если не проверен то не смотрим
                if (dgvcVerdict.Value.ToString() == Verdict.Queue.Name || dgvcVerdict.Value.ToString() == Verdict.Processing.Name)
                {
                    Verdict.SetVerdictCell(dgvcVerdict, Verdict.Processing);
                    ScrollToRow(currRow);

                    DateTime dtBefore = DateTime.Now;
                    try
                    {
                        vi.CheckNextChip(currFileName);
                        vi.PicWithSprites.Save(String.Format("{0}\\{1}", Settings.PathToCache, Path.GetFileName(currFileName)));
                    }
                    catch (Exception ex)
                    {
                        isError = true;
                        PushMessage(String.Format("Произошла ошибка при обработке: {0}", ex.Message));
                    }

                    TimeSpan timeSpan = DateTime.Now - dtBefore;
                    double seconds = timeSpan.TotalMilliseconds / 1000.0;
                    dgvTestingOfChips.Rows[currRow].Cells[_columns["Время обработки, с"]].Value = String.Format("{0:0.000}", seconds);
                    dgvTestingOfChips.Rows[currRow].Cells[_columns["Коэффициент (кластер)"]].Value = vi.CurrMarkIsland.ToString();
                    dgvTestingOfChips.Rows[currRow].Cells[_columns["Коэффициент (пыль)"]].Value = vi.CurrMarkDust.ToString();

                    if (!isError)
                    {
                        if (vi.CurrVerdict == Verdict.Bad.Name)
                        {
                            Verdict.SetVerdictCell(dgvcVerdict, Verdict.Bad);
                        }
                        if (vi.CurrVerdict == Verdict.Good.Name)
                        {
                            Verdict.SetVerdictCell(dgvcVerdict, Verdict.Good);
                        }
                        dgvTestingOfChips.Rows[currRow].Cells[_columns["Просмотрено"]].Value = "Нет";
                        dgvTestingOfChips.Rows[currRow].Cells[_columns["Просмотрено"]].Style.BackColor = Color.Khaki;
                    }
                    else
                    {
                         Verdict.SetVerdictCell(dgvcVerdict, Verdict.Error);
                         dgvTestingOfChips.Rows[currRow].Cells[_columns["Просмотрено"]].Value = "Недоступно";
                         dgvTestingOfChips.Rows[currRow].Cells[_columns["Просмотрено"]].Style.BackColor = Color.White;
                    }
                }
                
                lock (_statInfo)
                {
                    if (!isError)
                    {
                        if (vi.CurrVerdict == Verdict.Bad.Name)
                        {
                            _statInfo.CountOfBad++;
                        }
                        if (vi.CurrVerdict == Verdict.Good.Name)
                        {
                            _statInfo.CountOfGood++;
                        }
                    }
                    _statInfo.CurrFile = Path.GetFileName(currFileName);
                    _statInfo.CountOfCalced++;
                }

                RefreshStatisticControls();
            } 
            while (true);
        }

        private void OpenFolderForTesting(string initPath = null)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog
            {
                Description = "Выбор папки с микрофотографиями для визуального анализа",
            };
            if (initPath != null)
                fbd.SelectedPath = initPath;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                LoadFolderForTesting(fbd.SelectedPath);
            }
        }

        private void LoadFolderForTesting(string path)
        {
            _pathToTestingChipsFolder = path;
            Text = path;
            lblNameOfTestFolder.Text = Path.GetFileName(path);

            PrepareImageMas();
            LoadInfoAboutTestingSet();
            SetVerdictsFromWaferMap();
            if (_waferMap == null)
                _waferMap = new WaferMap(GetChipNames());

            RefreshStatisticControls();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFolderForTesting();
        }

        private void PushMessage(string message)
        {
            BeginInvoke(new MethodInvoker(delegate()
            {
                rtbInfo.Text += String.Format("{0}\n", message);
                rtbInfo.SelectionStart = rtbInfo.Text.Length;
            }));
        }

        private void FormStartAnalyze_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            pbLoading.Image = new Bitmap("assets\\waiting.png");
            InitDgvTestingOfChips();

            PushMessage("Модули успешно загружены ...");
        }

        private string GetVerdict(int row)
        {
            return dgvTestingOfChips.Rows[row].Cells[_columns["Вердикт"]].Value.ToString();
        }

        private string GetViewStatus(int row)
        {
            return dgvTestingOfChips.Rows[row].Cells[_columns["Просмотрено"]].Value.ToString();
        }

        private int SearchNextChip(int startPoint, bool isNext, string filter)
        {
            int countOfRows = dgvTestingOfChips.Rows.Count - 1;
            int pos = startPoint;

            if (filter == "")
            {
                if (isNext)
                {
                    pos++;
                    while (pos < countOfRows && GetViewStatus(pos) == "Недоступно")
                        pos++;
                }
                else
                {
                    pos--;
                    while (pos >= 0 && GetViewStatus(pos) == "Недоступно")
                        pos--;
                }
            }
            else
            {
                if (isNext)
                {
                    pos++;
                    while (pos < countOfRows && (GetVerdict(pos) != filter || GetViewStatus(pos) == "Недоступно"))
                        pos++;
                }
                else
                {
                    pos--;
                    while (pos >= 0 && (GetVerdict(pos) != filter || GetViewStatus(pos) == "Недоступно"))
                        pos--;
                }
            }
            if (pos < countOfRows && pos >= 0)
                return pos;

            return startPoint;
        }

        public void SendDataToShow(string prefix)
        {
            int pos = FindDgvRowByPrefixOfFileName(prefix);
            if (pos != -1)
                SendDataToShow(pos);
        }

        private FormAnalyzeView GetFormAnalyzeView()
        {
            FormAnalyzeView formAnalyzeView;
            if (!Utils.FormIsOpen("FormAnalyzeView"))
            {
                formAnalyzeView = new FormAnalyzeView { TopLevel = false };
                FormMain.Instance.Controls.Add(formAnalyzeView);
            }
            else
            {
                formAnalyzeView = FormAnalyzeView.Instance;
            }
            return formAnalyzeView;
        }

        public void SendDataToShow(int rowNumber, bool? isNext = null, string filter = null)
        {
            if (isNext != null && filter != null)
                rowNumber = SearchNextChip(rowNumber, (bool) isNext, filter);

            string viewStatus = dgvTestingOfChips.Rows[rowNumber].Cells[_columns["Просмотрено"]].Value.ToString();
            if (viewStatus == "Недоступно")
                return;

            dgvTestingOfChips.Rows[rowNumber].Cells[_columns["Просмотрено"]].Value = "Да";
            dgvTestingOfChips.Rows[rowNumber].Cells[_columns["Просмотрено"]].Style.BackColor = Color.White;
            string nameOfFile = dgvTestingOfChips.Rows[rowNumber].Cells[_columns["Название файла"]].Value.ToString();
            string coeff = dgvTestingOfChips.Rows[rowNumber].Cells[_columns["Коэффициент (кластер)"]].Value.ToString();
            string spritePicPath = Settings.PathToCache + "\\" + nameOfFile;
            string originalPicPath = _pathToTestingChipsFolder + "\\" + nameOfFile;
            string verdict = dgvTestingOfChips.Rows[rowNumber].Cells[_columns["Вердикт"]].Value.ToString();
            
            FormAnalyzeView formAnalyzeView = GetFormAnalyzeView();
            formAnalyzeView.LoadMainData(_cullingProject, dgvTestingOfChips.Rows.Count - 1);
            formAnalyzeView.LoadData(nameOfFile, spritePicPath, originalPicPath, coeff, rowNumber);
            formAnalyzeView.SetStatus(verdict);
            formAnalyzeView.Show();
            formAnalyzeView.WindowState = FormWindowState.Maximized;
            formAnalyzeView.BringToFront();
        }

        private void SetLoadingImage()
        {
            Random rnd = new Random();
            int num = rnd.Next(8) + 1;
            string path = String.Format("assets\\loading{0}.gif", num);
            Image image = new Bitmap(path);
            pbLoading.Image = image;
        }

        private void StartCalculating()
        {
            if (_cullingProject == null || _pathToTestingChipsFolder == null)
                return;

            SetLoadingImage();
            _dtStartOfCalculation = DateTime.Now;
            _mainTimer = new DispatcherTimer();
            _mainTimer.Tick += mainTimer_Tick;
            _mainTimer.Interval = new TimeSpan(0, 0, 0, 0, 200);
            _mainTimer.Start();
            int countOfThreads = Environment.ProcessorCount;
            _workThreads = new Thread[countOfThreads];
            for (int i = 0; i < countOfThreads; i++)
            {
                _workThreads[i] = new Thread(ReleaseTesting) { Name = i.ToString() };
                _workThreads[i].Start();
            }
        }

        private void стартToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartCalculating();
        }

        private void RefreshTime()
        {
            if (_statInfo.CountOfCalced > 0)
            {
                TimeSpan timeOfCalc = DateTime.Now - _dtStartOfCalculation;
                lblTimeOfCalculation.Text = timeOfCalc.ToString(@"hh\:mm\:ss");

                TimeSpan timeLeft = TimeSpan.FromSeconds((timeOfCalc.TotalSeconds / _statInfo.CountOfCalced) * _statInfo.CountOfFiles - timeOfCalc.TotalSeconds);
                lblTimeLeft.Text = timeLeft.ToString(@"hh\:mm\:ss");
            }
        }

        void mainTimer_Tick(object sender, EventArgs e)
        {
            lock (_statInfo)
            {
                RefreshTime();
                if (_statInfo.CountOfFiles == _statInfo.CountOfCalced)
                {
                    EndOfCalculation();
                }
            }
        }

        private void OpenCullingProject()
        {
            string path = Environment.CurrentDirectory + "\\" + Settings.PathToSaveProjects;
            OpenFileDialog ofd = new OpenFileDialog
            {
                InitialDirectory = path,
                Filter = "Culling Project (*.cpr)|*.cpr",
                Title = "Выбор файла проекта отбраковки"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _cullingProject = CullingProject.GetSavedProject(ofd.FileName);
                lblProjectOfCulling.Text = Path.GetFileName(ofd.FileName);
            }
        }

        private void открытьПроектОтбраковкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCullingProject();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormStartAnalyze_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                StopCalculating();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void StopCalculating()
        {
            if (_mainTimer != null)
                _mainTimer.Stop();
            if (_workThreads != null)
            {
                foreach (Thread thread in _workThreads.Where(thread => thread != null))
                {
                    thread.Abort();
                }
            }

            _currFileIndex = Math.Max(0, _currFileIndex - Environment.ProcessorCount * 2);
        }

        private void SetVerdictsFromWaferMap()
        {
            if (_waferMap == null || _pathToTestingChipsFolder == null)
                return;

            int indexOfVerdict = _columns["Вердикт"];
            int indexOfChipName = _columns["Название файла"];
            for (int i = 0; i < dgvTestingOfChips.Rows.Count - 1; i++)
            {
                Verdict.VerdictStructure verdict = _waferMap.GetStatusOfChip(dgvTestingOfChips.Rows[i].Cells[indexOfChipName].Value.ToString());
                if (verdict != null)
                    Verdict.SetVerdictCell(dgvTestingOfChips.Rows[i].Cells[indexOfVerdict], verdict);
            }
        }

        private void OpenWaferMapFile(string initPath = null)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Map files (*.map)|*.*",
                Title = "Выбор шаблона карты раскроя",
            };
            if (initPath != null)
                ofd.InitialDirectory = initPath;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _pathToWaferMap = ofd.FileName;
                lblCullingPattern.Text = Path.GetFileName(ofd.FileName);
                _waferMap = new WaferMap(ofd.FileName);
                SetVerdictsFromWaferMap();
            }
        }

        private void открытьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenWaferMapFile();
        }

        private List<string> GetChipNames()
        {
            List<string> res = new List<string>();
            int indexOfNameOfFile = _columns["Название файла"];
            for (int i = 0; i < dgvTestingOfChips.Rows.Count - 1; i++)
                res.Add(dgvTestingOfChips.Rows[i].Cells[indexOfNameOfFile].Value.ToString());

            return res;
        }

        private Dictionary<string, string> GetChipVerdictsMap()
        {
            Dictionary<string, string> res = new Dictionary<string, string>();
            int indexOfVerdict = _columns["Вердикт"];
            int indexOfNameOfFile = _columns["Название файла"];

            for (int i = 0; i < dgvTestingOfChips.Rows.Count - 1; i++)
                res.Add(dgvTestingOfChips.Rows[i].Cells[indexOfNameOfFile].Value.ToString(), dgvTestingOfChips.Rows[i].Cells[indexOfVerdict].Value.ToString());

            return res;
        }

        private void SaveWaferMapFile(string pathToSave)
        {
            WaferMap waferMap = new WaferMap(_pathToWaferMap);
            waferMap.SetChipsStatus(GetChipVerdictsMap());
            waferMap.SaveWaferMapFile(pathToSave);
        }

        private void SaveWaferMap()
        {
            if (_pathToWaferMap == null)
            {
                MessageBox.Show("Не выбран шаблон карты раскроя!");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Map file (*.map)|*.map",
                Title = "Сохранение текущей карты раскроя",
                FileName =
                    String.Format("{0}_after_VC.map",
                        Path.GetFileNameWithoutExtension(_pathToWaferMap))
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SaveWaferMapFile(sfd.FileName);
            }
        }

        private void сохранитьТекущуюКартуРаскрояToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveWaferMap();
        }

        private void dgvTestingOfChips_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == _columns["Просмотрено"] && e.RowIndex < dgvTestingOfChips.Rows.Count - 1)
            {
                SendDataToShow(e.RowIndex);
            }
        }

        private void автопрокруткаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem) sender).Checked = !((ToolStripMenuItem) sender).Checked;
        }

        private void остановкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopCalculating();
        }

        public void SetNewSegmentationLim(int lim)
        {
            if (_cullingProject != null)
                _cullingProject.Lim = lim;
        }

        private void порогСегментацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCalibration formCalibrationAndSettings = new FormCalibration {TopLevel = false};
            FormMain.Instance.Controls.Add(formCalibrationAndSettings);

            formCalibrationAndSettings.Show();
            formCalibrationAndSettings.LoadInfo(_pathesToImageFiles, _cullingProject.Lim, _cullingProject.KeyPoints);
        }

        private void pbStart_Click(object sender, EventArgs e)
        {
            StartCalculating();
        }

        private void pbPause_Click(object sender, EventArgs e)
        {
            StopCalculating();
        }

        private void pbStop_Click(object sender, EventArgs e)
        {
            StopCalculating();
        }

        private void pbChooseCullingProject_Click(object sender, EventArgs e)
        {
            OpenCullingProject();
        }

        private void pbChooseFolder_Click(object sender, EventArgs e)
        {
            OpenFolderForTesting(@"\\172.16.1.7\pc001-backup\4LAB\!MEASURING");
        }

        private void коэффициентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings formSettings = new FormSettings {TopLevel = false};
            FormMain.Instance.Controls.Add(formSettings);

            formSettings.Show();
            formSettings.BringToFront();
        }

        private FormWaferMap GetFormWaferMap()
        {
            FormWaferMap formWaferMap;
            if (!Utils.FormIsOpen("FormWaferMap"))
            {
                formWaferMap = new FormWaferMap {TopLevel = false};
                FormMain.Instance.Controls.Add(formWaferMap);
                formWaferMap.Show();
            }
            else
            {
                formWaferMap = FormWaferMap.Instance;
            }

            formWaferMap.WindowState = FormWindowState.Maximized;
            formWaferMap.BringToFront();

            return formWaferMap;
        }

        private void открытьКартуРаскрояToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormWaferMap formWaferMap = GetFormWaferMap();

            if (_waferMap != null)
            {
                _waferMap.SetChipsStatus(GetChipVerdictsMap());
                formWaferMap.SetWaferMap(_waferMap);
            }
        }

        private void pbOpenMap_Click(object sender, EventArgs e)
        {
            string path = null;
            if (_pathToTestingChipsFolder != null)
                path = _pathToTestingChipsFolder.Substring(0,
                    _pathToTestingChipsFolder.Length - Path.GetFileName(_pathToTestingChipsFolder).Length - 1);

            OpenWaferMapFile(path ?? @"\\172.16.1.7\pc001-backup\4LAB\!MEASURING");
        }

        private void pbSaveMap_Click(object sender, EventArgs e)
        {
            SaveWaferMap();
        }

        private void gpTesting_Enter(object sender, EventArgs e)
        {

        }

        private void dgvTestingOfChips_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void msMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void запускАнализаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void картаРаскрояToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void видToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void калибровкаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lblNameOfTestFolder_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblProjectOfCulling_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void lblCullingPattern_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pbLoading_Click(object sender, EventArgs e)
        {

        }

        private void lblCountOfFiles_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void lblTimeLeft_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void lblTimeOfCalculation_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lblCountOfBad_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void lblCountOfGood_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblPercentOfProgress_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblPercentOfOut_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lblCountOfCalced_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pbProgress_Click(object sender, EventArgs e)
        {

        }

        private void gbInstruments_Enter(object sender, EventArgs e)
        {

        }

    }
}
