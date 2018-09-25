using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBA_Projekt
{
    public class Lektor
    {
        private static int id = 100;
        public string FirstName { get; }
        public string LastName { get; }
        public int Id { get; set; }

        public Lektor(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = ++id;    
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
