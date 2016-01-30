<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>



    class Listing_05 {

        static void Main(string[] args) {

            // create the task
            Task<int> task1 = new Task<int>(() => {
                int sum = 0;
                for (int i = 0; i < 100; i++) {
                    sum += i;
                }
                return sum;
            });

            // start the task
            task1.Start();

            // write out the result
            Console.WriteLine("Result 1: {0}", task1.Result);

            // create the task using state
            Task<int> task2 = new Task<int>(obj => {
                int sum = 0;
                int max = (int)obj;
                for (int i = 0; i < max; i++) {
                    sum += i;
                }
                return sum;
            }, 100);

            // start the task
            task2.Start();

		// write out the result
		Console.WriteLine("Result 2: {0}", task2.Result);



		// create the task
		Task<string> taskSAM = new Task<string>(() =>
		{
			int sum = 0;
			for (int i = 0; i < 100; i++)
			{
				sum += i;
			}
			return "SAM";
		});

		// start the task
		taskSAM.Start();

		// write out the result
		Console.WriteLine("Result 1: {0}", taskSAM.Result);
		Console.WriteLine("Result 1: {0}", taskSAM.Status);
		Console.WriteLine("Result 1: {0}", taskSAM.IsCompleted);
		Console.WriteLine("Result 1: {0}", taskSAM.Id);

		// wait for input before exiting
		Console.WriteLine("Main method complete. Press enter to finish.");


		// Make a list of integers.
		List<int> list = new List<int>();
		list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });


		// Now process each argument within a group of
		// code statements.
		List<int> evenNumbers = list.FindAll((i) =>
		{
		///	Console.WriteLine("value of i is currently: {0}", i);
			bool isEven = ((i % 2) == 0);
			return isEven;
		});

		Console.WriteLine("Here are your even numbers:");
		foreach (int evenNumber in evenNumbers)
		{
			Console.Write("{0}\t", evenNumber);
		}
		Console.WriteLine();

	}
}
