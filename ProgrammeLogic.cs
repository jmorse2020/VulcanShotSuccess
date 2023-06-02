using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronXL;

namespace VulcanShotSuccess
{
    public class ProgrammeLogic
    {
        public struct userSelection {
            public string saveLocation;
            public string nameOfStatFile;
            public string area;
            public List<ExcelFile> files;

            public void Reset()
            {
                saveLocation = String.Empty;
                nameOfStatFile = String.Empty;
                area = String.Empty;
                if (files == null)
                {
                    // do nothing
                }
                else
                {
                    files.Clear();
                }
            }
        }

        public struct ExcelFile
        {
            public string file;
            public List<string> worksheets;
        }
        public string TXTextension(string NameOfDataFile, MainForm form1)
        {
            int length = NameOfDataFile.Length;
            if (length == 0)
            {
                return "";
            }
            int start = (length - 4);
            if ((length < 4) || (NameOfDataFile.Substring(start, 4) != ".txt")) {
                NameOfDataFile = string.Concat(NameOfDataFile, "SuccessData.csv");
                form1.AddSuccessDataLine();
            }
            return NameOfDataFile;
        }

        // Function for DataString //
        public List<string> ShotDataString(string filename, string sheetname, string area)
        {
            List<string> DataString = new List<string>();
            int ShotCount = 1;
            var workbook = WorkBook.Load(filename);
            var worksheet = workbook.GetWorkSheet(sheetname);
            var data = worksheet.ToDataTable();
            //foreach(var d in data)
            //{

            //}
            return DataString;
        }

        public struct FailedShotContainer
        {
            public string comments;
            public string reason;
            public string date;
            public string innerOsc;
            public string outerOsc;
            public string shotType;
        }

        public struct InconclusiveShotContainer
        {
            public string comments;
            public string reason;
            public string date;
            public string innerOsc;
            public string outerOsc;
            public string shotType;
        }
    }
}
