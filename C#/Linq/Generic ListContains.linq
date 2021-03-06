<Query Kind="Statements">
  <Reference Relative="..\..\..\..\..\AppData\Roaming\LINQPad\Samples\LINQ in Action\LinqInAction.LinqBooks.Common.dll">&lt;ApplicationData&gt;\LINQPad\Samples\LINQ in Action\LinqInAction.LinqBooks.Common.dll</Reference>
  <Namespace>LinqInAction.LinqBooks.Common</Namespace>
</Query>

List<Book> books = new List<Book>() {
  new Book { Title="LINQ in Action" },
  new Book { Title="LINQ for Fun" },
  new Book { Title="Extreme LINQ" } };

var titles = books
    .Where(book => book.Title.Contains("Action"))
    .Select(book => book.Title);
Console.WriteLine(titles);

//titles.Dump();