<Query Kind="Program" />

void Main()
{
	A newA= new A();
	A anotherA=new A();
	newA.a="Sam";
	newA.b="Tran";
	Console.WriteLine("anotherA.b:" +anotherA.b); 
	//Console.WriteLine(newA.b);
	DuckCopyShallow(anotherA,newA);
	//DuckCopyShallow(newA,anotherA);
	Console.WriteLine("anotherA.a after copy:" +anotherA.a); 
	Console.WriteLine("anotherA.b after copy:" +anotherA.b); 
	//Console.WriteLine(anotherA.b);
}


public class A
{
    public string a;
    public string b;
	 
}
// Define other methods and classes here



 public static void DuckCopyShallow( Object dst, object src)
    {
        var srcT = src.GetType();
        var dstT= dst.GetType();
        foreach(var f in srcT.GetFields())
        {
            var dstF = dstT.GetField(f.Name);
            if (dstF == null)
                continue;
            dstF.SetValue(dst, f.GetValue(src));
        }

        foreach (var f in srcT.GetProperties())
        {
            var dstF = dstT.GetProperty(f.Name);
            if (dstF == null)
                continue;

            dstF.SetValue(dst, f.GetValue(src, null), null);
        }
    }
