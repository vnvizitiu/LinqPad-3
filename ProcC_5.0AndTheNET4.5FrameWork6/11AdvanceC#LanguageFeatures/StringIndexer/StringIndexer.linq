<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>


    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine("***** Fun with Indexers *****\n");

            PersonCollection myPeople = new PersonCollection();

            myPeople["Homer"] = new Person("Homer", "Simpson", 40);
            myPeople["Marge"] = new Person("Marge", "Simpson", 38);

            // Get "Homer" and print data.
            Person homer = myPeople["Homer"];
            Console.WriteLine(homer.ToString());

           // Console.ReadLine();
        }
    }



    public class Person
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person() { }
        public Person(string firstName, string lastName, int age)
        {
            Age = age;
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return string.Format("Name: {0} {1}, Age: {2}",
              FirstName, LastName, Age);
        }
    }



    public class PersonCollection : IEnumerable
    {
        private Dictionary<string, Person> listPeople =
          new Dictionary<string, Person>();

        // This indexer returns a person based on a string index.
        public Person this[string name]
        {
            get { return (Person)listPeople[name]; }
            set { listPeople[name] = value; }
        }

        public void ClearPeople()
        { listPeople.Clear(); }

        public int Count
        { get { return listPeople.Count; } }

        IEnumerator IEnumerable.GetEnumerator()
        { return listPeople.GetEnumerator(); }
    }
