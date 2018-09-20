using MySql.Data.MySqlClient;
using System;
using System.Data;
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
        public Main()
        {
            InitializeComponent();

            myConnectionString = "SERVER=192.168.43.128;" + "DATABASE=fhooe;" + "UID=fhooe;" + "PASSWORD=1234;";

            connection = new MySqlConnection(myConnectionString);
            myda = new MySqlDataAdapter();
            sqlcmd = "SELECT * FROM Person";
            bindingSource = new BindingSource();

            connection.Open();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {

                myda.SelectCommand = new MySqlCommand(sqlcmd, connection);

                DataTable table = new DataTable();
                myda.Fill(table);


                bindingSource.DataSource = table;

                dataGridView1.DataSource = bindingSource;

                //connection.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnUpdateDatabase_Click(object sender, EventArgs e)
        {
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

        }
    }
}
