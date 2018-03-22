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

        public sqlComunicator()
        {

        }

        public void EstablishConnection()
        {
            string myConnectionString = "SERVER=127.0.0.1;" + "DATABASE= fhooe;" + "UID=fhooe;" + "PASSWORD=1234;";

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
            MySqlCommand command = connection.CreateCommand();
            DataSet set = new DataSet();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command.CommandText, connection);
            dataAdapter.Fill(set);
            return set;
        }

    }
}
