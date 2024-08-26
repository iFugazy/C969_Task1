using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Task1.Models
{
    public class Customer
    {
        public static DataTable customerInfo = new DataTable();
        public static DataTable SimpleCustomerList()
        {
            DatabaseConnection db = new DatabaseConnection();

            customerInfo.Clear();

            string Query = "SELECT customer.customerID as \"Customer ID\",\r\ncustomer.customerName as \"Customer Name\" FROM customer";

            MySqlDataAdapter adapter = new MySqlDataAdapter(db.DBCommand(Query));

            adapter.Fill(customerInfo);

            return customerInfo;
        }

    }
}
