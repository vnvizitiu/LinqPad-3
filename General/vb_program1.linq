<Query Kind="VBProgram">
  <Connection>
    <ID>700055bf-cade-4221-9ea3-2ee8255fed1a</ID>
    <Persist>true</Persist>
    <Server>WIN-90API3QKTDS</Server>
    <IncludeSystemObjects>true</IncludeSystemObjects>
    <Database>BreakAway</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Output>DataGrids</Output>
</Query>

Sub Main 
dim results= (From e in Contacts join c  in customers on e.ContactId equals c.ContactId
select e.firstname, e.contactid, c.Notes
)
For each element in results
debug.print (element.firstname)
debug.print(element.Notes)
debug.print(element.contactid)
next 

End Sub

