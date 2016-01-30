<Query Kind="Program" />

private void button1_Click(object sender, System.EventArgs e)
{
	Button btn = (Button)sender;
	this.textBox1.Text = btn.Text;
	//http://forums.asp.net/t/343932.aspx?How+can+I+get+values+of+sender+object+in+C
}
