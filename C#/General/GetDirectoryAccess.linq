<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Security.AccessControl</Namespace>
  <Namespace>System.Security.Principal</Namespace>
</Query>

///http://stackoverflow.com/questions/1281620/checking-for-directory-and-file-write-permissions-in-net
//using System;
//using System.IO;
//using System.Security.AccessControl;
//using System.Security.Principal;
    class Program
    {
        static void Main(string[] args)
        {
            string directory = @"C:\Users\Sam\Downloads\Oracle12_ODT";

            DirectoryInfo di = new DirectoryInfo(directory);

            DirectorySecurity ds = di.GetAccessControl();

          /// foreach (AccessRule rule in ds.GetAccessRules(true, true, typeof(NTAccount)))
			foreach (AccessRule rule in ds.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier)))
            {
                Console.WriteLine("Identity = {0}; Access = {1}", 
                              rule.IdentityReference.Value, rule.AccessControlType);
            }
        }
    }
