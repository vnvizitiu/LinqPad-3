<Query Kind="VBStatements">
  <Connection>
    <ID>37f30f2b-7522-4a17-a059-b417e9358a57</ID>
    <Persist>true</Persist>
    <Server>L50045421\MSSQLSERVER2008</Server>
    <Database>AdventureWorks</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Output>DataGrids</Output>
</Query>

dim x= from C in Contacts, d in c.ContactCreditCards 
Select c,d where C.ContactID<5
x.dump()
 


dim x= from C in Contacts, d in c.ContactCreditCards 
Select C.FirstName, C.LastName where C.ContactID<5
x.dump()