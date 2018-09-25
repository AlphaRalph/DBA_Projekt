using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBA_Projekt
{
    public class Termin
    {
        private static int id = 100;
        public int SemesterNummer { get; }

        public string SemesterName { get; }

        public DateTime Beginn { get; }

        public DateTime Ende { get; }

        public string Typ { get; }

        public string Identifikation { get; }

        public Lektor Lektor { get; }

        public Raum Raum { get; }

        public Studiengang Studiengang { get; }
        public int Id { get; set; }

        public Termin(int semesterNummer, string semesterName, DateTime beginn, DateTime ende, string typ, 
            string identifikation, Lektor lektor, Raum raum, Studiengang studiengang)
        {

            SemesterNummer = semesterNummer;
            SemesterName = semesterName;
            Beginn = beginn;
            Ende = ende;
            Typ = typ;
            Identifikation = identifikation;
            Lektor = lektor;
            Raum = raum;
            Studiengang = studiengang;
            Id = ++id;
            
        }

        public override string ToString()
        {
            return "Semesternummer: " + SemesterNummer +
                "Semestername: " + SemesterName +
                "Beginn: " + Beginn +
                "Ende: " + Ende +
                "Typ: " + Typ +
                "Identifikation: " + Identifikation +
                "Lektor: " + Lektor +
                "Raum: " + Raum +
                "Studiengang: " + Studiengang;
        }
    }
}
