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
  <GACReference>Microsoft.Office.Interop.Excel, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c</GACReference>
  <Namespace>Microsoft.Office.Interop.Excel</Namespace>
</Query>

Sub Main
	
	Dim _activities As List(Of Activity)
	Dim _destinations As List(Of Destination)
	
	
	'_context = New BAGA.BAEntities()
	Try
                '_activities = Activities.OrderBy(Function(a) a.Name).ToList() 'ok
                ' _destinations = Destinations.OrderBy(Function(d) d.Name).ToList() 'ok
        
             '   Dim customers As List(Of Customer) = Customers.Include("Contact").Include("Reservations.Trip").ToList()
                ' Dim customers As List(Of BAGA.Customer) = _context.Customers.Include("ContactID").Include("InitialDate").ToList()
				'_activities.dump() ' ok
				'_destinations.dump() 'ok
				
			'	for each e in _destinations 'ok
			'	console.writeline(e.Trips) 'ok
			'	console.writeline(e.Name) 'ok
			'	Next 
				
	
				'for each x in customers 'ok
				'console.writeline (customers) 'ok
				'next 'ok
				
				dim result=(from e in Customers where e.ContactID>20 
				Select e.ContactID, e.Notes,e.InitialDate,e.CustomerType.Type)
				result.dump()
				
				
				
               'customers.dump()
            Catch ex As Exception
                Console.writeline (ex.Message & "Sam")
            End Try
			

	
	
                             

End Sub