using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Task1.Models
{
    public class DatabaseConnection
    {
        //public string connstring = "datasource=127.0.0.1; port=3306; Username=root; Password=Giants12!";
        public string connstring = "server=localhost; user=sqlUser; pwd=Passw0rd!; Database=client_schedule";

        public string mainTableString = "SELECT customer.customerID as \"Customer ID\",\r\ncustomer.customerName as \"Customer Name\", \r\naddress.address as \"Address\",\r\naddress.PostalCode as \"Postal Code\",\r\naddress.Phone as \"Phone Number\"\r\n\r\nFROM client_schedule.address, client_schedule.customer\r\n\r\nWhere customer.addressId = address.addressId;";


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

        public MySqlCommand DBCommand(string query)
        {
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();
            

            return command;
        }

        public void RefreshData(string dataQuery, DataGridView dataGridView)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(dataQuery, connstring);
            DataSet ds = new DataSet();
            MySqlConnection conn = GetConnection();
            conn.Open();
            adapter.Fill(ds, "customer");
            dataGridView.DataSource = ds.Tables["customer"];
            conn.Close();

        }

        public void DeleteCustomer(string column, string value)
        {
            List<string> Query = new List<string>
            {
                "DELETE FROM client_schedule.customer WHERE " + column + " = '" + value + "'",
                "DELETE FROM client_schedule.address WHERE addressId = '" + value + "'",
                "DELETE FROM client_schedule.appointment WHERE " + column + " = '" + value + "'"
            };

            MySqlConnection conn = GetConnection();
            conn.Open();
            foreach (string query in Query)
            {
                MySqlCommand command = new MySqlCommand(query, conn);
                command.ExecuteNonQuery();
            }

        }

        public void AddCustomer( string customerID, string customerName, string AddressID, int active, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdateBy )
        {
            MySqlConnection conn = GetConnection();
            conn.Open();
            string insertQuery = "INSERT INTO client_schedule.customer VALUES('" + customerID + "', '" + customerName+ "', '" + AddressID + "', '" + active + "', current_date(), '" + createdBy + "', current_date(), '" + lastUpdateBy + "')";
            string insertAddressQuery = "INSERT INTO client_schedule.address VALUES('" + AddressID + "', '213 Auburn',' ', '2', '12345', '123-1524', now(), '" + lastUpdateBy + "', now(), '" +lastUpdateBy + "')";
            MySqlCommand command = new MySqlCommand(insertQuery, conn);
            MySqlCommand command2 = new MySqlCommand(insertAddressQuery, conn);
            command2.ExecuteNonQuery();
            command.ExecuteNonQuery();
            
        }
    }
}
