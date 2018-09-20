using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBA_Projekt
{
    public class Termin
    {
        public int SemesterNummer { get; }

        public string SemesterName { get; }

        public DateTime Beginn { get; }

        public DateTime Ende { get; }

        public string Typ { get; }

        public string Identifikation { get; }

        public Lektor Lektor { get; }

        public Raum Raum { get; }

        public Studiengang Studiengang { get; }

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
            
        }

        public override string ToString()
        {
            return "Semesternummer: " + SemesterNummer + "\n" +
                "Semestername: " + SemesterName + "\n" +
                "Beginn: " + Beginn + "\n" +
                "Ende: " + Ende + "\n" +
                "Typ: " + Typ + "\n" +
                "Identifikation: " + Identifikation + "\n" +
                "Lektor: " + Lektor + "\n" +
                "Raum: " + Raum + "\n" +
                "Studiengang: " + Studiengang + "\r\n";
        }
    }
}
