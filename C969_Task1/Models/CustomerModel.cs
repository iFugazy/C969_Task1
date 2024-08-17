using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Task1.Models
{
    public class CustomerModel
    {
        DatabaseConnection db = new DatabaseConnection();
        public void AddCustomer(int cu )
        {
            // Add customer to database

        }
        public void UpdateCustomer() 
        {
            // Update customer in database
        }
        public void DeleteCustomer() 
        {
            // Delete customer from database
            db.OpenConnection();
            string deleteQuery = "DELETE FROM client_schedule.customer WHERE customerID = '" + 1 + "'";
            db.DBCommand(deleteQuery);

        }

    }
}
