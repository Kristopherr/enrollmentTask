using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enrollmentTask
{
    internal class Person
    {
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }

        public int AGE { get; set; }
        public string ID { get; set; }
        public Person() { }

        public Person(string fName, string lName, int age, string id) 
        {
            this.FIRSTNAME = fName;
            this.LASTNAME = lName;
            this.AGE = age;
            this.ID = id;
        }

        public void GetFirstName()
        {
            Console.WriteLine("Please Enter your first name");
            FIRSTNAME = Console.ReadLine();
        }

        public void GetLastName()
        {
            Console.WriteLine("Please Enter your last name");
            LASTNAME = Console.ReadLine();
        }

        public void GetAge()
        {
            Console.WriteLine("Enter Your Age");
            AGE = int.Parse(Console.ReadLine());
        }


    }
}
