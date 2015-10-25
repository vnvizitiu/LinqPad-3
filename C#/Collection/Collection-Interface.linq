<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Collections.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.Linq.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Linq</Namespace>
</Query>

//using System;
//using System.Collections.Generic;
//using System.Linq;
//C:\Users\Sam\SkyDrive\Documents\vb_docs\Collections\Having fun with custom collections! - CodeProject.mht
void Main()
{
//	dim wa as new WesternAlphabet
//	wa.doSomething()
	
	WesternAlphabet wa = new WesternAlphabet(); 
	//WesternAlphabet.DoSomething();
	wa.DoSomething();
	
	
}


    public class WesternAlphabet : IEnumerable<String>
    {

       IEnumerable<String> _alphabet;
	  

        public WesternAlphabet()
        {
            _alphabet = new string[] { "A", "B", "C", 
               "D", "E", "F", "G", 
               "H", "I", "J", "K", 
               "L", "M", "N", "O", 
               "P", "Q", "R", "S", 
               "T", "U", "V", "W", 
               "X", "Y", "Z" };
			   
			 
        }
		
 
 
		
	public 	 void DoSomething()
		{
 	
		int c =  _alphabet.Count();
		for (int i=0; i <_alphabet.Count(); i++)	
		{
	 		
			Console.WriteLine(c);
			// Console.WriteLine(_alphabet(i).tostring()); //http://stackoverflow.com/questions/1532814/how-to-loop-through-a-collection-that-supports-ienumerable
			 string str=_alphabet.ElementAt(i);
			 Console.WriteLine(str);
		}
		 
 	
		 
		 }
		 

 
	
 
		
		
		

        public System.Collections.Generic.IEnumerator<String> GetEnumerator()
        {
            return new WesternAlphabetEnumerator(_alphabet);
        }

        System.Collections.IEnumerator 
               System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal class WesternAlphabetEnumerator : IEnumerator<String>
    {

        private IEnumerable<String> _alphabet;
        private int _position;
        private int _max;

        public WesternAlphabetEnumerator(IEnumerable<String> alphabet)
        {
            _alphabet = alphabet;
            _position = -1;
            _max = _alphabet.Count() - 1;
        }

        public string Current
        {
            get { return _alphabet.ElementAt(_position); }
        }

        object System.Collections.IEnumerator.Current
        {
            get { return this.Current; }
        }

        public bool MoveNext()
        {
            if (_position < _max)
            {
                _position += 1;
                return true;
            }
            return false;
        }

        void System.Collections.IEnumerator.Reset()
        {
            throw new NotImplementedException();
        }

        public void Dispose() { }
    }