<Query Kind="Program">
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\120\SDK\Assemblies\Microsoft.SqlServer.ConnectionInfo.dll</Reference>
  <Reference>C:\Windows\assembly\GAC_MSIL\Microsoft.SqlServer.Management.IntegrationServices\12.0.0.0__89845dcd8080cc91\Microsoft.SqlServer.Management.IntegrationServices.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\120\SDK\Assemblies\Microsoft.SqlServer.Management.Sdk.Sfc.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\120\SDK\Assemblies\Microsoft.SqlServer.Smo.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\120\SDK\Assemblies\Microsoft.SqlServer.SmoExtended.dll</Reference>
  <Namespace>Microsoft.SqlServer.Management.Smo</Namespace>
  <Namespace>Microsoft.SqlServer.Management.Smo.Agent</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Data</Namespace>
  <Namespace>System.Data.SqlClient</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>Microsoft.SqlServer.Management.IntegrationServices</Namespace>
</Query>

//http://social.technet.microsoft.com/wiki/contents/articles/21978.execute-ssis-2012-package-with-parameters-via-net.aspx?CommentPosted=true#commentmessage
//http://microsoft-ssis.blogspot.com.au/2013/01/call-ssis-2012-package-within-net.html
//http://microsoft-ssis.blogspot.com.au/2013/01/call-ssis-2012-package-within-net.html
// Connection to the database server where the packages are located

public class Form1x
{

	private void StartPackageButton_Click()
	{
		// Connection to the database server where the packages are located
		SqlConnection ssisConnection = new SqlConnection(@"Data Source=.\SQL2012;Initial Catalog=master;Integrated Security=SSPI;");

		// SSIS server object with connection
		IntegrationServices ssisServer = new IntegrationServices(ssisConnection);

		// The reference to the package which you want to execute
			PackageInfo ssisPackage = ssisServer.Catalogs["SSISDB"].Folders["MasterChild"].Projects["MasterChildPackages"].Packages["master.dtsx"];

			// Add execution parameter to override the default asynchronized execution. If you leave this out the package is executed asynchronized
			//Collection<PackageInfo.ExecutionValueParameterSet> executionParameter = new Collection<PackageInfo.ExecutionValueParameterSet>();
			executionParameter.Add(new PackageInfo.ExecutionValueParameterSet { ObjectType = 50, ParameterName = "SYNCHRONIZED", ParameterValue = 1 });

			// Get the identifier of the execution to get the log
			long executionIdentifier = ssisPackage.Execute(false, null, executionParameter);

			// Loop through the log and add the messages to the listbox
			foreach (OperationMessage message in ssisServer.Catalogs["SSISDB"].Executions[executionIdentifier].Messages)
			{
				//SSISMessagesListBox.Items.Add(message.MessageType.ToString() + ": " + message.Message);
			}
		}

	}
 