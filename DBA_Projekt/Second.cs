using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBA_Projekt
{
    public partial class Second : Form
    {
        private static string myConnectionString;
        private static string sqlcmd;
        private static MySqlConnection connection;
        private static MySqlDataAdapter myda;
        private static BindingSource bindingSource;

        
        public Second(int value, int column)
        {
            InitializeComponent();
            string slcTable = ChooseTable(column);
            label1.Text = "Data of the " + slcTable + " with the searched ID:";

            myConnectionString = "SERVER=192.168.43.128;" + "DATABASE=lva_liste;" + "UID=fhooe;" + "PASSWORD=1234;";
            connection = new MySqlConnection(myConnectionString);
            myda = new MySqlDataAdapter();

            


            sqlcmd = "SELECT * FROM "+ slcTable + " WHERE ID = " + value;
            bindingSource = new BindingSource();
            connection.Open();

            myda.SelectCommand = new MySqlCommand(sqlcmd, connection);

            DataTable table = new DataTable();
            myda.Fill(table);


            bindingSource.DataSource = table;

            dataGridView1.DataSource = bindingSource;
            

        }
        public static string ChooseTable(int column)
        {
            if (column == 7) { return "teacher"; }
            else if (column == 8) { return "room"; }
            else if (column == 9) { return "studyprogram"; }
            else return "";
        }
    }
    
}
