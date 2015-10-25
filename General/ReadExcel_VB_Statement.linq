<Query Kind="VBStatements">
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
  <Reference>D:\LinqToExcel_1.7.1\LinqToExcel.dll</Reference>
  <Reference>D:\LinqToExcel_1.7.1\log4net.dll</Reference>
  <Reference>D:\LinqToExcel_1.7.1\Remotion.Data.Linq.dll</Reference>
  <Reference>D:\LinqToExcel_1.7.1\Remotion.dll</Reference>
  <Reference>D:\LinqToExcel_1.7.1\Remotion.Interfaces.dll</Reference>
  <Namespace>LinqToExcel</Namespace>
  <Namespace>LinqToExcel.Domain</Namespace>
  <Namespace>LinqToExcel.Extensions</Namespace>
  <Namespace>LinqToExcel.Query</Namespace>
  <Namespace>Remotion</Namespace>
  <Namespace>Remotion.BridgeInterfaces</Namespace>
  <Namespace>Remotion.Collections</Namespace>
  <Namespace>Remotion.Context</Namespace>
  <Namespace>Remotion.Data.Linq</Namespace>
  <Namespace>Remotion.Data.Linq.Clauses</Namespace>
  <Namespace>Remotion.Data.Linq.Clauses.Expressions</Namespace>
  <Namespace>Remotion.Data.Linq.Clauses.ExpressionTreeVisitors</Namespace>
  <Namespace>Remotion.Data.Linq.Clauses.ResultOperators</Namespace>
  <Namespace>Remotion.Data.Linq.Clauses.StreamedData</Namespace>
  <Namespace>Remotion.Data.Linq.Collections</Namespace>
  <Namespace>Remotion.Data.Linq.EagerFetching</Namespace>
  <Namespace>Remotion.Data.Linq.EagerFetching.Parsing</Namespace>
  <Namespace>Remotion.Data.Linq.Parsing</Namespace>
  <Namespace>Remotion.Data.Linq.Parsing.ExpressionTreeVisitors</Namespace>
  <Namespace>Remotion.Data.Linq.Parsing.ExpressionTreeVisitors.MemberBindings</Namespace>
  <Namespace>Remotion.Data.Linq.Parsing.ExpressionTreeVisitors.TreeEvaluation</Namespace>
  <Namespace>Remotion.Data.Linq.Parsing.Structure</Namespace>
  <Namespace>Remotion.Data.Linq.Parsing.Structure.IntermediateModel</Namespace>
  <Namespace>Remotion.Data.Linq.Transformations</Namespace>
  <Namespace>Remotion.Data.Linq.Utilities</Namespace>
  <Namespace>Remotion.Design</Namespace>
  <Namespace>Remotion.Implementation</Namespace>
  <Namespace>Remotion.Logging</Namespace>
  <Namespace>Remotion.Logging.BridgeInterfaces</Namespace>
  <Namespace>Remotion.Mixins</Namespace>
  <Namespace>Remotion.Mixins.BridgeInterfaces</Namespace>
  <Namespace>Remotion.Reflection</Namespace>
  <Namespace>Remotion.Reflection.TypeDiscovery</Namespace>
  <Namespace>Remotion.Utilities</Namespace>
</Query>

dim excelQuery = new ExcelQueryFactory("\\naunsw019\samtran\delete\testass.xlsx")
dim rows = from x in excelQuery.Worksheet()
select x
For each element in rows
console.writeline (element)
Next
'rows.dump()