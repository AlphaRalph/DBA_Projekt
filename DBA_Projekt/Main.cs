using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using DBA_Projekt.SQL;

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
            //CsvHelper.ReadCsv("../../LVA.csv", 1, out var appointments, out var programs, out var rooms, out var teachers);
            sqlComunicator com = new sqlComunicator("192.168.142.128", "fhooe", "fhooe", "bitnami1");
            com.executeSqlQuery("");
        }
        #endregion
    }
}