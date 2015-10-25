<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Simple IO with the File Type *****\n");
            try
            {
                string[] myTasks = {
                  "Fix bathroom sink", "Call Dave",
                  "Call Mom and Dad", "Play Xbox 360"};

                // Write out all data to file on C drive.
                File.WriteAllLines(@"C:\Users\Administrator\SkyDrive\Documents\DownloadedCodes\C#\ProcC_5.0AndTheNET4.5FrameWork6thEdition\Chapter 20\SimpleFileIO\Test.txt", myTasks);

                // Read it all back and print out.
                foreach (string task in File.ReadAllLines(@"C:\Users\Administrator\SkyDrive\Documents\DownloadedCodes\C#\ProcC_5.0AndTheNET4.5FrameWork6thEdition\Chapter 20\SimpleFileIO\Test.txt"))
                {
                    Console.WriteLine("TODO: {0}", task);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        //    Console.ReadLine();
        }
    }

