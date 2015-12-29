<Query Kind="Program" />

void Main()
{
	
}
//https://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k%28EHInvalidOperation.WinForms.IllegalCrossThreadCall%29%3bk%28TargetFrameworkMoniker-.NETFramework%2cVersion%3Dv4.5.2%29&rd=true

// This method demonstrates a pattern for making thread-safe
// calls on a Windows Forms control. 
//
// If the calling thread is different from the thread that
// created the TextBox control, this method creates a
// SetTextCallback and calls itself asynchronously using the
// Invoke method.
//
// If the calling thread is the same as the thread that created
// the TextBox control, the Text property is set directly. 
delegate void SetTextCallback(string text);
private void SetText(string text)
{
	// InvokeRequired required compares the thread ID of the
	// calling thread to the thread ID of the creating thread.
	// If these threads are different, it returns true.
	if (this.textBox1.InvokeRequired)
	{
		SetTextCallback d = new SetTextCallback(SetText);
		this.Invoke(d, new object[] { text });
	}
	else
	{
		this.textBox1.Text = text;
	}
}




