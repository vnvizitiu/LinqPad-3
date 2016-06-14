<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.VisualBasic.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.dll</Reference>
  <Namespace>Microsoft.VisualBasic.FileIO</Namespace>
  <Namespace>System.Data.OleDb</Namespace>
</Query>

//http://stackoverflow.com/questions/14261655/best-fastest-way-to-read-an-excel-sheet-into-a-datatable
void Main()
{
	string file=@"C:\Users\Administrator\Downloads\delete\1\mycsv.txt";
	DataTable RcsvData= new DataTable();
	RcsvData=GetDataTabletFromCSVFile(file);
	
	for (int i = 0; i <= RcsvData.Columns.Count - 1; i++)
		{
	//		Console.WriteLine(RcsvData.Columns[i].ToString());
	//		Console.WriteLine(RcsvData.Columns[i]);
		}
	
		List<DataRow> mylist = RcsvData.AsEnumerable().ToList();
	 		
		foreach (DataRow element  in mylist)
		{
			Console.WriteLine(element.ItemArray[0].ToString()+ " "+element.ItemArray[1].ToString()+ " "+element.ItemArray[2].ToString());
		}
	}

private static DataTable GetDataTabletFromCSVFile(string csv_file_path)
{	
	DataTable csvData=new DataTable();
	string tableDelim=",";
	
   // csvData = new DataTable(defaultTableName);
csvData = new DataTable();
    try
    {
        using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
        {
            csvReader.SetDelimiters(new string[]
            {
               tableDelim 
			 //  ","
            });
            csvReader.HasFieldsEnclosedInQuotes = true;
            string[] colFields = csvReader.ReadFields();
            foreach (string column in colFields)
            {
                DataColumn datecolumn = new DataColumn(column);
                datecolumn.AllowDBNull = true;
                csvData.Columns.Add(datecolumn);
            }

            while (!csvReader.EndOfData)
            {
                string[] fieldData = csvReader.ReadFields();
                //Making empty value as null
                for (int i = 0; i < fieldData.Length; i++)
                {
                    if (fieldData[i] == string.Empty)
                    {
                        fieldData[i] = string.Empty; //fieldData[i] = null
                    }
                    //Skip rows that have any csv header information or blank rows in them
                    if (fieldData[0].Contains("Disclaimer") || string.IsNullOrEmpty(fieldData[0]))
                    {
                        continue;
                    }
                }
                csvData.Rows.Add(fieldData);
            }
        }
    }
    catch (Exception ex)
    {
    }
    return csvData;
}
// Define other methods and classes here