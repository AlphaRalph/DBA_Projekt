using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Context;
using System.Text.RegularExpressions;


namespace DBA_Projekt
{
    public partial class OR_Mapper_Window : Form
    {
        Context.DataContext dbCon;
        List<Termin> Termine;
        List<Raum> Rooms;
        List<Lektor> Teachers;
        List<Studiengang> Studyprograms;
        public OR_Mapper_Window(List<Termin> termine, List<Raum> rooms, List<Lektor> teachers, List<Studiengang> studyprogram)
        {
            InitializeComponent();

            Termine = termine;
            Rooms = rooms;
            Teachers = teachers;
            Studyprograms = studyprogram;

            dbCon = new DataContext();
            dbCon.SubmitChanges();
            refreshAll();
            
            var query = from appointment in dbCon.GetTable<Appointment>()
                        select appointment;

            if (query.ToList().Count == 0) { button1.Enabled = true; }
            else { button1.Enabled = false; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dbCon = InsertRooms(Rooms, dbCon);
                dbCon = InsertStudyprograms(Studyprograms, dbCon);
                dbCon = InsertTeachers(Teachers, dbCon);
                //dbCon.SubmitChanges();
                dbCon = InsertAppointsments(Termine, dbCon);
                dbCon.SubmitChanges();
                refreshAll();

                button1.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static DataContext InsertRooms(List<Raum> rooms, DataContext dbCon)
        {
            foreach (var room in rooms)
            {
                // Umschreiben der Daten eig. nicht nötig, da direkt die eigens implementierte Klasse verwendet werden könnte
                // Funktion wird jedoch gezeigt, da diese normalerweise nicht benötigt werden
                Room r = new Room();
                r.ID = room.Id;
                r.Building = room.Building;
                r.Type = room.Type;
                r.RoomName = room.RoomName.Replace("™", " "); //Löschen des Trademarks, da dieses Probleme bereitet

                dbCon.Rooms.InsertOnSubmit(r);

            }
            return dbCon;
        }

        private static DataContext InsertStudyprograms(List<Studiengang> studyprograms, DataContext dbCon)
        {
            foreach (var studyprogram in studyprograms)
            {
                // Umschreiben der Daten eig. nicht nötig, da direkt die eigens implementierte Klasse verwendet werden könnte
                // Funktion wird jedoch gezeigt, da diese normalerweise nicht benötigt werden
                Studyprogram s = new Studyprogram();
                s.ID = studyprogram.Id;
                s.ProgramName = studyprogram.Name;
                s.ProgramNumber = studyprogram.Nummer;
                s.ProgramGraduate = studyprogram.Titel;
                s.ProgramType = studyprogram.Organisationsform;

                dbCon.Studyprograms.InsertOnSubmit(s);

            }
            return dbCon;
        }

        private static DataContext InsertTeachers(List<Lektor> teachers, DataContext dbCon)
        {
            foreach (var teacher in teachers)
            {
                // Umschreiben der Daten eig. nicht nötig, da direkt die eigens implementierte Klasse verwendet werden könnte
                // Funktion wird jedoch gezeigt, da diese normalerweise nicht benötigt werden
                Teacher t = new Teacher();
                t.ID = teacher.Id;
                t.FirstName = Regex.Replace(teacher.FirstName, @"[^0-9a-zA-Z .;.,_-]", string.Empty);
                t.LastName = Regex.Replace(teacher.LastName, @"[^0-9a-zA-Z .;.,_-]", string.Empty);


                dbCon.Teachers.InsertOnSubmit(t);

            }
            return dbCon;
        }

        private DataContext InsertAppointsments(List<Termin> appointments, DataContext dbCon)
        {
            foreach (var appointment in appointments)
            {
                // Umschreiben der Daten eig. nicht nötig, da direkt die eigens implementierte Klasse verwendet werden könnte
                // Funktion wird jedoch gezeigt, da diese normalerweise nicht benötigt werden
                Appointment a = new Appointment();
                a.ID = appointment.Id;
                a.SemsterNumber = appointment.SemesterNummer;
                a.SemesterName = Regex.Replace(appointment.SemesterName, @"[^0-9a-zA-Z .;.,_-]", string.Empty);
                a.Beginning = appointment.Beginn;
                a.Ending = appointment.Ende;
                a.Type = Regex.Replace(appointment.Typ, @"[^0-9a-zA-Z .;.,_-]", string.Empty);
                a.Identifikation = Regex.Replace(appointment.Identifikation, @"[^0-9a-zA-Z .;.,_-]", string.Empty);

                var teacherquery = from teacher in dbCon.GetTable<Teacher>()
                                   where teacher.ID == appointment.Lektor.Id
                                   select teacher;

                var foundteacher = teacherquery.ToList();
                foreach (var teacher in foundteacher)
                {
                    a.Teacher = teacher;
                }
                a.TeacherID = appointment.Lektor.Id;

                var roomquery = from room in dbCon.GetTable<Room>()
                                   where room.ID == appointment.Raum.Id
                                   select room;

                var foundroom = roomquery.ToList();
                foreach (var room in foundroom)
                {
                    a.Room = room;
                }
                a.RoomID = appointment.Raum.Id;

                var studyprogramquery = from studyprogram in dbCon.GetTable<Studyprogram>()
                                where studyprogram.ID == appointment.Studiengang.Id
                                select studyprogram;

                var foundstudyprogram = studyprogramquery.ToList();
                foreach (var studyprogram in foundstudyprogram)
                {
                    a.Studyprogram = studyprogram;
                }
                a.StudyprogramID = appointment.Studiengang.Id;

                dbCon.Appointments.InsertOnSubmit(a);

            }
            return dbCon;
        }

        private void refreshAll()
        {
            var query = from Appointment in dbCon.GetTable<Appointment>()
                        select Appointment;

            dataGridView1.DataSource = query;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dbCon.SubmitChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            refreshAll();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var query = from appointment in dbCon.GetTable<Appointment>()
                        where appointment.Identifikation.StartsWith(textBox1.Text)
                        select appointment;

            dataGridView1.DataSource = query;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = dataGridView1.RowCount;
            int value = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            if (e.ColumnIndex >= 7 && e.RowIndex + 1 < i)
            {

                Second form = new Second(value, e.ColumnIndex);
                form.Show();
            }
        }
    }
}
