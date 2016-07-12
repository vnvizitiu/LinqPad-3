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
	try
	{
		//string TESTPARAMETER = Context.Parameters["MSGAPP"];

		// Get the path to the executable file that is being installed on the target computer  
		string assemblypath = @"C:\VisualStudioExercises\Test_Console\InstallShieldProjects\TestPackaging\TestPackaging\bin\Debug\TestPackaging.exe";
		string appConfigPath = assemblypath + ".config";
		MessageBox.Show(assemblypath);
		MessageBox.Show(appConfigPath);


		// Write the path to the app.config file  
		XmlDocument doc = new XmlDocument();
		doc.Load(appConfigPath);

		XmlNode configuration = null;
		foreach (XmlNode node in doc.ChildNodes)
			if (node.Name == "configuration")
				configuration = node;

		if (configuration != null)
		{
			//MessageBox.Show("configuration != null");  
			// Get the ‘appSettings’ node  
			XmlNode settingNode = null;
			foreach (XmlNode node in configuration.ChildNodes)
			{
				if (node.Name == "userSettings")
					settingNode = node;
				MessageBox.Show(node.Name);
				MessageBox.Show(node.Value);
			}

			if (settingNode != null)
			{
				MessageBox.Show(settingNode?.InnerText);
				//Reassign values in the config file  
				foreach (XmlNode node in settingNode.ChildNodes)
				{
					MessageBox.Show("node.Value = " + node?.Value);
					if (node.Attributes == null)
						continue;
					XmlAttribute attribute = node.Attributes["value"];
					//MessageBox.Show("attribute != null ");  
					MessageBox.Show("node.Attributes['value'] = " + node?.Attributes["value"].Value);
					if (node.Attributes["key"] != null)
					{
						//MessageBox.Show("node.Attributes['key'] != null ");  
						MessageBox.Show("node.Attributes['key'] = " + node?.Attributes?["key"].Value);
						MessageBox.Show(node.Attributes?["key"]?.Value);
						switch (node.Attributes["key"]?.Value)
						{

							case "MSGAPP":
							//	attribute.Value = TESTPARAMETER;
								MessageBox.Show(attribute?.Value);
								break;

						}
						MessageBox.Show(attribute?.Value);
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
