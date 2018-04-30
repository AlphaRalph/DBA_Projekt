using System.Data.SqlClient;
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
            sqlComunicator fhooeComunicator = new sqlComunicator("192.168.142.128", "fhooe", "fhooe", "bitnami1");
            CsvHelper.ReadCsv("../../LVA.csv", 1, out var appointments, out var programs, out var rooms, out var teachers);

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