<Query Kind="VBProgram">
  <Connection>
    <ID>f8ea445a-40e7-43c8-8ee7-3bad781710c8</ID>
    <Persist>true</Persist>
    <Server>vaunsw302\sqlpro_ciapps2</Server>
    <Database>ThreeWayRec</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Output>DataGrids</Output>
  <Reference>&lt;ProgramFiles&gt;\Microsoft Visual Studio 10.0\Visual Studio Tools for Office\PIA\Office14\Microsoft.Office.Interop.Excel.dll</Reference>
  <Reference>&lt;ProgramFiles&gt;\Microsoft Visual Studio 10.0\Visual Studio Tools for Office\PIA\Office14\Office.dll</Reference>
  <Namespace>Microsoft.Office.Core</Namespace>
  <Namespace>Microsoft.Office.Interop.Excel</Namespace>
</Query>

Sub Main
    ' Create new Application.

            Dim excel As Application = New Application
            ' Open Excel spreadsheet.
            Dim w As Workbook = excel.Workbooks.Open("\\naunsw019\samtran\delete\Runs.xlsx")
            ' Loop over all sheets.
    
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
					
				 end if 
					
										
				
										
					Console.writeline ("This is the value: " & sheet.Range("A2").value)
					dim myValue as integer=sheet.Range("A2").value
						
					dim myAList as new ArrayList
					For x as integer=2 to array.GetUpperBound(0)
					With myAlist
					    .Add(New record With {.RunNo = array(x,1), .System = array(x,2)})
            		        			
       				End With
					next 
					w.close()
					
					' for each record in myAlist
					' console.writeline (record.RunNo)
					' next
					 
					
					
								
	dim result=(from e in App_run_nos 
				Select e )
				dim results=result.tolist()
				results.dump()
			'http://msdn.microsoft.com/en-us/library/bb918093.aspx	

			dim output=(from c in results join record in myAlist on Record.RunNo equals c.Run_No
	       select c)
	      output.dump()
			
			
			' Late binding operations cannot be converted to an expression tree.
'	dim output=(from e in App_run_nos join record in myAlist on Record.RunNo equals e.Run_No
'	select e)
'	output.dump()
				
				
				
End Sub


Public Class Record

    Public Property RunNO As integer
    Public Property System As String
    'Public ReadOnly Property FullName As String
     '   Get
      '      Return String.Join(", ", RunNo, System)
       ' End Get
  '  End Property

End Class












' Define other methods and classes here