using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Task1.Models
{
    public class Appointment
    {
        public int appointmentID { get; set; }
        public int customerID { get; set; }
        public int userID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string  contact { get; set; }
        public string url { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }


        public static DataTable appointmentInfo = new DataTable();


        public Appointment(int appointmentID, int customerID, int userID, string title, string description, string contact, string url, DateTime start, DateTime end)
        {
            this.appointmentID = appointmentID;
            this.customerID = customerID;
            this.userID = userID;
            this.title = title;
            this.description = description;
            this.contact = contact;
            this.url = url;
            this.start = start;
            this.end = end;
        }

        public Appointment()
        {
        }

        public static DataTable AllAppointments()
        {
            DatabaseConnection db = new DatabaseConnection();

            appointmentInfo.Clear();

            string Query = "SELECT appointmentID, customerID, userID, title, description, contact, url, start, end FROM appointment";
            
            MySqlDataAdapter adapter = new MySqlDataAdapter(db.DBCommand(Query));

            adapter.Fill(appointmentInfo);

            foreach (DataRow row in appointmentInfo.Rows)
            {

                DateTime start = (DateTime)appointmentInfo.Rows[0]["start"];
                appointmentInfo.Rows[0]["start"] = start.ToLocalTime();

                DateTime end = (DateTime)appointmentInfo.Rows[0]["start"];
                appointmentInfo.Rows[0]["start"] = start.ToLocalTime();
            }

            return appointmentInfo;
        }
    }
}
