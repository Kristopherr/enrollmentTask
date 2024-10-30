using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enrollmentTask
{
    internal class Teacher : Person
    {
        public string TEACHERID {  get; set; }

        public Teacher() { }

        public Teacher(string fName, string lName, int age, string id) : base(lName, fName, age, id) 
        { 
            TEACHERID = id;
        }

       
    }
}
