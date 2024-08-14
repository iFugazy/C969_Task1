using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Task1.Models
{
    public class DatabaseConnection
    {
        public string connstring = "datasource=127.0.0.1; port=3306; Username=root; Password=Giants12!";
        //public string connstring = "server=localhost; user=sqlUser; pwd=Passw0rd!; Database=client_schedule";

        public MySqlConnection GetConnection()
        {
            MySqlConnection cnn = new MySqlConnection(connstring);
            //MySqlConnection conn = new MySqlConnection(connstring)

            return cnn;
        }

        public void OpenConnection()
        {
            MySqlConnection conn = GetConnection();
            conn.Open();
        }

        public void CloseConnection()
        {
            MySqlConnection conn = GetConnection();
            conn.Close();
        }

        public void DBCommand(string query)
        {
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}
