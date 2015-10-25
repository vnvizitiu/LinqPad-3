<Query Kind="VBProgram">
  <Connection>
    <ID>f8ea445a-40e7-43c8-8ee7-3bad781710c8</ID>
    <Persist>true</Persist>
    <Server>vaunsw302\sqlpro_ciapps2</Server>
    <Database>ThreeWayRec</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Output>DataGrids</Output>
</Query>

  Sub Main() 'http://support.microsoft.com/kb/302309
        Dim objReader As New StreamReader("\\naunsw002\CIS0_Workteam_sy$\Radar Production\Prudent\pastrans\PR080713.txt")
		'Dim objReader As New StreamReader("X:\Finance\Systems Accounting\Daily Validations\Toad Queries\Monthly Queries\X.txt")
        Dim sLine As String = ""
        Dim arrText As New ArrayList()

        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()

        For Each sLine In arrText
            Console.WriteLine(sLine)
        Next
		
       arrText.dump()
		
		
    End Sub

