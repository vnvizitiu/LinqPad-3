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
//http://stackoverflow.com/questions/2340411/use-linq-to-xml-with-xml-namespaces
string assemblypath = @"C:\VisualStudioExercises\Test_Console\InstallShieldProjects\TestPackaging\TestPackaging\bin\Debug\TestPackaging.exe";
string appConfigPath = assemblypath + ".config";

string theXml = System.IO.File.ReadAllText(appConfigPath);

//http://stackoverflow.com/questions/7227193/xelement-descendants-doesnt-work-with-namespace
XElement myElement = XElement.Parse(theXml);

var h = myElement.Descendants().Where(e => e.Name.LocalName == "setting");
foreach (var element in h)
{
Console.WriteLine(element.Attribute("name").Value);
Console.WriteLine(element.Value);
element.Value = "new value";
}

}

void MainOriginal()//http://www.c-sharpcorner.com/UploadFile/27c648/create-a-custom-setup-for-change-app-onfig/
{
	try
	{
		#region ifinside_application
		//http://www.c-sharpcorner.com/UploadFile/27c648/create-a-custom-setup-for-change-app-onfig/
		//		string assemblypath = Context.Parameters["assemblypath"];
		//		string appConfigPath = assemblypath + ".config";
		#endregion
		//string TESTPARAMETER = Context.Parameters["MSGAPP"];

		// Get the path to the executable file that is being installed on the target computer  
		string assemblypath = @"C:\VisualStudioExercises\Test_Console\InstallShieldProjects\TestPackaging\TestPackaging\bin\Debug\TestPackaging.exe";
		string appConfigPath = assemblypath + ".config.xml";
		//	MessageBox.Show(assemblypath);
		//	MessageBox.Show(appConfigPath);


		// Write the path to the app.config file  
		XmlDocument doc = new XmlDocument();
		doc.Load(appConfigPath);
		 
		

		XmlNode configuration = null;
		foreach (XmlNode node in doc.ChildNodes)
			if (node.Name == "configuration")
				configuration = node;

		if (configuration != null)
		{
			XmlNode settingNode = null;
			foreach (XmlNode node in configuration.ChildNodes)
			{
				if (node.Name == "userSettings")
				{
		
					settingNode = node;
				//	MessageBox.Show(node.Name);
					Console.WriteLine(node.ChildNodes.Count);
					XElement myElement = XElement.Parse(node.OuterXml);
					myElement.Dump();
					var h = myElement.Descendants().Where(e => e.Name.LocalName == "setting");
					foreach (var element in h)
					{
						Console.WriteLine(element.Attribute("name").Value);
						Console.WriteLine(element.Value);
						element.Value="new value";
					 
				 		Console.WriteLine(element.Value);
					 

					}
					foreach (var element in h)
					{
						Console.WriteLine(element.Attribute("name").Value);
						Console.WriteLine(element.Value);
					}


				}


			}


			doc.Save(appConfigPath);
		}

	}
	catch (Exception ex)
	{
		MessageBox.Show(ex.ToString());
		throw;
	}
}

// Define other methods and classes here