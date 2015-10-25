<Query Kind="Statements">
  <Connection>
    <ID>65e0892b-2c67-48c8-9d4f-3aa69a59de16</ID>
    <Server>.\SQLEXPRESS</Server>
    <AttachFile>true</AttachFile>
    <UserInstance>true</UserInstance>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\Samples\LINQ in Action\lia6-8.mdf</AttachFileName>
  </Connection>
  <Output>DataGrids</Output>
</Query>

//http://stackoverflow.com/questions/5573851/reading-text-files-with-linq
var targetLines = File.ReadAllLines(@"\\naunsw002\CIS0_Workteam_sy$\Radar Production\Prudent\pastrans\PR080713.txt")
                      .Select((x, i) => new { Line = x, LineNumber = i })
                      //.Where( x => x.Line.Contains("pattern"))
                      .ToList();

foreach (var line in targetLines)
{
  Console.WriteLine("{0} : {1}", line.LineNumber, line.Line);
}

targetLines.Dump();
