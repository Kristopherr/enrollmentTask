using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace enrollmentTask
{
    internal class Student : Person
    {
        public string STUDENTID {  get; set; }
        public Student() { }
        public Student (string fName,  string lName, int AGE, string id) : base(lName, fName, AGE, id)
        {
            STUDENTID = id;
        }

        static string GetID(string lName, string fName, string id, int AGE) 
        {
            char lInitial = lName[0];
            char fInitial = fName[0];

            id = lName + fInitial + AGE;
            return id;
        }
    }
}
