using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace C969_Task1.Models
{
    public class SqlConnection
    {
        public string connstring;
        public MySqlConnection cnn;
        public SqlConnection() 
        {            

            connstring = @"server=127.0.0.1; database=client_schedule; userid=sqlUser; password=Passw0rd!";
            cnn = new MySqlConnection(connstring);
        }
    }
}
