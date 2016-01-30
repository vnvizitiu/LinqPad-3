<Query Kind="Program">
  <Namespace>System.Data.Common</Namespace>
</Query>

static void Main(string[] args)

        {

            try

            {

                System.Data.DataTable dt = System.Data.Common.DbProviderFactories.GetFactoryClasses();

                for (int i = 0; i < dt.Rows.Count; i++)

                    Console.WriteLine("{0}: {1}", i.ToString(), dt.Rows[i][2].ToString());

                Console.WriteLine("------------------------------------------------------\n");

            }

            catch (Exception ex)

            {

                Console.WriteLine(ex);

            }

}
