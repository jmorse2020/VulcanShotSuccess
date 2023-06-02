using IronXL;
using System.Data;
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;

namespace VulcanShotSuccess
{
    public partial class MainForm : Form
    {
        static MainForm instance;
        public static MainForm Instance { get { return instance; } }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            instance = this;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            instance = null;
        }

        ProgrammeLogic.userSelection user;
        ProgrammeLogic p = new ProgrammeLogic();

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            double a = 392;
            double b = 500;
            double c = Math.Abs(a - b) / b;
            double d = c / b;
            progressBar1.Value = 100;
            ConsoleMessage($"c is {c}");
        }


        public void AddSuccessDataLine()
        {
            resultsTextField.AppendText("'SuccessData.csv' extension applied");
            resultsTextField.AppendText(Environment.NewLine);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult folderPath = folderBrowserDialog1.ShowDialog();
            if (folderPath == DialogResult.OK)
            {
                LocationToSaveTextField.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void LocationToSaveTextField_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchingFilesTextField_TextChanged(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void runButton_Click(object sender, EventArgs e)
        {

            // Clear console
            resultsTextField.Text = "";
            // Store location to save file in user.saveLocation
            user.saveLocation = LocationToSaveTextField.Text;

            // Apply SuccessData.txt extension if necessary, store result in user.nameOfStatFile
            user.nameOfStatFile = p.TXTextension(nameOfStatsFileTextField.Text, instance);

            // Store the area in user.area
            user.area = areaDropDown.Text;

            
            //RunButtonMethod();
            Thread t1 = new Thread(RunButtonMethod)
            {
                Name = "Thread1"
            };
            t1.Start();
            //runButton.Enabled = true;
            //spinningWheel.Visible = false;
        }
        public void RunButtonMethod()
        {
            if (InvokeRequired)
            {
                runButton.Invoke((MethodInvoker)delegate
                {
                    runButton.Enabled = false;
                });
            }
            else
            {
                runButton.Enabled = false;
            }
            // First check that each of the text fields have data
            if ((user.saveLocation == "") || (user.nameOfStatFile == "") || (user.area == "") || (user.files == null))
            {
                ErrorMessage("Please ensure all fields are filled out");
                spinningWheel.Invoke((MethodInvoker)delegate { spinningWheel.Visible = false; });
                runButton.Invoke((MethodInvoker)delegate { runButton.Enabled = true; });
                return;
            }

            var statFileFullpath = Path.Combine(user.saveLocation, user.nameOfStatFile);

            //using (StreamWriter sw = File.AppendText(statFileFullpath))
            //{
            //    sw.WriteLine("Has this line printed?");
            //} // Use this piece of code to write to a file...

            if (File.Exists(statFileFullpath))
            {
                ErrorMessage("File already exists. Change the save location or filename and try again");
                spinningWheel.Invoke((MethodInvoker)delegate { spinningWheel.Visible = false; });
                runButton.Invoke((MethodInvoker)delegate { runButton.Enabled = true; });
                return;
            }

            displayConfiguration();

            using (StreamWriter sw = File.AppendText(statFileFullpath))
            {
                sw.WriteLine("This file contains data on the success rate of Vulcan.\nIn this file a '1' represents 'successful' and '0' represents 'unsuccessful'.\n\n");
                sw.WriteLine("Date,\t   ShotType,\t Area,\t InnerOsc, \t OuterOsc,\t Inner, Outer, Shot,    UE,\t UEReq,\t UEDel,\t LE,\t LEReq,\t LEDel,\t LW,\t LWReq,\t LWDel,\t UW,\t UWReq,\t UWDel,\t ME,\t MEReq,\t MEDel,\t MW,\t MWReq,\t MWDel,\t L150,\t L150Req,\t L150Del,\t U150,\t U150Req,\t U150Del,\t ABC208,\t ABC208Req,\t ABC208Del,\t File, \t\t Comments\n");
            } // Use this piece of code to write to a file...
            int filesArraySize = user.files.Count;
            if (filesArraySize != 0) // if the user.files array is non-empty
            {
                int didSave = 0;
                ConsoleMessage("\n\nObtaining data...\n");
                for (int k = 0; k < filesArraySize; k++) // for each file k
                {
                    var currentfile = user.files[k]; // set the file
                    for (int t = 0; t < currentfile.worksheets.Count; t++) // for each sheet in  file k
                    {
                        int EmptyCount = 0;
                        // ConsoleMessage("Next file...");
                        // ConsoleMessage($"File is: {currentfile.file}, Sheet is {currentfile.worksheets[t]}\n");
                        List<string> DataString = ShotDataString(currentfile.file, currentfile.worksheets[t]);
                        int DataStringHeight = DataString.Count; // dummy until function is made
                        if (DataStringHeight == 0)
                        {
                            //ConsoleMessage($"No {user.area} data found in this file.");
                            //didSave = 0;
                        }
                        else
                        {
                            int n = 0;
                            for (int l = 0; l < DataStringHeight; l++)
                            {
                                n = 0;
                                if (!DataString[l].Equals(""))
                                {
                                    using (StreamWriter sw = File.AppendText(statFileFullpath))
                                    {
                                        sw.WriteLine(DataString[l]);
                                        //sw.WriteLine(Environment.NewLine);
                                    }
                                    // ConsoleMessage("PRINTING TO FILE...");
                                    didSave = 1;
                                    n++;
                                }
                                else
                                {
                                    EmptyCount++;
                                }
                            }
                            if (EmptyCount == DataStringHeight)
                            {
                                //ConsoleMessage("No relevant data found in this file...\n\n");
                            }
                            if (n == 0)
                            {
                                //ConsoleMessage("No relevant data found in this sheet...\n\n");
                                n = 1;
                            }
                        }
                        if (InvokeRequired)
                        {
                            var val = Convert.ToInt16(Convert.ToDouble(t) / Convert.ToDouble(currentfile.worksheets.Count) * 100);
                            progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Value = val; });
                        }
                        else
                        {
                            progressBar1.Value = t / currentfile.worksheets.Count * 100;
                        }
                    }
                    if (didSave == 1)
                    {
                        if (InvokeRequired)
                        {
                            progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Value = 100; });
                        }
                        ConsoleMessage("Scan complete.");
                    }
                    else
                    {
                        ErrorMessage("No data could be located");
                    }                    
                }
            }
            else
            {
                ErrorMessage("No files to search!");
            }

            string pathToStatFile = Path.Combine(user.saveLocation, user.nameOfStatFile);
            // Naming Stat file
            string nameOfFormattedStatisticsFile = pathToStatFile.Replace("SuccessData.csv", "StatisticsFile.txt");

            // Create file with statistics formatted
            SuccessRate(pathToStatFile, user.area, nameOfFormattedStatisticsFile);
            StatisticsTextBox.Invoke((MethodInvoker)delegate { StatisticsTextBox.Text = File.ReadAllText(nameOfFormattedStatisticsFile); });
            if (InvokeRequired)
            {
                runButton.Invoke((MethodInvoker)delegate
                {
                    runButton.Enabled = true;                    
                });
                progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Value = 0; });
            }
        }

        public void SuccessRate(string pathToStatFile, string Area, string nameOfFormattedStatisticsFile)
        {
            DataTable dataFromFile = ConvertCSVtoDataTable(pathToStatFile);
            List<ProgrammeLogic.FailedShotContainer> FailedShotArray = new List<ProgrammeLogic.FailedShotContainer>();
            List<ProgrammeLogic.InconclusiveShotContainer> InconclusiveShotArray = new List<ProgrammeLogic.InconclusiveShotContainer>();
            double totalShotsWithData = 0;
            int crossInconcluseCheck = 0;
            double NoSuccesses = 0;
            int height = dataFromFile.Rows.Count; //  - 5; was minus 5, changed to go from 5 to skip the header rows
            //ConsoleMessage($"Height is: {height}");
            //dataGridView1.Invoke((MethodInvoker)delegate { dataGridView1.DataSource = dataFromFile; }); 
            for (int m = 0; m < height; m++) // was 0, height
            {
                try
                {
                    double currentShotSuccess = Convert.ToDouble(dataFromFile.Rows[m][7]);
                    if (!double.IsNaN(currentShotSuccess))
                    {
                        totalShotsWithData++;
                        if (currentShotSuccess == 1)
                        {
                            NoSuccesses++;
                        }
                        else
                        {
                            ProgrammeLogic.FailedShotContainer TempFailedShotContainer = new ProgrammeLogic.FailedShotContainer();
                            TempFailedShotContainer.comments = dataFromFile.Rows[m][36].ToString(); //ShotComments[m] was 34

                            try
                            {
                                //ConsoleMessage($"m is: {m}");
                                TempFailedShotContainer.reason = FailedShotReason(dataFromFile.Rows[m], dataFromFile).ToString();
                            }
                            catch (System.FormatException)
                            {
                                ErrorMessage("System.FormatException");
                                TempFailedShotContainer.reason = "Unknown";
                            }
                            TempFailedShotContainer.date = dataFromFile.Rows[m][0].ToString();
                            TempFailedShotContainer.innerOsc = dataFromFile.Rows[m][3].ToString();
                            TempFailedShotContainer.outerOsc = dataFromFile.Rows[m][4].ToString();
                            TempFailedShotContainer.shotType = dataFromFile.Rows[m][1].ToString();
                            FailedShotArray.Add(TempFailedShotContainer);
                        }
                    }
                    else
                    {
                        ProgrammeLogic.InconclusiveShotContainer TempInconclusiveShotContainer = new ProgrammeLogic.InconclusiveShotContainer();
                        TempInconclusiveShotContainer.comments = dataFromFile.Rows[m][36].ToString(); //ShotComments[m]

                        try
                        {
                            //ConsoleMessage($"m is: {m}");
                            TempInconclusiveShotContainer.reason = FailedShotReason(dataFromFile.Rows[m], dataFromFile).ToString();
                        }
                        catch (System.FormatException)
                        {
                            ErrorMessage("System.FormatException");
                            TempInconclusiveShotContainer.reason = "Unknown";
                        }
                        TempInconclusiveShotContainer.date = dataFromFile.Rows[m][0].ToString();
                        TempInconclusiveShotContainer.innerOsc = dataFromFile.Rows[m][3].ToString();
                        TempInconclusiveShotContainer.outerOsc = dataFromFile.Rows[m][4].ToString();
                        TempInconclusiveShotContainer.shotType = dataFromFile.Rows[m][1].ToString();
                        InconclusiveShotArray.Add(TempInconclusiveShotContainer);
                        crossInconcluseCheck++;
                    }
                }
                catch (System.FormatException)
                {
                    ErrorMessage("System.FormatException");
                }
            }
            double NoFailed = totalShotsWithData - NoSuccesses;
            double NoInconclusive = height - NoFailed - NoSuccesses;
            double SuccessRatio = (NoSuccesses / totalShotsWithData);

            if (crossInconcluseCheck != NoInconclusive)
            {
                ErrorMessage($"Some Inconlclusive shots were not picked up in this document: {crossInconcluseCheck} found but {NoInconclusive} exist");
            }

            using (StreamWriter sw = File.AppendText(nameOfFormattedStatisticsFile))
            {
                //ErrorMessage("Have got to line 237");
                sw.WriteLine("* * * * * * * * * * * * * * * * *\n*   Vulcan Success Data File    *\n* * * * * * * * * * * * * * * * *\n\n");
                sw.WriteLine($"Results for the {user.nameOfStatFile.Replace("SuccessData.csv", string.Empty)} experimental period into {user.area}. The Vulcan statistics for this experiment are:\n\n\tTotal Shots = {totalShotsWithData}\n\tSuccessful Shots = {NoSuccesses}\n\tFailed Shots = {NoFailed}\n\tInconclusive Shots = {NoInconclusive}\n\tSuccess rate = {String.Format("{0:0.00}", SuccessRatio * 100)}%");
                //ErrorMessage("Have got to line 252");
                sw.WriteLine("\n\n* * * * * * * * * * * * * * * * * * *\n*   Information on Failed Shots     *\n* * * * * * * * * * * * * * * * * * *\n\n");
                if (FailedShotArray.Count != 0)
                {  
                    for (int b = 0; b < FailedShotArray.Count; b++)
                    {
                        sw.WriteLine($"Failed shot {b+1}:\n\tDate:\t\t\t\t{FailedShotArray[b].date}\n\tShot Number / Type:\t{FailedShotArray[b].shotType}\n\tInner Osc:\t\t{FailedShotArray[b].innerOsc}\n\tOuter Osc:\t\t{FailedShotArray[b].outerOsc}\n\tWhere:\t\t\t{FailedShotArray[b].reason}\n\tComments:\t\t{FailedShotArray[b].comments}\n\n");
                    }
                   
                }
                else
                {
                    sw.WriteLine("There were no Failed shots found");
                }
            } // Use this piece of code to write to a file..

            using (StreamWriter sw = File.AppendText(nameOfFormattedStatisticsFile))
            {
                //ErrorMessage("Have got to line 237");
                sw.WriteLine("\n\n* * * * * * * * * * * * * * * * * * * * * *\n*   Information on Inconclusive Shots     *\n* * * * * * * * * * * * * * * * * * * * * *\n\n");
                if (InconclusiveShotArray.Count != 0)
                {
                    for (int b = 0; b < InconclusiveShotArray.Count; b++)
                    {
                        sw.WriteLine($"Inconclusive shot {b + 1}:\n\tDate:\t\t\t\t{InconclusiveShotArray[b].date}\n\tShot Number / Type:\t{InconclusiveShotArray[b].shotType}\n\tInner Osc:\t\t{InconclusiveShotArray[b].innerOsc}\n\tOuter Osc:\t\t{InconclusiveShotArray[b].outerOsc}\n\tWhere:\t\t\t{InconclusiveShotArray[b].reason}\n\tComments:\t\t{InconclusiveShotArray[b].comments}\n\n");
                    }

                } 
                else
                {
                    sw.WriteLine("There were no Inconclusive shots found");
                }
                sw.WriteLine("END");
            } // Use this piece of code to write to a file..

        }
        
        public string FailedShotReason(DataRow row, DataTable table)
        {
            string Arr = String.Empty;
            int[] Beams = new int[] { 1, 5, 6, 2, 3, 4, 7, 8, 7 };
            int index = 0;
            for (int j = 8; j < 35; j = j + 3) // was8 17
            {
                try
                {

                    if (Convert.ToInt16(row.Field<string>(j)).Equals(0))
                    {
                        Arr = Arr + table.Columns[j].ColumnName + " (Beam " + Beams[index] + " @ " + String.Format("{0:0.00}", (Math.Abs(Convert.ToDouble(row.Field<string>(j + 1)) - Convert.ToDouble(row.Field<string>(j + 2))) / Convert.ToDouble(row.Field<string>(j + 1))) * 100) + "% from " + String.Format("{0:0.00}", Convert.ToDouble(row.Field<string>(j + 1))) + "J " + "); ";
                    }
                }
                catch (System.FormatException)
                {
                    // Seen a NaN
                }
                index++;
            }
            return Arr;
        }
        public List<object> GetColumnFromStat(DataTable data, int col)
        {
            var list = new List<object>();
            int skipRows = 5;
            int counter = 0;
            foreach (DataRow row in data.Rows)
            {
                counter++;
                if (counter > skipRows)
                {
                    list.Add(row.Field<object>(col));
                }
            }
            return list;
        }
        private void displayConfiguration()
        {
            if (resultsTextField.InvokeRequired)
            {
                resultsTextField.Invoke((MethodInvoker)delegate
                {
                    resultsTextField.AppendText(Environment.NewLine);
                    resultsTextField.AppendText("Details of search:");
                    resultsTextField.AppendText(Environment.NewLine);
                    resultsTextField.AppendText($"\tLocation to save: \t{user.saveLocation}\n\tName of statistics file: \t{user.nameOfStatFile}\n\tTarget area: \t{user.area}");
                    resultsTextField.AppendText(Environment.NewLine);
                    resultsTextField.AppendText("\t Searching files:");
                    for (int i = 0; i < user.files.Count; i++)
                    {
                        resultsTextField.AppendText($"\n\t\t{user.files[i].file}");
                    }
                });
            }
            else
            {
                resultsTextField.AppendText(Environment.NewLine);
                resultsTextField.AppendText("Details of search:");
                resultsTextField.AppendText(Environment.NewLine);
                resultsTextField.AppendText($"\tLocation to save: \t{user.saveLocation}\n\tName of statistics file: \t{user.nameOfStatFile}\n\tTarget area: \t{user.area}");
                resultsTextField.AppendText(Environment.NewLine);
                resultsTextField.AppendText("\t Searching files:");
                for (int i = 0; i < user.files.Count; i++)
                {
                    resultsTextField.AppendText($"\n\t\t{user.files[i].file}");
                }
            }
            
        }

        public void ErrorMessage(string error)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(ErrorMessage), new object[] { error });
                return;
            }
            resultsTextField.Select(resultsTextField.TextLength, 0);
            resultsTextField.SelectionColor = System.Drawing.Color.Red;
            resultsTextField.AppendText($"ERROR: {error}");
            resultsTextField.AppendText(Environment.NewLine);
        }
        public void ConsoleMessage(string message)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(ConsoleMessage), new object[] { message });
                return;
            }
            resultsTextField.Select(resultsTextField.TextLength, 0);
            resultsTextField.SelectionColor = System.Drawing.Color.Black;
            resultsTextField.AppendText($"{message}");
            resultsTextField.AppendText(Environment.NewLine);
        }
        public List<string> ListSheets(string filename) // Returns list of worksheets in excel file
        {
            try
            {
                var sheetNames = new List<string>();
                WorkBook workbook = WorkBook.Load(filename);
                if (workbook != null)
                {
                    var sheets = workbook.WorkSheets;
                    foreach (WorkSheet sheet in sheets)
                    {
                        sheetNames.Add(sheet.Name);
                    }
                }
                else
                {
                    ErrorMessage("No sheets could be found in the file");
                }
                return sheetNames;
            }
            catch (System.IO.IOException)
            {
                ErrorMessage("Cannot open file(s), please ensure they are all closed and try again");
                spinningWheel.Invoke((MethodInvoker)delegate { spinningWheel.Visible = false; });
                return new List<string>();
            }
            catch (System.FormatException)
            {
                ErrorMessage("Cannot open file(s), file extension not supported. Supported formats are: '.xlsm''");
                spinningWheel.Invoke((MethodInvoker)delegate { spinningWheel.Visible = false; });
                return new List<string>();
            }
            catch (Exception ex)
            {
                ErrorMessage("Cannot open file(s), exception: " + ex);
                spinningWheel.Invoke((MethodInvoker)delegate { spinningWheel.Visible = false; });
                return new List<string>();
            }
        }

        public bool acceptedShotType(DataTable data, int proceedCondition)
        {
            var l = data.Rows[proceedCondition][1].GetType();
            try
            {
                double numericCell = data.Rows[proceedCondition].Field<double>(1);
                return true;
            }
            catch (System.InvalidCastException ex)
            {
                try
                {
                    string stringCell = data.Rows[proceedCondition].Field<string>(1);
                    if (stringCell == null)
                    {
                        return false;
                    }
                    if (stringCell.Equals("F") || stringCell.Equals("Fday") || stringCell.Equals("FDay"))
                    {
                        return false; // Can be true if we accept faraday shots: will need to update which cells to look for requested and delivered on as this is different to disk
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (System.InvalidCastException ey)
                {
                    return false;
                }
            }
            catch (System.FormatException ex)
            {
                return false;
            }
        }

        public string shotRatio(int ReqRow, int DelRow, DataTable data, int Col)
        {
            try
            {
                if (double.IsNaN((data.Rows[ReqRow].Field<double>(Col))) || double.IsNaN(data.Rows[DelRow].Field<double>(Col)))
                {
                    return "NaN";
                }
                else
                {
                    double requestedEnergy = data.Rows[ReqRow].Field<double>(Col);
                    double deliveredEnergy = data.Rows[DelRow].Field<double>(Col);
                    double ratio = Math.Abs(deliveredEnergy - requestedEnergy) / requestedEnergy; // Defining Ratio := |Del - Req| / Req
                    return ratio.ToString();
                }
            }
            catch (System.InvalidCastException ex)
            {
                return "NaN";
            }
        }
        public string isSuccessful(string ratio)
        {
            double doubleRatio = Convert.ToDouble(ratio);
            if (double.IsNaN(doubleRatio))
            {
                return "NaN";
            }
            else if ((0.0 <= doubleRatio) && (doubleRatio <= 0.20)) // Using definition of ratio as Ratio := |Del - Req| / Del, value will always be greater than 0, and successful if < 0.2
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        public string orPlusMinus5Joule(string issuccessful, int ReqRow, int DelRow, DataTable data, int Col)
        {
            if (issuccessful.Equals("NaN") || issuccessful.Equals("1"))
            {
                return issuccessful;
            }
            else
            {
                try
                {
                   if ((data.Rows[ReqRow].Field<double>(Col) - 5 < data.Rows[DelRow].Field<double>(Col)) && (data.Rows[DelRow].Field<double>(Col) < data.Rows[ReqRow].Field<double>(Col) + 5)) // (data.Rows[DelRow].Field<double>(Col) + 5.0 >= data.Rows[ReqRow].Field<double>(Col)) || (data.Rows[DelRow].Field<double>(Col) - 5.0 <= data.Rows[ReqRow].Field<double>(Col))
                    {
                        return "1";
                    }
                    else
                    {
                        return "0";
                    }
                }
                catch (System.InvalidCastException ex)
                {
                    ErrorMessage("Invalid cast exception (plusMinus5Joule function contains an error, please contact administrator)");
                    return "0";
                }
            }
        }

        public bool checkSuccess(string stage)
        {
            double doubleStage = Convert.ToDouble(stage);
            if (!double.IsNaN(doubleStage))
            {
                if (doubleStage == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public List<string> ShotDataString(string filename, string sheetname)
        {
            //ConsoleMessage("Entered 351");
            List<string> DataString = new List<string>();
            var workbook = WorkBook.Load(filename);
            var worksheet = workbook.GetWorkSheet(sheetname);
            var data = worksheet.ToDataTable();

            // Initial Row numbers for each piece of data // 
            int CommentsRow = 8;
            int OscillatorRow = 3;
            int AreaRow = 4;
            int ShotType = 2;
            int ReqRow = 5;
            int DelRow = 6;
            int proceedCondition = 2;
            int shotCount = 1;
            // ConsoleMessage($"no rows: {data.Rows.Count}");
            string isShotNo = "";
            try
            {
                isShotNo = data.Rows[proceedCondition].Field<string>(0);
                if (isShotNo == null)
                {
                    isShotNo = "";
                }
            }
            catch (System.NullReferenceException)
            {
                 isShotNo = "";
            }
            catch (System.IndexOutOfRangeException)
            {
                isShotNo = "";
            }
            while ((proceedCondition < data.Rows.Count) && (isShotNo.Equals("Shot no.")))
            {
                // ConsoleMessage($"Entered 369, {user.area}, {acceptedShotType(data, proceedCondition)}");
                //dataGridView1.Invoke((MethodInvoker)delegate { dataGridView1.DataSource = data; });
                string OuterSuccess;
                string InnerSuccess;
                if (user.area.Equals("TAP") && (acceptedShotType(data, proceedCondition)))
                {
                    if (data.Rows[AreaRow].Field<string>(1).Equals("TAP"))
                    {
                        InnerSuccess = "N/A";
                        string ABC208Success = isSuccessful(shotRatio(ReqRow, DelRow, data, 31));
                        string ABC208Req = DoubleCellValue(data, ReqRow, 31);
                        string ABC208Del = DoubleCellValue(data, DelRow, 31);
                        string U150Success = isSuccessful(shotRatio(ReqRow, DelRow, data, 28));
                        string U150Req = DoubleCellValue(data, ReqRow, 28);
                        string U150Del = DoubleCellValue(data, DelRow, 28);
                        string L150Success = isSuccessful(shotRatio(ReqRow, DelRow, data, 30));
                        string L150Req = DoubleCellValue(data, ReqRow, 30);
                        string L150Del = DoubleCellValue(data, DelRow, 30);
                        if (checkSuccess(ABC208Success) && checkSuccess(U150Success) && checkSuccess(L150Success))
                        {
                            if (double.IsNaN(Convert.ToDouble(ABC208Success)) && double.IsNaN(Convert.ToDouble(U150Success)) && double.IsNaN(Convert.ToDouble(L150Success)))
                            {
                                OuterSuccess = "NaN";
                            }
                            else
                            {
                                OuterSuccess = "1";
                            }
                        }
                        else
                        {
                            OuterSuccess = "0";
                        }                      
                        string Success = OverallSuccess("NaN", OuterSuccess);
                        string CommentCellValue = data.Rows[CommentsRow].Field<string>(3);
                        string Comment;
                        if (CommentCellValue.Equals(""))
                        {
                            double requestedEntry = data.Rows[ReqRow].Field<double>(31);
                            double deliveredEntry = data.Rows[DelRow].Field<double>(31);
                            Comment = "No Comment" + $". Additional Information: The energy was {String.Format("{0:0.00}", (Math.Abs(requestedEntry - deliveredEntry) / requestedEntry) * 100)}% from the requested energy of {requestedEntry}J";
                        }
                        else
                        {
                            double requestedEntry = data.Rows[ReqRow].Field<double>(31);
                            double deliveredEntry = data.Rows[DelRow].Field<double>(31);
                            Comment = CommentCellValue + $". Additional Information: The energy was {String.Format("{0:0.00}", (Math.Abs(requestedEntry - deliveredEntry) / requestedEntry) * 100)}% from the requested energy of {requestedEntry}J";
                        }
                        string InnerOscillator = data.Rows[OscillatorRow].Field<string>(4);
                        string OuterOscillator = data.Rows[OscillatorRow].Field<string>(20);
                        if (InnerOscillator.Equals(""))
                        {
                            InnerOscillator = "Unknown";
                        }
                        if (OuterOscillator.Equals(""))
                        {
                            OuterOscillator = "Unknown";
                        }
                        string ShotTypeString = GetShotTypeString(data, proceedCondition);

                        // ConsoleMessage(sheetname + ", \t" + ShotType + ", \t" + "TAP" + ", \t" + InnerOscillator + ", \t" + OuterOscillator + ", \t" + InnerSuccess + ", \t" + OuterSuccess + ", \t" + Success + ", \t" + "N / A" + ", \t" + "N / A" + ", \t" + "N / A" + ", \t" + "N / A" + ", \t" + "N / A" + ", \t" + "N / A" + ", \t" + L150Success + ", \t" + U150Success + ", \t" + ABC208Success + ", \t" + filename + ", \t" + Comment);
                        //DataString.Add(sheetname + ", \t" + ShotTypeString + ", \t" + "TAP" + ", \t" + InnerOscillator + ", \t" + OuterOscillator + ", \t" + InnerSuccess + ", \t" + OuterSuccess + ", \t" + Success + ", \t" + "N/A" + ", \t" + "N/A" + ", \t" + "N/A" + ", \t" + "N/A" + ", \t" + "N/A" + ", \t" + "N/A" + ", \t" + L150Success + ", \t" + U150Success + ", \t" + ABC208Success + ", \t" + filename + ", \t" + Comment);
                        DataString.Add(sheetname + ", \t" + ShotTypeString + ", \t" + "TAP" + ", \t" + InnerOscillator + ", \t" + OuterOscillator + ", \t" + InnerSuccess + ", \t" + OuterSuccess + ", \t" + Success + ", \t" + "N/A" + ", \t" + "NaN" + ", \t" + "NaN" + ", \t" + "N/A" + ", \t" + "NaN" + ", \t" + "NaN" + ", \t" + "N/A" + ", \t" + "NaN" + ", \t" + "NaN" + ", \t" + "N/A" + ", \t" + "NaN" + ", \t" + "NaN" + ", \t" + "N/A" + ", \t" + "NaN" + ", \t" + "NaN" + ", \t" + "N/A" + ", \t" + "NaN" + ", \t" + "NaN" + ", \t" + L150Success + ", \t" + L150Req + ", \t" + L150Del + ", \t" + U150Success + ", \t" + U150Req + ", \t" + U150Del + ", \t" + ABC208Success + ", \t" + ABC208Req + ", \t" + ABC208Del + ", \t" + filename + ", \t" + Comment);
                    }
                    else
                    {
                        DataString.Add("");
                    }
                }
                else if (user.area.Equals("TAW") && (acceptedShotType(data, proceedCondition)))
                {
                    // ConsoleMessage("Entered 426");
                    // ConsoleMessage($"{data.Rows[AreaRow].Field<string>(1)},  {AreaRow}");
                    if (data.Rows[AreaRow].Field<string>(1).Equals("TAW"))
                    {
                        // Inner Track
                        //string UESuccess = isSuccessful(shotRatio(ReqRow, DelRow, data, 11));
                        string UESuccess = orPlusMinus5Joule(isSuccessful(shotRatio(ReqRow, DelRow, data, 11)), ReqRow, DelRow, data, 11);
                        string UEReq = DoubleCellValue(data, ReqRow, 11);
                        string UEDel = DoubleCellValue(data, DelRow, 11);
                        //string LESuccess = isSuccessful(shotRatio(ReqRow, DelRow, data, 12)); 
                        string LESuccess = orPlusMinus5Joule(isSuccessful(shotRatio(ReqRow, DelRow, data, 12)), ReqRow, DelRow, data, 12);
                        string LEReq = DoubleCellValue(data, ReqRow, 12);
                        string LEDel = DoubleCellValue(data, DelRow, 12);
                        //string LWSuccess = isSuccessful(shotRatio(ReqRow, DelRow, data, 13));
                        string LWSuccess = orPlusMinus5Joule(isSuccessful(shotRatio(ReqRow, DelRow, data, 13)), ReqRow, DelRow, data, 13);
                        string LWReq = DoubleCellValue(data, ReqRow, 13);
                        string LWDel = DoubleCellValue(data, DelRow, 13);
                        //string UWSuccess = isSuccessful(shotRatio(ReqRow, DelRow, data, 15));
                        string UWSuccess = orPlusMinus5Joule(isSuccessful(shotRatio(ReqRow, DelRow, data, 15)), ReqRow, DelRow, data, 15);
                        string UWReq = DoubleCellValue(data, ReqRow, 15);
                        string UWDel = DoubleCellValue(data, DelRow, 15);
                        //string MESuccess = isSuccessful(shotRatio(ReqRow, DelRow, data, 16));
                        string MESuccess = orPlusMinus5Joule(isSuccessful(shotRatio(ReqRow, DelRow, data, 16)), ReqRow, DelRow, data, 16);
                        string MEReq = DoubleCellValue(data, ReqRow, 16);
                        string MEDel = DoubleCellValue(data, DelRow, 16);
                        //string MWSuccess = isSuccessful(shotRatio(ReqRow, DelRow, data, 17));
                        string MWSuccess = orPlusMinus5Joule(isSuccessful(shotRatio(ReqRow, DelRow, data, 17)), ReqRow, DelRow, data, 17);
                        string MWReq = DoubleCellValue(data, ReqRow, 17);
                        string MWDel = DoubleCellValue(data, DelRow, 17);
                        if (checkSuccess(UESuccess) && checkSuccess(LESuccess) && checkSuccess(LWSuccess) && checkSuccess(UWSuccess) && checkSuccess(MESuccess) && checkSuccess(MWSuccess))
                        {
                            if (double.IsNaN(Convert.ToDouble(UESuccess)) && double.IsNaN(Convert.ToDouble(LESuccess)) && double.IsNaN(Convert.ToDouble(LWSuccess)) && double.IsNaN(Convert.ToDouble(UWSuccess)) && double.IsNaN(Convert.ToDouble(MESuccess)) && double.IsNaN(Convert.ToDouble(MWSuccess)))
                            {
                                InnerSuccess = "NaN";
                            }
                            else
                            {
                                InnerSuccess = "1";
                            }
                        }
                        else
                        {
                            InnerSuccess = "0";
                        }

                        // Outer Track
                        //string U150Success = isSuccessful(shotRatio(ReqRow, DelRow, data, 28));
                        string U150Success = orPlusMinus5Joule(isSuccessful(shotRatio(ReqRow, DelRow, data, 28)), ReqRow, DelRow, data, 28);
                        string U150Req = DoubleCellValue(data, ReqRow, 28);
                        string U150Del = DoubleCellValue(data, DelRow, 28);
                        //string L150Success = isSuccessful(shotRatio(ReqRow, DelRow, data, 30));
                        string L150Success = orPlusMinus5Joule(isSuccessful(shotRatio(ReqRow, DelRow, data, 30)), ReqRow, DelRow, data, 28);
                        string L150Req = DoubleCellValue(data, ReqRow, 30);
                        string L150Del = DoubleCellValue(data, DelRow, 30);
                        if (checkSuccess(U150Success) && checkSuccess(L150Success))
                        {
                            if (double.IsNaN(Convert.ToDouble(U150Success)) && double.IsNaN(Convert.ToDouble(L150Success)))
                            {
                                OuterSuccess = "NaN";
                            }
                            else
                            {
                                OuterSuccess = "1";
                            }
                        }
                        else
                        {
                            OuterSuccess = "0";
                        }
                        string Success = OverallSuccess(InnerSuccess, OuterSuccess);
                        string CommentCellValue = data.Rows[CommentsRow].Field<string>(3);
                        string Comment;
                        if (CommentCellValue.Equals(""))
                        {
                            Comment = "No Comment";
                        }
                        else
                        {
                            Comment = CommentCellValue;
                        }
                        string InnerOscillator = data.Rows[OscillatorRow].Field<string>(4);
                        string OuterOscillator = data.Rows[OscillatorRow].Field<string>(20);
                        if (InnerOscillator.Equals(""))
                        {
                            InnerOscillator = "Unknown";
                        }
                        if (OuterOscillator.Equals(""))
                        {
                            OuterOscillator = "Unknown";
                        }
                        string ShotTypeString = GetShotTypeString(data, proceedCondition);
                        // ConsoleMessage(sheetname + ", \t" + ShotType + ", \t" + "TAW" + ", \t" + InnerOscillator + ", \t" + OuterOscillator + ", \t" + InnerSuccess + ", \t" + OuterSuccess + ", \t" + Success + ", \t" + UESuccess + ", \t" + LESuccess + ", \t" + LWSuccess + ", \t" + UWSuccess + ", \t" + MESuccess + ", \t" + MWSuccess + ", \t" + L150Success + ", \t" + U150Success + ", \t" + "N/A" + ", \t" + filename + ", \t" + Comment);
                        DataString.Add(sheetname + ", \t" + ShotTypeString + ", \t" + "TAW" + ", \t" + InnerOscillator + ", \t" + OuterOscillator + ", \t" + InnerSuccess + ", \t" + OuterSuccess + ", \t" + Success + ", \t" + UESuccess + ", \t" + UEReq + ", \t" + UEDel + ", \t" + LESuccess + ", \t" + LEReq + ", \t" + LEDel + ", \t" + LWSuccess + ", \t" + LWReq + ", \t" + LWDel + ", \t" + UWSuccess + ", \t" + UWReq + ", \t" + UWDel + ", \t" + MESuccess + ", \t" + MEReq + ", \t" + MEDel + ", \t" + MWSuccess + ", \t" + MWReq + ", \t" + MWDel + ", \t" + L150Success + ", \t" + L150Req + ", \t" + L150Del + ", \t" + U150Success + ", \t" + U150Req + ", \t" + U150Del + ", \t" + "N/A" + ", \t" + "NaN" + ", \t" + "NaN" + ", \t" + filename + ", \t" + Comment);
                    }
                    else
                    {
                        DataString.Add("");
                    }
                }
                else
                {
                    DataString.Add("");
                }
                // Iterations
                ReqRow += 8;
                DelRow += 8;
                OscillatorRow += 8;
                CommentsRow += 8;
                ShotType += 8;
                proceedCondition += 8;
                AreaRow += 8;
                shotCount += 1;

                // Reget the isShotNo
                try
                {
                    isShotNo = data.Rows[proceedCondition].Field<string>(0);
                    if (isShotNo == null)
                    {
                        isShotNo = "";
                    }
                }
                catch (System.NullReferenceException)
                {
                    isShotNo = "";
                }
                catch (System.IndexOutOfRangeException)
                {
                    isShotNo = "";
                }
            }
            return DataString;
        }

        public string DoubleCellValue(DataTable data, int row, int col)
        {
            try
            {
                if (double.IsNaN((data.Rows[row].Field<double>(col))))
                {
                    return "NaN";
                }
                else
                {
                    return data.Rows[row].Field<double>(col).ToString();
                }
            }
            catch (System.InvalidCastException ex)
            {
                return "NaN";
            }
        }

        public string GetShotTypeString(DataTable data, int proceedCondition)
        {
            var l = data.Rows[proceedCondition][1].GetType();
            try
            {
                double numericCell = data.Rows[proceedCondition].Field<double>(1);
                string stringCell = Convert.ToString(numericCell);
                return stringCell;
            }
            catch (System.InvalidCastException ex)
            {
                try
                {
                    string stringCell = data.Rows[proceedCondition].Field<string>(1);
                    if (stringCell == null)
                    {
                        return "NaN";
                    }
                    if (stringCell.Equals("F") || stringCell.Equals("Fday") || stringCell.Equals("FDay"))
                    {
                        return "F";
                    }
                    else
                    {
                        return "NaN";
                    }
                }
                catch (System.InvalidCastException ey)
                {
                    return "NaN";
                }
            }
            catch (System.FormatException ex)
            {
                return "NaN";
            }
        }
        public string OverallSuccess(string InnerSuccess, string OuterSuccess)
        {
            double doubleInnerSuccess = 10000;
            double doubleOuterSuccess = 10000;
            try
            {
                doubleInnerSuccess = Convert.ToDouble(InnerSuccess);
                doubleOuterSuccess = Convert.ToDouble(OuterSuccess);
            }
            catch (System.FormatException)
            {
                if (InnerSuccess.Equals("N/A"))
                {
                    doubleInnerSuccess = double.NaN;
                }
                if (OuterSuccess.Equals("N/A"))
                {
                    doubleOuterSuccess = double.NaN;
                }
            }
            if (!double.IsNaN(doubleInnerSuccess) && !double.IsNaN(doubleOuterSuccess))
            {
                if (doubleInnerSuccess.Equals(1) && doubleOuterSuccess.Equals(1))
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
            else if (!double.IsNaN(doubleInnerSuccess) && double.IsNaN(doubleOuterSuccess))
            {
                if (doubleInnerSuccess.Equals(1))
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
            else if (double.IsNaN(doubleInnerSuccess) && !double.IsNaN(doubleOuterSuccess))
            {
                if (doubleOuterSuccess.Equals(1))
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                return "NaN";
            }
        }

        public void getFileButtonFunction()
        {
            if (InvokeRequired)
            {
                spinningWheel.Invoke((MethodInvoker)delegate {
                    spinningWheel.Visible = true;
                    spinningWheel.Refresh();                    
                });
                getFileButton.Invoke((MethodInvoker)delegate { getFileButton.Enabled = false; });
            }
            if (user.files == null) // If files not initiated, do now
            {
                user.files = new List<ProgrammeLogic.ExcelFile>();
            }
            var TempExcelFile = new ProgrammeLogic.ExcelFile(); // create a new ExcelFile
            TempExcelFile.file = openFileDialog1.FileName; // set file name
            if (ListSheets(TempExcelFile.file).Count == 0)  // catch if listsheeets returns early indicating catch triggered
            {
                getFileButton.Invoke((MethodInvoker)delegate { getFileButton.Enabled = true; });
                return;
            }
            TempExcelFile.worksheets = ListSheets(TempExcelFile.file); // set all sheets in file
            user.files.Add(TempExcelFile); // Append to user.files list
            if (InvokeRequired)
            {
                searchingFilesTextField.Invoke((MethodInvoker)delegate
                {
                    searchingFilesTextField.AppendText(openFileDialog1.FileName);
                    searchingFilesTextField.AppendText(Environment.NewLine);                    
                });
                spinningWheel.Invoke((MethodInvoker)delegate { spinningWheel.Visible = false; });
                getFileButton.Invoke((MethodInvoker)delegate { getFileButton.Enabled = true; });
                
            }
        }
        private void getFileButton_Click(object sender, EventArgs e)
        {
            DialogResult filePath = openFileDialog1.ShowDialog();
            if (filePath == DialogResult.OK)
            {
                Thread t2 = new Thread(getFileButtonFunction)
                {
                    Name = "Thread2"
                };
                t2.Start();
            }
            
            
        }
        public static DataTable ConvertCSVtoDataTable(string sCsvFilePath)
        {
            DataTable dtTable = new DataTable();
            Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

            

            using (StreamReader sr = new StreamReader(sCsvFilePath))
            {
                for (int i = 0; i < 4; i++)
                {
                    sr.ReadLine();
                    // System.Diagnostics.Debug.WriteLine($"Skipped {i}");
                }
                string[] headers = sr.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    dtTable.Columns.Add(header);
                }
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string[] rows = CSVParser.Split(sr.ReadLine());
                    DataRow dr = dtTable.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i].Replace("\"", string.Empty);
                    }
                    dtTable.Rows.Add(dr);
                }
            }
            return dtTable;
        }

        private void ClearConsoleButton_Click(object sender, EventArgs e)
        {
            if (!(resultsTextField.Text == ""))
            {
                var confirmResult = MessageBox.Show("Are you sure you want to clear the console?",
                                         "Confirmation required",
                                         MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    resultsTextField.Text = "";
                }
                else
                {
                    // If 'No', do something here.
                }
            }
        }

        private void InformationButton_Click(object sender, EventArgs e)
        {
            Form aboutBox = new AboutBox();
            aboutBox.Show();
            //string message = "How to use:\nThis software has been designed to conform to the current\nVulcan shot record procedure (Excel format, 2022).\nAfter having retrieved the data you require, you may need to undertake\nsome minimal 'tidying up' to get the data in the form you require. This is mainly\nbecause some shots will want to be passed even though they conform to\nthe failure protocol in this software, or because you have been\nable to identify the reason for an inconclusive shot and wish to update it.\nYou can either adjust the excel document and rerun the programme, or\nadjust and resave the statistics text file.";
            //string title = "Software information - How to Use";
            //MessageBox.Show(message, title);
        }

        private void StartOverButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to reset?",
                                        "Confirmation required",
                                        MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                LocationToSaveTextField.Text = "";
                nameOfStatsFileTextField.Text = "";
                areaDropDown.Text = "";
                searchingFilesTextField.Text = "";
                resultsTextField.Text = "";
                progressBar1.Value = 0;
                StatisticsTextBox.Text = "";
                //dataGridView1.DataSource = null;
                user.Reset();
                ConsoleMessage("Reset complete.");
            }
            else
            {
                // If 'No', do something here.
            }
        }

        private void removeFile_Click(object sender, EventArgs e)
        {            
            if (user.files == null) // If files not initiated, do now
            {
                ErrorMessage("There are no files to remove");
            }
            else
            {
                var confirmResult = MessageBox.Show("Are you sure you want to remove the last file?",
                                         "Confirmation required",
                                         MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    user.files.RemoveAt(user.files.Count - 1);
                    searchingFilesTextField.Text = "";
                    for (int i = 0; i < user.files.Count; i++)
                    {                        
                        searchingFilesTextField.AppendText(user.files[i].file);
                    }
                }
                else
                {
                    // If 'No', do something here.
                }
            }
            
        }
    }
}