<Query Kind="VBStatements">
  <Reference Relative="..\LINQ\ExcelQueryFactory_Assembly\LinqToExcel.dll">&lt;MyDocuments&gt;\LINQ\ExcelQueryFactory_Assembly\LinqToExcel.dll</Reference>
  <Reference Relative="..\LINQ\ExcelQueryFactory_Assembly\Remotion.Data.Linq.dll">&lt;MyDocuments&gt;\LINQ\ExcelQueryFactory_Assembly\Remotion.Data.Linq.dll</Reference>
  <Reference Relative="..\LINQ\ExcelQueryFactory_Assembly\Remotion.dll">&lt;MyDocuments&gt;\LINQ\ExcelQueryFactory_Assembly\Remotion.dll</Reference>
  <Reference Relative="..\LINQ\ExcelQueryFactory_Assembly\Remotion.Interfaces.dll">&lt;MyDocuments&gt;\LINQ\ExcelQueryFactory_Assembly\Remotion.Interfaces.dll</Reference>
  <Namespace>LinqToExcel</Namespace>
  <Namespace>LinqToExcel.Domain</Namespace>
  <Namespace>LinqToExcel.Extensions</Namespace>
  <Namespace>LinqToExcel.Query</Namespace>
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
</Query>

dim excel = new ExcelQueryFactory("C:\Users\Administrator\Documents\LINQ\ForLinq.xlsx")
dim oldCompanies = from c in excel.Worksheet("Company")  
                   select C where c.FirstName="Sam"
				   oldcompanies.tolist()
				   oldCompanies.Dump()
				 '  dim x= from d in oldcompanies where d.FirstName="Guy" select d
				  ' x.dump()
				   'https://github.com/paulyoder/LinqToExcel
