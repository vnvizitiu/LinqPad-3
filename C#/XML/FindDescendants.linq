<Query Kind="Program" />

void Main() //https://msdn.microsoft.com/en-us/library/bb387067.aspx
{
	XElement root = XElement.Parse(@"<root>
  <para>
    <r>
      <t>Some text </t>
    </r>
    <n>
      <r>
        <t>that is broken up into </t>
      </r>
    </n>
    <n>
      <r>
        <t>multiple segments.</t>
      </r>
    </n>
  </para>
</root>");
	IEnumerable<string> textSegs =
		from seg in root.Descendants("t")
		select (string)seg;

	string str = textSegs.Aggregate(new StringBuilder(),
		(sb, i) => sb.Append(i),
		sp => sp.ToString()
	);
 
	Console.WriteLine(str);
}

// Define other methods and classes here