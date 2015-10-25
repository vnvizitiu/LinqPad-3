<Query Kind="VBStatements">
  <Connection>
    <ID>f8ea445a-40e7-43c8-8ee7-3bad781710c8</ID>
    <Persist>true</Persist>
    <Server>vaunsw302\sqlpro_ciapps2</Server>
    <Database>ThreeWayRec</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Output>DataGrids</Output>
</Query>

dim var =from e in Transaction_L400_gl_etls join ee in Transref_gl_etls on e.rec_transaction_id equals ee.transaction_ref where e.rec_transaction_id>1265590767 and e.run_no=14562
Select e
for each element in var
debug.print (element.up_key)
Next 
var.Dump()