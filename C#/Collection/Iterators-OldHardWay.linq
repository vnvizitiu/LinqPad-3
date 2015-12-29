<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections</Namespace>
  <Namespace>System.ComponentModel</Namespace>
</Query>

[Description("Listing 6.1/6.2/6.3")]
//Chapter 1: C# in Depth 3rd Edition
class IterationSample : IEnumerable
{
	object[] values;
	int startingPoint;

	public IterationSample(object[] values, int startingPoint)
	{
		this.values = values;
		this.startingPoint = startingPoint;
	}

	public IEnumerator GetEnumerator()
	{
		return new IterationSampleIterator(this);
	}

	class IterationSampleIterator : IEnumerator
	{
		IterationSample parent;
		int position;

		internal IterationSampleIterator(IterationSample parent)
		{
			this.parent = parent;
			position = -1;
		}

		public bool MoveNext()
		{
			if (position != parent.values.Length)
			{
				position++;
			}
			return position < parent.values.Length;
		}

		public object Current
		{
			get
			{
				if (position == -1 ||
					position == parent.values.Length)
				{
					throw new InvalidOperationException();
				}
				int index = (position + parent.startingPoint);
				index = index % parent.values.Length;
				return parent.values[index];
			}
		}

		public void Reset()
		{
			position = -1;
		}
	}

	static void Main()
	{
		object[] values = { "a", "b", "c", "d", "e" };
		IterationSample collection = new IterationSample(values, 3);
		foreach (object x in collection)
		{
			Console.WriteLine(x);
		}
	}
}