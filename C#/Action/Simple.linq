<Query Kind="Program">
  <Namespace>System</Namespace>
</Query>

//
//Action objects return no values.The Action type is similar to a void method.
//It must never return a value onto the evaluation stack. This generic type is found in the System namespace.
//Void
//
//Example. Let us start.In this program, the Actions point to anonymous functions. These functions cannot return values onto the evaluation stack.
//An Action instance can receive parameters, but cannot return values.
//class Program//http://www.dotnetperls.com/action

	static void Main()
    {
		// Example Action instances.
		// ... First example uses one parameter.
		// ... Second example uses two parameters.
		// ... Third example uses no parameter.
		// ... None have results.
		Action<int> example1 =
			(int x) => Console.WriteLine("Write {0}", x);
		Action<int, int> example2 =
			(x, y) => Console.WriteLine("Write {0} and {1}", x, y);
		Action example3 =
			() => Console.WriteLine("Done");
		// Call the anonymous methods.
		example1.Invoke(1);
		example2.Invoke(2, 3);
		example3.Invoke();
	}
