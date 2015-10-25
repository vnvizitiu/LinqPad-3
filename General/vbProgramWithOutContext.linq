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
</Query>

Sub Main
	
	Dim _activities As List(Of Activity)
	Dim _destinations As List(Of Destination)
	
	'_context = New BAGA.BAEntities()
	Try
                _activities = Activities.OrderBy(Function(a) a.Name).ToList()
                _destinations = Destinations.OrderBy(Function(d) d.Name).ToList()
        
             '   Dim customers As List(Of Customer) = Customers.Include("Contact").Include("Reservations.Trip").ToList()
                ' Dim customers As List(Of BAGA.Customer) = _context.Customers.Include("ContactID").Include("InitialDate").ToList()
				_activities.dump()
				_destinations.dump()
               'customers.dump()
            Catch ex As Exception
                Console.writeline (ex.Message & "Sam")
            End Try
End Sub