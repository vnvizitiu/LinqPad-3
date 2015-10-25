<Query Kind="VBProgram">
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.dll</Reference>
  <Namespace>System.Data.OleDb</Namespace>
</Query>

'Imports System.Data.OleDb

Sub Main
	Dim ExcelCon As New OleDbConnection
	        Dim ExcelAdp As OleDbDataAdapter
	        Dim ExcelComm As OleDbCommand
	        Dim Col1 As DataColumn
			dim strFilePath as string="C:\Users\Administrator\Downloads\delete\Linqpad.xlsx"
	        Try
	            ExcelCon.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
	                "Data Source= " & StrFilePath & _
	                ";Extended Properties=""Excel 8.0;"""
	            ExcelCon.Open()
	 
	            dim StrSql = "Select * From [Sheet1$]"
	            ExcelComm = New OleDbCommand(StrSql, ExcelCon)
	            ExcelAdp = New OleDbDataAdapter(ExcelComm)
	            dim objdt = New DataTable()
	            ExcelAdp.Fill(objdt)
				 ExcelCon.Close()
			
				For i=0 to objdt.columns.count-1
					console.writeline(objdt.columns(i).tostring())
				next 
				
				console.writeline()
				console.writeline()
				
						   
			 For I = 1 To objdt.Rows.Count
                For j = 0 To objdt.Columns.Count - 1
                     
                   Console.writeline(objdt.Rows(I - 1)(j).ToString())
                Next
            Next
				
				
				
	         
	          '  ExcelCon.Close()
	        Catch ex As Exception
	            
	        Finally
	            ExcelCon = Nothing
	            ExcelAdp = Nothing
	            ExcelComm = Nothing
	        End Try
End Sub

' Define other methods and classes here
