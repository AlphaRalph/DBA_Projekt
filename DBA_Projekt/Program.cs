using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBA_Projekt
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());

            List<Termin> termine = new List<Termin>();
            string pfad = @"C:\Users\Alexander\Documents\GitHub\DBA_Projekt\DBA_Projekt\LVA_Liste_veröffentlicht.csv";
            termine = CsvTermineEinlesen(pfad);
        }

        public static List<Termin> CsvTermineEinlesen(string pfad)
        {
            List<Termin> termine = new List<Termin>();

            StreamReader reader = new StreamReader(pfad, Encoding.Default);

            // Ersten 4 Zeilen überspringen
            reader.ReadLine();
            reader.ReadLine();
            reader.ReadLine();
            reader.ReadLine();
            while (reader.Peek() != -1)
            {
                string line = reader.ReadLine();
                if (line == ";;;;;;;;;;;;;;;;") continue;   //Leerzeile

                //Studiengang;Organisationsform;Zweig;Semester;SemesterNr.;KW;Datum;Von;Bis;Einheiten;Raum;Bauteil;LVA;Lektor;Zuhörer;Typ                                                                
                //     0             1             2      3         4       5   6    7   8      9      10    11    12    13     14     15

                try     //aufspaltern der zeile und aufteilen in Properties eines Termins
                {
                    string[] elemente = line.Split(';');

                    // Überspringen falls ein Eintrag nicht vorhanden ist
                    if (elemente[13] == "" ||           //falls kein Lektor eingetragen ist, hinzufügen überspringen
                        elemente[0] == "" ||            //falls kein Studiengang eingetragen ist, hinzufügen überspringen
                        elemente[1] == "" ||            //falls keine Organisationsform eingetragen ist, hinzufügen überspringen
                        elemente[2] == "" ||            //falls kein Zweig eingetragen ist, hinzufügen überspringen
                        elemente[3] == "" ||            //falls kein Semester eingetragen ist, hinzufügen überspringen
                        elemente[4] == "" ||            //falls keine Semesternummer eingetragen ist, hinzufügen überspringen
                        elemente[6] == "" ||            //falls kein Datum eingetragen ist, hinzufügen überspringen
                        elemente[7] == "" ||            //falls kein "Von" eingetragen ist, hinzufügen überspringen
                        elemente[8] == "" ||            //falls kein "Bis" eingetragen ist, hinzufügen überspringen
                        elemente[10] == "" ||           //falls kein Raum eingetragen ist, hinzufügen überspringen
                        elemente[11] == "" ||           //falls kein Bauteil eingetragen ist, hinzufügen überspringen
                        elemente[12] == "" ||           //falls keine Identifikation eingetragen ist, hinzufügen überspringen
                        elemente[15] == "") { continue; }   //falls kein Typ eingetragen ist, hinzufügen überspringen

                    // Studiengang für Termin erstellen
                    string[] elementeSG = elemente[0].Split('.');
                    string[] elementeTest = elementeSG[1].Split('(');
                    elementeTest[1] = elementeTest[1].Substring(0, elementeTest[1].Length - 1);
                    Studiengang studiengang = new Studiengang(elementeSG[0].Trim(), int.Parse(elementeTest[1]), elementeTest[0].Trim(), elemente[1].Trim());

                    // Raum für Termin erstellen
                    elementeTest = elemente[10].Split('|');
                    Raum room = new Raum(elemente[11], elementeTest[1].Split('-')[0].Trim(), elementeTest[1].Split('-')[1].Trim());

                    // Lektor für Termin ertellen
                    elementeTest = elemente[13].Split(' ');
                    Lektor lektor = new Lektor(elementeTest[0], elementeTest[1]);

                    // Zeitdaten für Termin erstellen
                    DateTime beginn = DateTime.Parse(elemente[7].Trim());
                    DateTime ende = DateTime.Parse(elemente[8].Trim());
                    DateTime datum = DateTime.Parse(elemente[6].Trim());
                    beginn = new DateTime(datum.Year, datum.Month, datum.Day, beginn.Hour, beginn.Minute, 0);
                    ende = new DateTime(datum.Year, datum.Month, datum.Day, ende.Hour, ende.Minute, 0);

                    // Termin hinzufügen
                    termine.Add(new Termin(int.Parse(elemente[4]), elemente[3], beginn, ende,
                        elemente[15], elemente[12], lektor, room, studiengang));
                }
                catch
                {
                    // normalerweise wäre hier ein Fehler zu werfen, in diesem Fall werden Probleme einfach still übergangen              
                }
            }
            return termine;


        }
    }
}
