<Query Kind="Statements">
  <Output>DataGrids</Output>
  <Reference>D:\ExcelLibrary_20110730\ExcelLibrary.dll</Reference>
  <Reference>D:\LinqToExcel_1.7.1\LinqToExcel.dll</Reference>
  <Reference>D:\LinqToExcel_1.7.1\log4net.dll</Reference>
  <Reference>D:\LinqToExcel_1.7.1\Remotion.Data.Linq.dll</Reference>
  <Reference>D:\LinqToExcel_1.7.1\Remotion.dll</Reference>
  <Reference>D:\LinqToExcel_1.7.1\Remotion.Interfaces.dll</Reference>
  <Namespace>ExcelLibrary</Namespace>
  <Namespace>ExcelLibrary.BinaryDrawingFormat</Namespace>
  <Namespace>ExcelLibrary.BinaryFileFormat</Namespace>
  <Namespace>ExcelLibrary.CompoundDocumentFormat</Namespace>
  <Namespace>ExcelLibrary.SpreadSheet</Namespace>
  <Namespace>LinqToExcel</Namespace>
  <Namespace>LinqToExcel.Domain</Namespace>
  <Namespace>LinqToExcel.Extensions</Namespace>
  <Namespace>LinqToExcel.Query</Namespace>
  <Namespace>QiHe.CodeLib</Namespace>
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


var excelQuery = new ExcelQueryFactory(@"\\naunsw019\samtran\delete\testass.xlsx");
var rows = from x in excelQuery.Worksheet()
select x;
rows.Dump();

var book = new LinqToExcel.ExcelQueryFactory(@"\\naunsw019\samtran\delete\testass.xlsx");
var query =
    from row in book.WorksheetRange("A4", "B16384")
    select new
    {
        Name = row["Name"].Cast<string>(),
        Age = row["Age"].Cast<int>(),
    };

