using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Task1.Models
{
    public class Appointment
    {
        public int appointmentID { get; set; }
        public int customerID { get; set; }
        public int userID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string location { get; set; }
        public string contact { get; set; }
        public string url { get; set; }
        public string Type { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }


        public static DataTable appointmentInfo = new DataTable();
        public static DataTable userAppointmentInfo = new DataTable();
        public static DataTable calendarAppointmentInfo = new DataTable();


        public Appointment(int appointmentID, int customerID, int userID, string title, string description, string location, string Type,string contact, string url, DateTime start, DateTime end)
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
            this.location = location;
            this.Type = Type;
         
        }

        public Appointment()
        {
        }

        public static DateTime dateToHighlight()
        {
            DatabaseConnection db = new DatabaseConnection();
            string Query = "SELECT appointmentID, customerID, userID, title, type, description, contact, url, start, end FROM appointment";
            MySqlDataReader rdr = db.DBCommand(Query).ExecuteReader();
            DateTime date = new DateTime();
            while (rdr.Read())
            {
                date = Convert.ToDateTime(rdr["start"]);
            }
            return date;

        }
        public static DataTable AllAppointments()
        {
            DatabaseConnection db = new DatabaseConnection();

            appointmentInfo.Clear();

            string Query = "SELECT appointmentID, customerID, userID, title, type, description, contact, url, start, end FROM appointment";

            MySqlDataAdapter adapter = new MySqlDataAdapter(db.DBCommand(Query));

            adapter.Fill(appointmentInfo);

            for (int i = 0; i < appointmentInfo.Rows.Count; i++)
            {
                DateTime start = (DateTime)appointmentInfo.Rows[i]["start"];
                appointmentInfo.Rows[i]["start"] = start.ToLocalTime();

                DateTime end = (DateTime)appointmentInfo.Rows[i]["end"];
                appointmentInfo.Rows[i]["end"] = end.ToLocalTime();
            }

            return appointmentInfo;
        }

        public static DataTable AppointmentsByMonth()
        {
            DatabaseConnection db = new DatabaseConnection();

            appointmentInfo.Clear();

            string Query = "SELECT appointmentID, customerID, userID, title,type, description, contact, url, start, end FROM appointment WHERE MONTH(start) = MONTH(CURRENT_DATE())";

            MySqlDataAdapter adapter = new MySqlDataAdapter(db.DBCommand(Query));

            adapter.Fill(appointmentInfo);

            for (int i = 0; i < appointmentInfo.Rows.Count; i++)
            {
                DateTime start = (DateTime)appointmentInfo.Rows[i]["start"];
                appointmentInfo.Rows[i]["start"] = start.ToLocalTime();

                DateTime end = (DateTime)appointmentInfo.Rows[i]["end"];
                appointmentInfo.Rows[i]["end"] = end.ToLocalTime();
            }

            return appointmentInfo;
        }

        public static DataTable AppointmentsByWeek()
        {
            DatabaseConnection db = new DatabaseConnection();

            appointmentInfo.Clear();

            string Query = "SELECT appointmentID, customerID, userID, title, type, description, contact, url, start, end FROM appointment WHERE WEEK(start) = WEEK(CURRENT_DATE())";

            MySqlDataAdapter adapter = new MySqlDataAdapter(db.DBCommand(Query));

            adapter.Fill(appointmentInfo);

            for (int i = 0; i < appointmentInfo.Rows.Count; i++)
            {
                DateTime start = (DateTime)appointmentInfo.Rows[i]["start"];
                appointmentInfo.Rows[i]["start"] = start.ToLocalTime();

                DateTime end = (DateTime)appointmentInfo.Rows[i]["end"];
                appointmentInfo.Rows[i]["end"] = end.ToLocalTime();
            }

            return appointmentInfo;
        }

        public static DataTable AppointmentsByUser(int userID)
        {
            DatabaseConnection db = new DatabaseConnection();

            userAppointmentInfo.Clear();

            string Query = $"SELECT appointmentID, customerID, userID, title, type, description, location, contact, url, start, end FROM appointment WHERE userID = {userID}";

            MySqlDataAdapter adapter = new MySqlDataAdapter(db.DBCommand(Query));

            adapter.Fill(userAppointmentInfo);
            try
            {
                for (int i = 0; i < userAppointmentInfo.Rows.Count; i++)
                {
                    DateTime start = (DateTime)appointmentInfo.Rows[i]["start"];
                    appointmentInfo.Rows[i]["start"] = start.ToLocalTime();

                    DateTime end = (DateTime)appointmentInfo.Rows[i]["end"];
                    appointmentInfo.Rows[i]["end"] = end.ToLocalTime();
                }
            }
            catch 
            {
                
            }
           

            return userAppointmentInfo;
        }

        public static DataTable AppointmentsByCalendar(string selectedDate)
        {
            DatabaseConnection db = new DatabaseConnection();

            calendarAppointmentInfo.Clear();

            string Query = $"SELECT appointmentID, customerID, userID, title, type, description, contact, url, start, end FROM appointment WHERE start = '{selectedDate}'";

            MySqlDataAdapter adapter = new MySqlDataAdapter(db.DBCommand(Query));

            adapter.Fill(calendarAppointmentInfo);

            for (int i = 0; i < calendarAppointmentInfo.Rows.Count; i++)
            {
                DateTime start = (DateTime)appointmentInfo.Rows[i]["start"];
                appointmentInfo.Rows[i]["start"] = start.ToLocalTime();

                DateTime end = (DateTime)appointmentInfo.Rows[i]["end"];
                appointmentInfo.Rows[i]["end"] = end.ToLocalTime();
            }

            return calendarAppointmentInfo;
        }




        public static void AddAppointment(Appointment appointment)
        {
            DatabaseConnection db = new DatabaseConnection();

            string Query = $"INSERT INTO appointment (appointmentID, customerID, userID, title, description, location, type, contact, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy ) VALUES ({appointment.appointmentID},{appointment.customerID}, {appointment.userID}, '{appointment.title}', '{appointment.description}', '{appointment.location}', '{appointment.Type}', '{appointment.contact}', '{appointment.url}', '{appointment.start.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', '{appointment.end.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', Now(), 'test', Now(), 'test')";

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

            int newAppointmentID = 0;

            string query = "SELECT MAX(appointmentId) FROM appointment";

            MySqlDataReader rdr = db.DBCommand(query).ExecuteReader();
            while (rdr.Read())
            {
                newAppointmentID = Convert.ToInt32(rdr.GetValue(0)) + 1;
            }

            rdr.Close();

            return newAppointmentID;

        }

        public static void RefreshData(DataTable table, System.Windows.Forms.DataGridView dataGridView)
        {

            dataGridView.DataSource = table;
        }

        public static bool OverlappingAppointment(Appointment appointment)
        {
            DatabaseConnection db = new DatabaseConnection();
            
            string qry = $"SELECT * FROM appointment WHERE userId = '{appointment.userID}' and ((start >= '{appointment.start.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}' and end <= '{appointment.end.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}') or (end >= '{appointment.start.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}' and end <= '{appointment.end.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}'))";

            MySqlDataReader rdr = db.DBCommand(qry).ExecuteReader();

            while (rdr.Read()) ;
            {
                if (rdr.HasRows)
                {
                    rdr.Close();
                    return false;
                }
                else
                {
                    rdr.Close();
                    return true;
                }
            }
            
        }

        public static bool WithinBusinessHours(Appointment appointment)
        {
            DateTime businessStart = DateTime.Today.AddHours(8);
            DateTime businessEnd = DateTime.Today.AddHours(17);

            DateTime appointmentStart = DateTime.Parse(appointment.start.ToString());
            DateTime appointmentEnd = DateTime.Parse(appointment.end.ToString());

            if (appointmentStart.TimeOfDay >= businessStart.TimeOfDay && appointmentStart.TimeOfDay <= businessEnd.TimeOfDay && appointmentEnd.TimeOfDay > businessStart.TimeOfDay && appointmentEnd.TimeOfDay <= businessEnd.TimeOfDay)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<Appointment> checkUserReminders(int userID)
        {
            List<Appointment> appts = new List<Appointment>();
            DateTime currentUtc = DateTime.UtcNow;
            DatabaseConnection db = new DatabaseConnection();
            string query = $"SELECT * FROM appointment WHERE userId = '{userID}' and TIMESTAMPDIFF(MINUTE, start, '{currentUtc}') < 15";

            MySqlCommand cmd = db.DBCommand(query);
            cmd.ExecuteNonQuery();

            
            return appts;
        }
    }
}
