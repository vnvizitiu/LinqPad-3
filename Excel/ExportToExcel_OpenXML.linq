<Query Kind="Program">
  <Reference>&lt;ProgramFilesX86&gt;\Open XML SDK\V2.5\lib\DocumentFormat.OpenXml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xml.XDocument.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <Namespace>DocumentFormat.OpenXml</Namespace>
  <Namespace>DocumentFormat.OpenXml.Packaging</Namespace>
  <Namespace>DocumentFormat.OpenXml.Spreadsheet</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Data</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Reflection</Namespace>
  <Namespace>System.Text</Namespace>
</Query>

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Diagnostics;
//using System.Data;
//using System.Reflection;
//using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml.Spreadsheet;
//using DocumentFormat.OpenXml;
    //

//http://www.codeproject.com/Articles/692092/A-free-Export-to-Excel-Csharp-class-using-OpenXML#xx4715594xx
//http://mikesknowledgebase.azurewebsites.net/pages/CSharp/ExportToExcel.htm


//http://mikesknowledgebase.azurewebsites.net/pages/CSharp/ExportToExcel.htm

//http://mikesknowledgebase.azurewebsites.net/pages/CSharp/ExportToExcel.htm
void Main()
{	

			string conn=GetConnectionString();

 	 using (SqlConnection connection = new SqlConnection(
               conn))
    {	
		//SqlParameter myParam= new SqlParameter();
				
//		myParam.ParameterName="@SystemNo";
//		myParam.DbType=DbType.Int16;;
//		myParam.Value=10;
		
        SqlCommand command = new SqlCommand();
			SqlDataAdapter Adpt = default(SqlDataAdapter); //new
			Adpt = new SqlDataAdapter(command); //new
		
		
		command.CommandText="GetResults"; //proc name
		command.CommandType=CommandType.StoredProcedure;
		//command.Parameters.Add(myParam);
		//command.Parameters.AddWithValue(8);
		command.Connection=connection;
		
		
//		DataTable  dt = new DataTable();
//        command.Connection.Open();
		
				DataTable  ds = new DataTable();
        command.Connection.Open();
	 
		
		Adpt.Fill(ds);
		
		 string excelFilename = "C:\\Sample.xlsx";
     CreateExcelFile.CreateExcelDocument(ds, excelFilename);
		
//			for (int i = 0; i <= dt.Columns.Count - 1; i++)
//		{
// 			Console.WriteLine(dt.Columns[i].ToString());
// 	//	Console.WriteLine(dt.Columns[i]);
//		}
//		
//	 
		List<DataRow> mylist = ds.AsEnumerable().ToList();
	 
		
		foreach (DataRow element  in mylist)
		{
			Console.WriteLine(element.ItemArray[0].ToString());
		}
		
		
      //  command.ExecuteNonQuery();
    }

	// Step 1: Create a DataSet, and put some sample data in it
  //  DataSet ds = CreateSampleData();

// Step 2: Create the Excel .xlsx file
// try
// {
//     string excelFilename = "C:\\Sample.xlsx";
//     CreateExcelFile.CreateExcelDocument(ds, excelFilename);
// }
// catch (Exception ex)
// { 
//     //MessageBox.Show("Couldn't create Excel file.\r\nException: " + ex.Message);
//	 Console.WriteLine("Couldn't create Excel file.\r\nException: " + ex.Message);
//     return;
// }
}









//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Diagnostics;
//using System.Data;
//using System.Reflection;
//using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml.Spreadsheet;
//using DocumentFormat.OpenXml;
    //
    //  January 2013
    //  http://www.mikesknowledgebase.com
    //
    //  Release history
    //   - Jan 2013: Fix: Couldn't open .xlsx files using OLEDB  (was missing "WorkbookStylesPart" part)
    //   - Nov 2012: 
    //        List<>s with Nullable columns weren't be handled properly.
    //        If a value in a numeric column doesn't have any data, don't write anything to the Excel file (previously, it'd write a '0')
    //   - Jul 2012: Fix: Some worksheets weren't exporting their numeric data properly, causing "Excel found unreadable content in '___.xslx'" errors.
    //   - Mar 2012: Fixed issue, where Microsoft.ACE.OLEDB.12.0 wasn't able to connect to the Excel files created using this class.
    //
    public class CreateExcelFile
    {
        public static bool CreateExcelDocument<T>(List<T> list, string xlsxFilePath)
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(ListToDataTable(list));

            return CreateExcelDocument(ds, xlsxFilePath);
        }

        //  This function is adapated from: http://www.codeguru.com/forum/showthread.php?t=450171
        //  My thanks to Carl Quirion, for making it "nullable-friendly".
        public static DataTable ListToDataTable<T>(List<T> list)
        {
            DataTable dt = new DataTable();

            foreach (PropertyInfo info in typeof(T).GetProperties())
            {
                dt.Columns.Add(new DataColumn(info.Name, GetNullableType(info.PropertyType)));
            }
            foreach (T t in list)
            {
                DataRow row = dt.NewRow();
                foreach (PropertyInfo info in typeof(T).GetProperties())
                {
                    if (!IsNullableType(info.PropertyType))
                        row[info.Name] = info.GetValue(t, null);
                    else
                        row[info.Name] = (info.GetValue(t, null) ?? DBNull.Value);
                }
                dt.Rows.Add(row);
            }
            return dt;
        }
        private static Type GetNullableType(Type t)
        {
            Type returnType = t;
            if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                returnType = Nullable.GetUnderlyingType(t);
            }
            return returnType;
        }
        private static bool IsNullableType(Type type)
        {
            return (type == typeof(string) ||
                    type.IsArray ||
                    (type.IsGenericType &&
                     type.GetGenericTypeDefinition().Equals(typeof(Nullable<>))));
        }

        public static bool CreateExcelDocument(DataTable dt, string xlsxFilePath)
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);

            return CreateExcelDocument(ds, xlsxFilePath);
        }

        public static bool CreateExcelDocument(DataSet ds, string excelFilename)
        {
            try
            {
                using (SpreadsheetDocument document = SpreadsheetDocument.Create(excelFilename, SpreadsheetDocumentType.Workbook))
                {
                    document.AddWorkbookPart();
                    document.WorkbookPart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();

                    //  My thanks to James Miera for the following line of code (which prevents crashes in Excel 2010)
                    document.WorkbookPart.Workbook.Append(new BookViews(new WorkbookView()));

                    //  If we don't add a "WorkbookStylesPart", OLEDB will refuse to connect to this .xlsx file !
                    WorkbookStylesPart workbookStylesPart = document.WorkbookPart.AddNewPart<WorkbookStylesPart>("rIdStyles");
                    Stylesheet stylesheet = new Stylesheet();
                    workbookStylesPart.Stylesheet = stylesheet;

                    CreateParts(ds, document);
                }
                Trace.WriteLine("Successfully created: " + excelFilename);
                return true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Failed, exception thrown: " + ex.Message);
                return false;
            }
        }

        private static void CreateParts(DataSet ds, SpreadsheetDocument spreadsheet)
        {
            //  Loop through each of the DataTables in our DataSet, and create a new Excel Worksheet for each.
            uint worksheetNumber = 1;
            foreach (DataTable dt in ds.Tables)
            {
                //  For each worksheet you want to create
                string workSheetID = "rId" + worksheetNumber.ToString();
                string worksheetName = dt.TableName;

                WorksheetPart newWorksheetPart = spreadsheet.WorkbookPart.AddNewPart<WorksheetPart>();
                newWorksheetPart.Worksheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet();

                // create sheet data
                newWorksheetPart.Worksheet.AppendChild(new DocumentFormat.OpenXml.Spreadsheet.SheetData());

                // save worksheet
                WriteDataTableToExcelWorksheet(dt, newWorksheetPart);
                newWorksheetPart.Worksheet.Save();

                // create the worksheet to workbook relation
                if (worksheetNumber == 1)
                    spreadsheet.WorkbookPart.Workbook.AppendChild(new DocumentFormat.OpenXml.Spreadsheet.Sheets());

                spreadsheet.WorkbookPart.Workbook.GetFirstChild<DocumentFormat.OpenXml.Spreadsheet.Sheets>().AppendChild(new DocumentFormat.OpenXml.Spreadsheet.Sheet()
                {
                    Id = spreadsheet.WorkbookPart.GetIdOfPart(newWorksheetPart),
                    SheetId = (uint)worksheetNumber,
                    Name = dt.TableName
                });

                worksheetNumber++;
            }

            spreadsheet.WorkbookPart.Workbook.Save();
        }


        private static void WriteDataTableToExcelWorksheet(DataTable dt, WorksheetPart worksheetPart)
        {
            var worksheet = worksheetPart.Worksheet;
            var sheetData = worksheet.GetFirstChild<SheetData>();

            string cellValue = "";

            //  Create a Header Row in our Excel file, containing one header for each Column of data in our DataTable.
            //
            //  We'll also create an array, showing which type each column of data is (Text or Numeric), so when we come to write the actual
            //  cells of data, we'll know if to write Text values or Numeric cell values.
            int numberOfColumns = dt.Columns.Count;
            bool[] IsNumericColumn = new bool[numberOfColumns];

            string[] excelColumnNames = new string[numberOfColumns];
            for (int n = 0; n < numberOfColumns; n++)
                excelColumnNames[n] = GetExcelColumnName(n);

            //
            //  Create the Header row in our Excel Worksheet
            //
            uint rowIndex = 1;

            var headerRow = new Row { RowIndex = rowIndex };  // add a row at the top of spreadsheet
            sheetData.Append(headerRow);

            for (int colInx = 0; colInx < numberOfColumns; colInx++)
            {
                DataColumn col = dt.Columns[colInx];
                AppendTextCell(excelColumnNames[colInx] + "1", col.ColumnName, headerRow);
                IsNumericColumn[colInx] = (col.DataType.FullName == "System.Decimal") || (col.DataType.FullName == "System.Int32");
            }

            //
            //  Now, step through each row of data in our DataTable...
            //
            double cellNumericValue = 0;
            foreach (DataRow dr in dt.Rows)
            {
                // ...create a new row, and append a set of this row's data to it.
                ++rowIndex;
                var newExcelRow = new Row { RowIndex = rowIndex };  // add a row at the top of spreadsheet
                sheetData.Append(newExcelRow);

                for (int colInx = 0; colInx < numberOfColumns; colInx++)
                {
                    cellValue = dr.ItemArray[colInx].ToString();

                    // Create cell with data
                    if (IsNumericColumn[colInx])
                    {
                        //  For numeric cells, make sure our input data IS a number, then write it out to the Excel file.
                        //  If this numeric value is NULL, then don't write anything to the Excel file.
                        cellNumericValue = 0;
                        if (double.TryParse(cellValue, out cellNumericValue))
                        {
                            cellValue = cellNumericValue.ToString();
                            AppendNumericCell(excelColumnNames[colInx] + rowIndex.ToString(), cellValue, newExcelRow);
                        }
                    }
                    else
                    {
                        //  For text cells, just write the input data straight out to the Excel file.
                        AppendTextCell(excelColumnNames[colInx] + rowIndex.ToString(), cellValue, newExcelRow);
                    }
                }
            }
        }

        private static void AppendTextCell(string cellReference, string cellStringValue, Row excelRow)
        {
            //  Add a new Excel Cell to our Row 
            Cell cell = new Cell() { CellReference = cellReference, DataType = CellValues.String };
            CellValue cellValue = new CellValue();
            cellValue.Text = cellStringValue;
            cell.Append(cellValue);
            excelRow.Append(cell);
        }

        private static void AppendNumericCell(string cellReference, string cellStringValue, Row excelRow)
        {
            //  Add a new Excel Cell to our Row 
            Cell cell = new Cell() { CellReference = cellReference };
            CellValue cellValue = new CellValue();
            cellValue.Text = cellStringValue;
            cell.Append(cellValue);
            excelRow.Append(cell);
        }

        private static string GetExcelColumnName(int columnIndex)
        {
            //  Convert a zero-based column index into an Excel column reference  (A, B, C.. Y, Y, AA, AB, AC... AY, AZ, B1, B2..)
            //
            //  eg  GetExcelColumnName(0) should return "A"
            //      GetExcelColumnName(1) should return "B"
            //      GetExcelColumnName(25) should return "Z"
            //      GetExcelColumnName(26) should return "AA"
            //      GetExcelColumnName(27) should return "AB"
            //      ..etc..
            //
            if (columnIndex < 26)
                return ((char)('A' + columnIndex)).ToString();

            char firstChar = (char)('A' + (columnIndex / 26) - 1);
            char secondChar = (char)('A' + (columnIndex % 26));

            return string.Format("{0}{1}", firstChar, secondChar);
        }
    }





    private static string GetConnectionString()
    {
        // To avoid storing the connection string in your code,             
        // you can retrieve it from a configuration file.  

        // If you have not included "Asynchronous Processing=true" in the
        // connection string, the command is not able 
        // to execute asynchronously. 
        return "Data Source=WIN-90API3QKTDS;Integrated Security=SSPI;" +
            "Initial Catalog=NorthWind; Asynchronous Processing=true";
    }



