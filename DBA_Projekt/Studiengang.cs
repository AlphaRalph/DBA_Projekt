using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBA_Projekt
{
    public class Studiengang
    {
        public string Name { get; }
        public int Nummer { get; }
        public string Titel { get; }
        public string Organisationsform { get; }

        public Studiengang(string name, int nummer, string titel, string organisationsform)
        {
            Name = name;
            Nummer = nummer;
            Titel = titel;
            Organisationsform = organisationsform;
        }

        public override string ToString()
        {
            return Name + ", " + Nummer + ", " + Titel + ", " + Organisationsform;
        }

    }
}
