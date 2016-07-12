<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationCore.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\UIAutomationProvider.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\UIAutomationTypes.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\ReachFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationUI.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\System.Printing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Deployment.dll</Reference>
  <Namespace>System.Windows</Namespace>
</Query>

void Main()
{
	string codeBase = Assembly.GetExecutingAssembly().CodeBase;
	Console.WriteLine(codeBase);
	//http://stackoverflow.com/questions/2340411/use-linq-to-xml-with-xml-namespaces
	//http://www.codeproject.com/Articles/35379/Basics-of-Handling-XML-using-LINQ
string assemblypath = @"C:\VisualStudioExercises\Test_Console\InstallShieldProjects\TestPackaging\TestPackaging\bin\Debug\TestPackaging.exe";
 
string appConfigPath = assemblypath + ".config";

	//Load the XML File
	XElement dataElements = XElement.Load(appConfigPath);
	//	dataElements.Element("user").Element("name").ReplaceNodes("sss");
	//	dataElements.Element("user").Element("password").ReplaceNodes("Ray");
	var h =dataElements.Descendants().Where(e => e.Name.LocalName == "setting"); //http://stackoverflow.com/questions/7227193/xelement-descendants-doesnt-work-with-namespace
	h.Dump();
	Console.WriteLine(h.GetType());
	foreach (var element in h)
	{
		Console.WriteLine(element.Attribute("name").Value);
		Console.WriteLine(element.Attribute("serializeAs").Value);
		Console.WriteLine(element.Value);
		//element.Value.ToString().Replace(element.Value.ToString(), "sam"); //doesn't work
		element.SetElementValue("value", "Sam Rocks");
		//element.Value = "xxx"; //Don't do this, updates but changes file
		switch (element.Attribute("name").Value)
		{
			case "MSG":
				element.SetElementValue("value", "Sam Rocks");
				break;
			case "MSGAPP":
				element.SetElementValue("value", "Raymond Rocks");
				break;
			default:
				Console.WriteLine("Nothing Found");
				element.SetElementValue("value", "Krystal Rocks");
				break;


		}

	}
	// Save the file
	dataElements.Save(appConfigPath);

}