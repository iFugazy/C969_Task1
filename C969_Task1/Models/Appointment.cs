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
        public string contact { get; set; }
        public string url { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }


        public static DataTable appointmentInfo = new DataTable();
        public static DataTable userAppointmentInfo = new DataTable();


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

        public static DataTable AppointmentsByMonth()
        {
            DatabaseConnection db = new DatabaseConnection();

            appointmentInfo.Clear();

            string Query = "SELECT appointmentID, customerID, userID, title, description, contact, url, start, end FROM appointment WHERE MONTH(start) = MONTH(CURRENT_DATE())";

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

        public static DataTable AppointmentsByWeek()
        {
            DatabaseConnection db = new DatabaseConnection();

            appointmentInfo.Clear();

            string Query = "SELECT appointmentID, customerID, userID, title, description, contact, url, start, end FROM appointment WHERE WEEK(start) = WEEK(CURRENT_DATE())";

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

        public static DataTable AppointmentsByUser(int userID)
        {
            DatabaseConnection db = new DatabaseConnection();

            userAppointmentInfo.Clear();

            string Query = $"SELECT appointmentID, customerID, userID, title, description, contact, url, start, end FROM appointment WHERE userID = {userID}";

            MySqlDataAdapter adapter = new MySqlDataAdapter(db.DBCommand(Query));

            adapter.Fill(userAppointmentInfo);

            foreach (DataRow row in userAppointmentInfo.Rows)
            {

                DateTime start = (DateTime)userAppointmentInfo.Rows[0]["start"];
                userAppointmentInfo.Rows[0]["start"] = start.ToLocalTime();

                DateTime end = (DateTime)userAppointmentInfo.Rows[0]["start"];
                userAppointmentInfo.Rows[0]["start"] = start.ToLocalTime();
            }

            return userAppointmentInfo;
        }

        public static void AddAppointment(Appointment appointment)
        {
            DatabaseConnection db = new DatabaseConnection();

            string Query = $"INSERT INTO appointment (customerID, userID, title, description, contact, url, start, end) VALUES ({appointment.customerID}, {appointment.userID}, '{appointment.title}', '{appointment.description}', '{appointment.contact}', '{appointment.url}', '{appointment.start.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', '{appointment.end.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}')";

            db.DBCommand(Query);
        }

        public static void UpdateAppointment(Appointment appointment)
        {
            DatabaseConnection db = new DatabaseConnection();

            string Query = $"UPDATE appointment SET customerID = {appointment.customerID}, userID = {appointment.userID}, title = '{appointment.title}', description = '{appointment.description}', contact = '{appointment.contact}', url = '{appointment.url}', start = '{appointment.start.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', end = '{appointment.end.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}' WHERE appointmentID = {appointment.appointmentID}";

            db.DBCommand(Query);
        }

        public static void DeleteAppointment(int appointmentID)
        {
            DatabaseConnection db = new DatabaseConnection();

            string Query = $"DELETE FROM appointment WHERE appointmentID = {appointmentID}";

            db.DBCommand(Query);


        }

        public static int NewAppointmentID()
        {
            DatabaseConnection db = new DatabaseConnection();

            string query = "SELECT MAX(appointmentID) FROM appointment";
            MySqlDataReader rdr = db.DBCommand(query).ExecuteReader();
            rdr.Read();
            if (rdr.HasRows)
            {
                return Convert.ToInt32(rdr.GetValue(0)) + 1;
            }
            else
            {
                return 0;
            }

        }

        public static void RefreshDataNonUser(DataTable table, System.Windows.Forms.DataGridView dataGridView)
        {

            dataGridView.DataSource = table;
        }

        public static void RefreshDataUser(DataTable table, System.Windows.Forms.DataGridView dataGridView)
        {
            DatabaseConnection db = new DatabaseConnection();

            table.Clear();

            MySqlDataAdapter adapter = new MySqlDataAdapter(db.DBCommand("SELECT * FROM appointment"));

            adapter.Fill(table);

            dataGridView.DataSource = table;
        }

    }
}
