<Query Kind="VBProgram">
  <Output>DataGrids</Output>
  <Reference Relative="..\..\Downloads\EntityFrameworkDownload\LinqToExcel_x64_1.7.1\LinqToExcel.dll">C:\Users\Administrator\Downloads\EntityFrameworkDownload\LinqToExcel_x64_1.7.1\LinqToExcel.dll</Reference>
  <Reference Relative="..\..\Downloads\EntityFrameworkDownload\LinqToExcel_x64_1.7.1\Remotion.Data.Linq.dll">C:\Users\Administrator\Downloads\EntityFrameworkDownload\LinqToExcel_x64_1.7.1\Remotion.Data.Linq.dll</Reference>
  <Reference Relative="..\..\Downloads\EntityFrameworkDownload\LinqToExcel_x64_1.7.1\Remotion.dll">C:\Users\Administrator\Downloads\EntityFrameworkDownload\LinqToExcel_x64_1.7.1\Remotion.dll</Reference>
  <Reference Relative="..\..\Downloads\EntityFrameworkDownload\LinqToExcel_x64_1.7.1\Remotion.Interfaces.dll">C:\Users\Administrator\Downloads\EntityFrameworkDownload\LinqToExcel_x64_1.7.1\Remotion.Interfaces.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.dll</Reference>
  <GACReference>Microsoft.VisualStudio.OLE.Interop, Version=7.1.40304.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a</GACReference>
  <Namespace>LinqToExcel</Namespace>
  <Namespace>LinqToExcel.Domain</Namespace>
  <Namespace>LinqToExcel.Extensions</Namespace>
  <Namespace>LinqToExcel.Query</Namespace>
  <Namespace>Microsoft.SqlServer.Server</Namespace>
  <Namespace>Microsoft.VisualStudio.OLE.Interop</Namespace>
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
  <Namespace>System.Data</Namespace>
  <Namespace>System.Data.Common</Namespace>
  <Namespace>System.Data.Odbc</Namespace>
  <Namespace>System.Data.OleDb</Namespace>
  <Namespace>System.Data.Sql</Namespace>
  <Namespace>System.Data.SqlClient</Namespace>
  <Namespace>System.Data.SqlTypes</Namespace>
  <Namespace>System.Xml</Namespace>
</Query>

Sub Main
	   Dim fileName = "C:\Users\Administrator\Downloads\LinqToExcel_VBExample\LinqToExcel_VBExample\bin\Debug\Names.xlsx"
        Dim book = New LinqToExcel.ExcelQueryFactory(fileName)
		Console.writeline (book)
       '  dim  users = From x In book.Worksheet<Sheet1>()  Where x.FirstName = "Paul" 
		dim  users = From x In book.Worksheet(Of User)()  Where x.FirstName = "Paul" _ 
          Select x

        For Each u In users
            Console.WriteLine(u.FirstName + " " + u.LastName)
        Next
       ' Console.ReadKey()
	   users.dump()
End Sub
Public Class User
    Private _firstName As String
    Private _lastName As String
    Private _role As String
    Private _age As Integer

    Property FirstName() As String
        Get
            Return _firstName
        End Get
        Set(ByVal value As String)
            _firstName = value
        End Set
    End Property

    Property LastName() As String
        Get
            Return _lastName
        End Get
        Set(ByVal value As String)
            _lastName = value
        End Set
    End Property

    Property Role() As String
        Get
            Return _role
        End Get
        Set(ByVal value As String)
            _role = value
        End Set
    End Property

    Property Age() As Integer
        Get
            Return _age
        End Get
        Set(ByVal value As Integer)
            _age = value
        End Set
    End Property
End Class

' Define other methods and classes here
