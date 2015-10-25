<Query Kind="Statements">
  <Reference Relative="..\LINQ\ExcelQueryFactory_Assembly\LinqToExcel.dll">&lt;MyDocuments&gt;\LINQ\ExcelQueryFactory_Assembly\LinqToExcel.dll</Reference>
  <Reference Relative="..\LINQ\ExcelQueryFactory_Assembly\log4net.dll">&lt;MyDocuments&gt;\LINQ\ExcelQueryFactory_Assembly\log4net.dll</Reference>
  <Reference Relative="..\LINQ\ExcelQueryFactory_Assembly\Remotion.Data.Linq.dll">&lt;MyDocuments&gt;\LINQ\ExcelQueryFactory_Assembly\Remotion.Data.Linq.dll</Reference>
  <Reference Relative="..\LINQ\ExcelQueryFactory_Assembly\Remotion.dll">&lt;MyDocuments&gt;\LINQ\ExcelQueryFactory_Assembly\Remotion.dll</Reference>
  <Reference Relative="..\LINQ\ExcelQueryFactory_Assembly\Remotion.Interfaces.dll">&lt;MyDocuments&gt;\LINQ\ExcelQueryFactory_Assembly\Remotion.Interfaces.dll</Reference>
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

var excel = new ExcelQueryFactory(@"C:\Users\Administrator\Documents\LINQ\ForLinq.xlsx");
var oldCompanies = from c in excel.Worksheet("Company") //worksheet name = 'US Companies'
                //   where c.FirstName=="Rob"
				   select c;
				   oldCompanies.Dump();
				   		  //'https://github.com/paulyoder/LinqToExcel

