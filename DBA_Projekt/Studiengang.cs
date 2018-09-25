using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBA_Projekt
{
    public class Studiengang
    {
        private static int id = 100;
        public string Name { get; }
        public int Nummer { get; }
        public string Titel { get; }
        public string Organisationsform { get; }
        public int Id { get; set; }

        public Studiengang(string name, int nummer, string titel, string organisationsform)
        {
            Name = name;
            Nummer = nummer;
            Titel = titel;
            Organisationsform = organisationsform;
            Id = ++id;
        }

        public override string ToString()
        {
            return Name + ", " + Nummer + ", " + Titel + ", " + Organisationsform;
        }

    }
}
