<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Concurrent</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

class ConcurrentCollection
{ 
    static void Main()
	{
		ConcurrentQueue<int> queue = new ConcurrentQueue<int>();

		//Sum of a single thread adding the numbers as we queue them.
		int SingleThreadSum = 0;

		// Populate the queue. 
		for (int i = 0; i < 5000; i++)
		{
			SingleThreadSum += i;
			queue.Enqueue(i);
		}

		//Print the Sum of 0 to 5000.
		Console.WriteLine("Single Thread Sum = {0}", SingleThreadSum);

		//Sum of a multithread adding of the numbers.
		int MultiThreadSum = 0;

		//Create an Action delegate to dequeue items and sum them.
		Action localAction = () =>
		{
			int localSum = 0;
			int localValue;

			while (queue.TryDequeue(out localValue)) localSum += localValue;

			Interlocked.Add(ref MultiThreadSum, localSum);
		};

		// Run 3 concurrent Tasks.
		Parallel.Invoke(localAction, localAction, localAction);

		//Print the Sum of 0 to 5000 done by 3 separate threads.
		Console.WriteLine("MultiThreaded  Sum = {0}", MultiThreadSum);

		Console.ReadLine();
	}
}
