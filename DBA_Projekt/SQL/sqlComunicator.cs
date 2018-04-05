using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DBA_Projekt.SQL
{
    class sqlComunicator
    {
        private MySqlConnection connection;

        public sqlComunicator(string serverIPAddress,string database, string uid, string password)
        {
            EstablishConnection(serverIPAddress, database, uid, password);
        }

        public void EstablishConnection(string address, string database, string uid, string password)
        {
            string myConnectionString = "SERVER="+address+";" + "DATABASE="+database+";" + "UID="+uid+";" + "PASSWORD="+password+";";
            connection = new MySqlConnection(myConnectionString);
        }

        public void executeSqlQuery(string sqlCommand)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = sqlCommand;

            MySqlDataReader Reader;
            Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                string row = "";
                for (int i = 0; i < Reader.FieldCount; i++)
                {
                    row += Reader.GetValue(i).ToString() + ", ";
                }
                connection.Close();
            }
        }

        public void Insert(string intoTable, string intoColumn, string value)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO " + intoTable + " (" + intoColumn + ") VALUES ('" + value + "')";   //"INSERT INTO Person (Vorname) VALUES ('tom')"; 
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public DataSet Get()
        {
            //DataTable table = new DataTable();
            //myDataAdapter.Fill(table);
            //BindingSource sourc = new BindingSource();
            //sourc.DataSource = table;
            //dataGridView.DataSource = bindingSource;

            MySqlCommand command = connection.CreateCommand();
            DataSet set = new DataSet();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command.CommandText, connection);
            dataAdapter.Fill(set);
            return set;
        }
    }
}
