<Query Kind="VBProgram">
  <Connection>
    <ID>b89c6662-db50-49a5-a29f-8d85b49306e5</ID>
    <Persist>true</Persist>
    <Driver>EntityFramework</Driver>
    <Server>L50045421\MSSQLSERVER2008</Server>
    <CustomAssemblyPathEncoded>&lt;MyDocuments&gt;\Visual Studio 2010\2e Chapter 9 Windows Forms VB\BreakAwayModel\bin\Debug\BreakAwayModel.dll</CustomAssemblyPathEncoded>
    <CustomAssemblyPath>\\naunsw019\samtran\Visual Studio 2010\2e Chapter 9 Windows Forms VB\BreakAwayModel\bin\Debug\BreakAwayModel.dll</CustomAssemblyPath>
    <CustomTypeName>BAGA.BAEntities</CustomTypeName>
    <CustomMetadataPath>res://BreakAwayModel/BAModel.csdl|res://BreakAwayModel/BAModel.ssdl|res://BreakAwayModel/BAModel.msl</CustomMetadataPath>
    <Database>BreakAway</Database>
  </Connection>
  <Output>DataGrids</Output>
  <Reference>&lt;ProgramFiles&gt;\Microsoft Visual Studio 10.0\Visual Studio Tools for Office\PIA\Office14\Office.dll</Reference>
  <GACReference>Microsoft.Office.Interop.Excel, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c</GACReference>
  <Namespace>Microsoft.Office.Core</Namespace>
  <Namespace>Microsoft.Office.Interop.Excel</Namespace>
</Query>

Sub Main
	
	Dim _activities As List(Of Activity)
	Dim _destinations As List(Of Destination)
	
	
	'_context = New BAGA.BAEntities()
	Try
             
				
						
				     ' Create new Application.
            Dim excel As Application = New Application
            ' Open Excel spreadsheet.
            Dim w As Workbook = excel.Workbooks.Open("\\naunsw019\samtran\delete\Custs.xlsx")
            ' Loop over all sheets.
            For i As Integer = 1 To w.Sheets.Count
                ' Get sheet.
                Dim sheet As Worksheet = w.Sheets(1)
                ' Get range.
                Dim r As Range = sheet.UsedRange
                ' Load all cells into 2d array.
                Dim array(,) As Object = r.Value(XlRangeValueDataType.xlRangeValueDefault)
                ' Scan the cells.
                If array IsNot Nothing Then
                    Console.WriteLine("Length: {0}", array.Length)
                    ' Get bounds of the array.
                    Dim bound0 As Integer = array.GetUpperBound(0)
                    Dim bound1 As Integer = array.GetUpperBound(1)
                    Console.WriteLine("Dimension 0: {0}", bound0)
                    Console.WriteLine("Dimension 1: {0}", bound1)
                    ' Loop over all elements.
                    For j As Integer = 1 To bound0
                        For x As Integer = 1 To bound1
                            Dim s1 As String = array(j, x)
                            Console.Write(s1)
                            Console.Write(" "c)
                        Next
                        Console.WriteLine()
                    Next
					Console.writeline ("This is the value: " & sheet.Range("A2").value)
					dim myValue as integer=sheet.Range("A2").value
				dim result=(from e in Customers where e.ContactID= myValue
				Select e.ContactID, e.Notes,e.InitialDate,e.CustomerType.Type)
				result.dump()
                End If
            Next
            ' Close.
            w.Close()
				
				
               'customers.dump()
            Catch ex As Exception
                Console.writeline (ex.Message & "Sam")
            End Try
			

	
	
                             

End Sub