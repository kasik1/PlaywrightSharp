using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace CustomerHelperUtility
{
    public class ExcelHelper
    {
        /// <summary>
        /// Reads the excel file and returns a table results
        /// </summary>
        /// <param name="fileName">The file path of the excel file that will be used in the </param>
        /// <returns></returns>
		private static DataTable ExcelToDataTable(string fileName, string sheet)
        {
            //open file and returns as Stream
            using (FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader excelReader;
                //Createopenxmlreader via ExcelReaderFactory
                if (fileName.Contains("xlsx"))
                {
                    excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                }
                else
                {
                    excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                }
                //Return as DataSet
                var result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });
                //Get all the Tables
                DataTableCollection table = result.Tables;
                //Store it in DataTable
                int changeToSheet = table.IndexOf(sheet);
                DataTable resultTable = table[changeToSheet];
                return resultTable;
            }

        }

        private readonly List<Datacollection> dataCol = new List<Datacollection>();
        /// <summary>
        /// Gets the rows, columns, and columns values results and store it in a DataCollection
        /// </summary>
        /// <param name="filePath"></param>
		public void LoadFile(string filePath, string sheetName)
        {
            DataTable table = ExcelToDataTable(filePath, sheetName);

            //Iterate through the rows and columns of the Table
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        RowNumber = row,
                        ColName = table.Columns[col].ColumnName,
                        ColValue = table.Rows[row - 1][col].ToString()
                    };
                    //Add all the details for each row
                    dataCol.Add(dtTable);
                }
            }
        }
        /// <summary>
        /// Retrives the Column Value based on the Row number and the top Column Name
        /// </summary>
        /// <param name="rowNumber">The Row Number in the excel sheet to look from</param>
        /// <param name="columnName">The Colunmn Name header row in the excel sheet to look from</param>
        /// <returns></returns>
		public string ReadCellValue(int rowNumber, string columnName)
        {
            try
            {
                //Retriving Data using LINQ to reduce much of iterations
                string data = (from colData in dataCol
                               where colData.ColName == columnName && colData.RowNumber == rowNumber
                               select colData.ColValue).SingleOrDefault();
                return data.ToString();
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }
        /// <summary>
        /// Retrives the values in the top column name given as a List
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
		public List<string> ReadColumnValues(string columnName)
        {
            var data = dataCol.Where(x => x.ColName == columnName).Select(x => x.ColValue).ToList();
            return data;
        }
        /// <summary>
        /// Retrives the values in the row based on the row number
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <returns></returns>
		public List<string> ReadRowValues(int rowNumber)
        {
            var data = dataCol.Where(x => x.RowNumber == rowNumber).Select(x => x.ColValue).ToList();
            return data;
        }
        /// <summary>
        /// Retrives the Column value based on the value of the Test Case Step column
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public string GetValueFromTestStep(string testCaseStep, string columnName)
        {
            try
            {
                //Get a list values from the Test Case Step Column then get the row number from a certain value from the column
                List<string> testCaseColumn = ReadColumnValues("Test Case Step");
                int rowNumber = testCaseColumn.IndexOf(testCaseStep) + 2 ;

                //Retriving Data using LINQ to reduce much of iterations
                string data = (from colData in dataCol
                               where colData.ColName == columnName && colData.RowNumber == rowNumber
                               select colData.ColValue).SingleOrDefault();
                return data.ToString();
            }
            catch (Exception ex)
            {
                throw new ConduentUIAutomationException(ex.Message);
            }
        }
    }

    public class Datacollection
    {
        public int RowNumber { get; set; }
        public string ColName { get; set; }
        public string ColValue { get; set; }
    }
}
