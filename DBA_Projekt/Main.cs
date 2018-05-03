﻿using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using DBA_Projekt.SQL;
using System.Data;

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

        //public Main()
        //{
        //    MySqlConnection conn = new MySqlConnection("SERVER=192.168.142.128;" + "DATABASE=fhooe;" + "UID=fhooe" + "PASSWORD=1234;");
        //    conn.Open();
        //    InitializeComponent();
        //}

        #region constructor
        public Main() => InitializeComponent();
        #endregion


        //DataTable table = new DataTable();
        //myDataAdapter.Fill(table);
        //BindingSource sourc = new BindeingSource();
        //sourc.DataSource = table;
        //dataGridView.DataSource = bindingSource;






        #region events
        private void button1_Click(object sender, System.EventArgs e)
        {
            // Establish DB communication (once per Program)
            sqlComunicator fhooeComunicator = new sqlComunicator("192.168.142.128", "fhooe", "fhooe", "bitnami1");
            
            // Load LVA List from File
            CsvHelper.ReadCsv("../../LVA.csv", 1, out var appointments, out var programs, out var rooms, out var teachers);

            // Upload all teachers, rooms, studyPrograms, 
            foreach (var teacher in teachers)
            {
                if (teacher.FirstName == "" || teacher.LastName == "") continue;
                fhooeComunicator.Insert("teacher", new string[] { "firstName", "lastName" }, new string[] { teacher.FirstName, teacher.LastName });
            }
            foreach (var room in rooms)
            {
                fhooeComunicator.Insert("room", new string[] { "building", "type", "roomName" }, new string[] { room.Building, room.Type, room.RoomName });
            }
            foreach (var program in programs)
            {
                if (program.ProgramGraduate == "" || program.ProgramGraduate== null || program.ProgramName == "" || program.ProgramNumber.ToString() == "" || program.ProgramType == "") continue;
                fhooeComunicator.Insert("studyprogram", new string[] { "programName", "programNumber", "programGraduate", "programType" }, new string[] { program.ProgramName, program.ProgramNumber.ToString(), program.ProgramGraduate, program.ProgramType });
            }
            foreach(var appointment in appointments)
            {
                if (string.IsNullOrWhiteSpace(appointment.Identification)||string.IsNullOrWhiteSpace(appointment.SemesterName)|| string.IsNullOrWhiteSpace(appointment.Type)) continue;
                string[] columns = new string[] { "semesterNumber", "semesterName", "beginning", "ending", "type", "identification", "teacher", "room", "studyProgram" };

                if (appointment.Teachers == null || appointment.Teachers.Length < 1) continue;
                string teacherID = fhooeComunicator.executeSqlQuery("SELECT ID FROM teacher WHERE " + sqlComunicator.MakeConditions(new string[] { "firstName", "lastName" }, new string[] { appointment.Teachers[0].FirstName, appointment.Teachers[0].LastName }, "AND"));

                if (appointment.Rooms == null || appointment.Rooms.Length < 1) continue;
                string roomID = fhooeComunicator.executeSqlQuery("SELECT ID FROM room WHERE " + sqlComunicator.MakeConditions(new string[] { "building", "type", "roomName" }, new string[] { appointment.Rooms[0].Building, appointment.Rooms[0].RoomName, appointment.Rooms[0].Type }, "AND"));

                string[] values = new string[] {appointment.SemesterNumber.ToString(),
                                                appointment.SemesterName,
                                                appointment.Beginning.ToString(),
                                                appointment.Ending.ToString(),
                                                appointment.Type,
                                                appointment.Identification,
                                                teacherID,
                                                roomID};

                fhooeComunicator.Insert("appointment",columns , values);
            }


            DataSet set = fhooeComunicator.Get("teacher", new string[] { "firstName", "lastName" }, new string[] { "Franz", "Auinger" });


            sqlComunicator com = new sqlComunicator("192.168.142.128", "fhooe", "fhooe", "bitnami1");
            string query = com.executeSqlQuery("SELECT * FROM person");
            com.Insert("person", new string[] { "Vorname, Nachname, SVNR" }, new string[] { "Albert", "Hofer", "9723" });
            com.TryEdit("person", new string[] { "Vorname", "Nachname" }, new string[] { "Albert", "Hofer" }, new string[] { "Kunibert", "Hofer" });
            com.TryRemove("person", new string[] { "Vorname", "Nachname"}, new string[] { "Kunibert", "Hofer"});
            
        }
        #endregion
    }
}