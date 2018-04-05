using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
    }
}