<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Windows.Forms</Namespace>
</Query>

void Main()
{
       var test = "Hello";
            new Thread( new ThreadStart(() =>
            {
                try
                {
                    //Staff to do            
                    Console.WriteLine(test);
                    Thread.Sleep(10000);
                    MessageBox.Show(test);
                                  Console.WriteLine("Thread finished");

                }
                          catch (Exception ex)
                           {
                                 MessageBox.Show(ex.ToString());
                                  throw;
                          }
                     })).Start();
       Console.WriteLine("finished outside of thread");
       MessageBox.Show("Finished");

}
