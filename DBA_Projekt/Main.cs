using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DBA_Projekt
{
    /// <summary>
    /// Credentials for vmware 
    ///     - name: bitnami
    ///     - login: bitnami1
    /// Credentials for phpmyadmin
    ///     - name: fhooe
    ///     - login: bitnami1
    /// </summary>
    public partial class Main : Form
    {
        private static string myConnectionString;
        private static string sqlcmd;
        private static MySqlConnection connection;
        private static MySqlDataAdapter myda;
        private static BindingSource bindingSource;
        public List<Termin> termine = new List<Termin>();
        public List<Raum> rooms = new List<Raum>();
        public List<Lektor> teachers = new List<Lektor>();
        public List<Studiengang> studyprogramms = new List<Studiengang>();
        public Main()
        {
            InitializeComponent();
            //csv mit Daten Einlesen
            string pfad = @"C:\Users\Alexander\Documents\GitHub\DBA_Projekt\DBA_Projekt\LVA_Liste_veröffentlicht.csv";
            CsvTermineEinlesen(pfad);

            
            myConnectionString = "SERVER=192.168.43.128;" + "DATABASE=lva_liste;" + "UID=fhooe;" + "PASSWORD=1234;";

            connection = new MySqlConnection(myConnectionString);
            myda = new MySqlDataAdapter();
            sqlcmd = "SELECT * FROM Appointment";
            bindingSource = new BindingSource();

            connection.Open();

            // Überprüfung ob sich Daten in der DB befinden
            string cmd = "SELECT * FROM Appointment WHERE ID != '' ";
            MySqlCommand cmdIsEmpty = new MySqlCommand(cmd, connection);
            
            int j = cmdIsEmpty.ExecuteNonQuery();
            if (j == 0) { btnReadcsv.Enabled = false; }

            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {

                myda.SelectCommand = new MySqlCommand(sqlcmd, connection);
                //var reader = myda.SelectCommand.ExecuteReader();
                //while (reader.Read())
                //{
                //    string firstname = reader.GetString("firstname");
                //}
                DataTable table = new DataTable();
                myda.Fill(table);


                bindingSource.DataSource = table;
                
                dataGridView1.DataSource = bindingSource;
                string i = dataGridView1.RowCount.ToString();
                //connection.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnUpdateDatabase_Click(object sender, EventArgs e)
        {
            /*
       try
       {

           string insertcmd = "INSERT INTO Person (PersonID,Nachname, Vorname,SVNummer) VALUES (@PersonID,@Nachname, @Vorname,@SVNummer)";
           MySqlCommand cmd = new MySqlCommand(insertcmd, connection);
           cmd.Parameters.AddWithValue("@PersonID", dataGridView1.Rows[1].Cells[0].Value);
           cmd.Parameters.AddWithValue("@Nachname", dataGridView1.Rows[1].Cells[1].Value);
           cmd.Parameters.AddWithValue("@Vorname", dataGridView1.Rows[1].Cells[2].Value);
           cmd.Parameters.AddWithValue("@SVNummer", dataGridView1.Rows[1].Cells[3].Value);


           myda.InsertCommand = cmd;
           myda.Update((DataTable)bindingSource.DataSource);

       }
       catch (Exception ex)
       {
           MessageBox.Show(ex.ToString());
       }
       */


        }
        private void btnReadcsv_Click(object sender, EventArgs e)
        {

                try
                {
                    InsertRooms(rooms);
                    InsertTeacher(teachers);
                    InsertStudyprograms(studyprogramms);
                    InsertAppointments(termine);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            
        }

        private void BtnDeleteDataFromDB_Click(object sender, EventArgs e)
        {
            try
            {
                string insertcmdAp = "DELETE FROM `appointment`";
                MySqlCommand cmdAp = new MySqlCommand(insertcmdAp, connection);
                cmdAp.ExecuteNonQuery();

                string insertcmdRoom = "DELETE FROM `room`";
                MySqlCommand cmdRoom = new MySqlCommand(insertcmdRoom, connection);
                cmdRoom.ExecuteNonQuery();

                string insertcmdTe = "DELETE FROM `teacher`";
                MySqlCommand cmdTe = new MySqlCommand(insertcmdTe, connection);
                cmdTe.ExecuteNonQuery();

                string insertcmdProg = "DELETE FROM `studyprogram`";
                MySqlCommand cmdProg = new MySqlCommand(insertcmdProg, connection);
                cmdProg.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void CsvTermineEinlesen(string pfad)
        {

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
                    if ( CheckExStudyprogram(studyprogramms, studiengang) == null) { studyprogramms.Add(studiengang); } //überprüft, ob sich der Studiengang bereits in der Liste befindet
                    else { studiengang = CheckExStudyprogram(studyprogramms, studiengang); }

                    // Raum für Termin erstellen
                    elementeTest = elemente[10].Split('|');
                    Raum room = new Raum(elemente[11], elementeTest[1].Split('-')[0].Trim(), elementeTest[1].Split('-')[1].Trim());
                    if (CheckExRoom(rooms, room) == null) { rooms.Add(room); } //überprüft, ob sich der Raum bereits in der Liste befindet
                    else { room = CheckExRoom(rooms, room); }

                    // Lektor für Termin ertellen
                    elementeTest = elemente[13].Split(' ');
                    Lektor lektor = new Lektor(elementeTest[0], elementeTest[1]);
                    if(CheckExTeacher(teachers, lektor) == null) { teachers.Add(lektor); } // Überprüft, ob sich der Lektor bereits in der Liste befindet
                    else { lektor = CheckExTeacher(teachers, lektor); }

                    // Zeitdaten für Termin erstellen
                    DateTime beginn = DateTime.Parse(elemente[7].Trim());
                    DateTime ende = DateTime.Parse(elemente[8].Trim());
                    DateTime datum = DateTime.Parse(elemente[6].Trim());
                    beginn = new DateTime(datum.Year, datum.Month, datum.Day, beginn.Hour, beginn.Minute, 0);
                    ende = new DateTime(datum.Year, datum.Month, datum.Day, ende.Hour, ende.Minute, 0);
                    Termin appointment = new Termin(int.Parse(elemente[4]), elemente[3], beginn, ende,
                        elemente[15], elemente[12], lektor, room, studiengang);

                    // Termin hinzufügen
                    termine.Add(appointment);
                    
                }
                catch
                {
                    // normalerweise wäre hier ein Fehler zu werfen, in diesem Fall werden Probleme einfach still übergangen              
                }
            }

        }

        public static Studiengang CheckExStudyprogram(List<Studiengang> list, Studiengang objekt)
        {
            foreach (var item in list)
            {
                if (item.ToString().Equals(objekt.ToString()))
                {
                    objekt.Id = item.Id;
                    return objekt;
                }
            }
            return null;
        }

        public static Raum CheckExRoom(List<Raum> list, Raum objekt)
        {
            foreach (var item in list)
            {
                if (item.ToString().Equals(objekt.ToString()))
                {
                    objekt.Id = item.Id;
                    return objekt;
                }
            }
            return null;
        }

        public static Lektor CheckExTeacher(List<Lektor> list, Lektor objekt)
        {
            foreach (var item in list)
            {
                if (item.ToString().Equals(objekt.ToString()))
                {
                    objekt.Id = item.Id;
                    return objekt;
                }
            }
            return null;
        }

        public static void InsertStudyprograms(List<Studiengang> programs)
        {
            foreach (var program in programs)
            {
                string insertcmdProg = "INSERT INTO studyprogram (programName,programNumber,programGraduate,programType,ID) VALUES (@programName,@programNumber,@programGraduate,@programType,@ID)";
                MySqlCommand cmdProg = new MySqlCommand(insertcmdProg, connection);
                cmdProg.Parameters.AddWithValue("@programName", program.Name);
                cmdProg.Parameters.AddWithValue("@programNumber", program.Nummer);
                cmdProg.Parameters.AddWithValue("@programGraduate", program.Organisationsform);
                cmdProg.Parameters.AddWithValue("@programType", program.Titel);
                cmdProg.Parameters.AddWithValue("@ID", program.Id);
                cmdProg.ExecuteNonQuery();
            }
        }

        public static void InsertRooms(List<Raum> rooms)
        {
            foreach (var room in rooms)
            {
                string insertcmdRoom = "INSERT INTO room (building,type,roomName,ID) VALUES (@building,@type,@roomName,@ID)";
                MySqlCommand cmdRoom = new MySqlCommand(insertcmdRoom, connection);
                cmdRoom.Parameters.AddWithValue("@building", room.Building);
                cmdRoom.Parameters.AddWithValue("@type", room.Type);
                cmdRoom.Parameters.AddWithValue("@roomName", room.RoomName);
                cmdRoom.Parameters.AddWithValue("@ID", room.Id);
                cmdRoom.ExecuteNonQuery();
            }
        }

        public static void InsertTeacher(List<Lektor> teachers)
        {
            foreach (var teacher in teachers)
            {
                string insertcmdTe = "INSERT INTO teacher (firstName,lastName,ID) VALUES (@firstName,@lastName,@ID)";
                MySqlCommand cmdTe = new MySqlCommand(insertcmdTe, connection);
                cmdTe.Parameters.AddWithValue("@firstName", teacher.FirstName);
                cmdTe.Parameters.AddWithValue("@lastName", teacher.LastName);
                cmdTe.Parameters.AddWithValue("@ID", teacher.Id);
                cmdTe.ExecuteNonQuery();
            }
        }

        public static void InsertAppointments(List<Termin> appointments)
        {

            foreach (var appointment in appointments)
            {
                string insertcmdAp = "INSERT INTO Appointment (ID,semesterNumber,semesterName,beginning,ending,type,identifikation,teacher,room,studyprogram) VALUES (@ID,@semesterNumber,@semesterName,@beginning,@ending,@type,@identifikation,@teacher,@room,@studyprogram)";
                MySqlCommand cmdAp = new MySqlCommand(insertcmdAp, connection);
                cmdAp.Parameters.AddWithValue("@ID", appointment.Id);
                cmdAp.Parameters.AddWithValue("@semesterNumber", appointment.SemesterNummer);
                cmdAp.Parameters.AddWithValue("@semesterName", appointment.SemesterName);
                cmdAp.Parameters.AddWithValue("@beginning", appointment.Beginn);
                cmdAp.Parameters.AddWithValue("@ending", appointment.Ende);
                cmdAp.Parameters.AddWithValue("@type", appointment.Typ);
                cmdAp.Parameters.AddWithValue("@identifikation", appointment.Identifikation);
                cmdAp.Parameters.AddWithValue("@teacher", appointment.Lektor.Id);
                cmdAp.Parameters.AddWithValue("@room", appointment.Raum.Id);
                cmdAp.Parameters.AddWithValue("@studyprogram", appointment.Studiengang.Id);
                cmdAp.ExecuteNonQuery();
            }
        }

        
    }
}
