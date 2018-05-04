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
            string myConnectionString = "SERVER="+address+";" + "DATABASE="+database+";" + "UID="+uid+";" + "PASSWORD="+password;
            connection = new MySqlConnection(myConnectionString);
        }

        public string executeSqlQuery(string sqlCommand)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = sqlCommand;

            MySqlDataReader Reader;
            Reader = command.ExecuteReader();
            string output = string.Empty;
            while (Reader.Read())
            {
                string row = "";
                for (int i = 0; i < Reader.FieldCount; i++)
                {
                    row += Reader.GetValue(i).ToString() + ", ";
                }
                output += row + "\r\n";
            }
            connection.Close();
            if(output.Length > 4) return output.Substring(0, output.Length - 4);
            return "";
        }

        public void Insert(string intoTable, string[] columns, string[] values)
        {
            MySqlCommand command = connection.CreateCommand();
            string insertString = string.Empty;
            string targetColumns = string.Empty;
            for (int i = 0; i < columns.Length; i++)
            {
                if (ReferenceEquals(values[i], null) || values[i] == "") continue;
                targetColumns += columns[i] + ",";
            }
            foreach (var item in values)
            {
                if (ReferenceEquals(item, null) || item == "") continue;
                insertString += "'" + item.Replace("'", "") + "',";
            }
            connection.Open();
            MySqlCommand selectCommand = connection.CreateCommand();
            selectCommand.CommandText = "SELECT " + targetColumns.Substring(0,targetColumns.Length-1) + " FROM " + intoTable + " WHERE " + MakeConditions(columns, values, "AND");

            MySqlDataReader Reader;
            Reader = selectCommand.ExecuteReader();

            if (!Reader.HasRows)
            {
                Reader.Close();
                command.CommandText = "INSERT INTO " + intoTable + " ( " + targetColumns.Substring(0, targetColumns.Length - 1) + " )" + " VALUES ( " + insertString.Substring(0, insertString.Length - 1) + " );";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public DataSet Get(string table, string[] lookForColumns, string[] lookForAttributes)
        {
            //DataTable table = new DataTable();
            //myDataAdapter.Fill(table);
            //BindingSource sourc = new BindingSource();
            //sourc.DataSource = table;
            //dataGridView.DataSource = bindingSource;

            MySqlCommand command = connection.CreateCommand();
            DataSet set = new DataSet();
            string targetColumns = string.Empty;
            for (int i = 0; i < lookForColumns.Length; i++)
            {
                if (ReferenceEquals(lookForAttributes[i], null) || lookForAttributes[i] == "") continue;
                targetColumns += lookForColumns[i] + ",";
            }
            command.CommandText = "SELECT " + targetColumns.Substring(0, targetColumns.Length - 1) + " FROM " + table + " WHERE " + MakeConditions(lookForColumns, lookForAttributes, "AND");
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command.CommandText, connection);
            dataAdapter.Fill(set);
            return set;
        }

        public bool TryRemove(string table, string[] lookForCloumns, string[] lookForAttributes)
        {
            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM " + table + " WHERE " + MakeConditions(lookForCloumns, lookForAttributes, "AND") + ";";
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool TryEdit(string table, string[] editColumns, string[] oldValues, string[] newValues)
        {
            try
            {
                MySqlCommand command = connection.CreateCommand();
                string setValues = string.Empty;
                for (int i = 0; i < editColumns.Length; i++)
                {
                    setValues += editColumns[i] + " = '" + newValues[i] + "' ,";
                }
                command.CommandText = "UPDATE " + table + " SET " + setValues.Substring(0,setValues.Length-1) + " WHERE " + MakeConditions(editColumns, oldValues, "AND") + ";";
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public static string MakeConditions(string[] lookForCloumns, string[] lookForAttributes, string connectionWord)
        {
            string conditions = string.Empty;
            for (int i = 0; i < lookForCloumns.Length; i++)
            {
                if (!ReferenceEquals(lookForAttributes[i], null))
                {
                    conditions += lookForCloumns[i] + " = '" + lookForAttributes[i].Replace("'", "") + "' ";
                    if (i < lookForCloumns.Length - 1) conditions += connectionWord + " ";
                }
            }
            return conditions;
        }
    }
}
