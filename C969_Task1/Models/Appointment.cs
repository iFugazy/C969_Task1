﻿using MySql.Data.MySqlClient;
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
            this.location = location;
            this.Type = Type;
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

            string Query = "SELECT appointmentID, customerID, userID, title, type, description, contact, url, start, end FROM appointment";

            MySqlDataAdapter adapter = new MySqlDataAdapter(db.DBCommand(Query));

            adapter.Fill(appointmentInfo);

            for (int i = 0; i < userAppointmentInfo.Rows.Count; i++)
            {
                DateTime start = (DateTime)userAppointmentInfo.Rows[i]["start"];
                start = DateTime.SpecifyKind(start, DateTimeKind.Utc).ToLocalTime();
                userAppointmentInfo.Rows[i]["start"] = start;

                DateTime end = (DateTime)userAppointmentInfo.Rows[i]["end"];
                end = DateTime.SpecifyKind(end, DateTimeKind.Utc).ToLocalTime();
                userAppointmentInfo.Rows[i]["end"] = end;
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

            for (int i = 0; i < userAppointmentInfo.Rows.Count; i++)
            {
                DateTime start = (DateTime)userAppointmentInfo.Rows[i]["start"];
                start = DateTime.SpecifyKind(start, DateTimeKind.Utc).ToLocalTime();
                userAppointmentInfo.Rows[i]["start"] = start;

                DateTime end = (DateTime)userAppointmentInfo.Rows[i]["end"];
                end = DateTime.SpecifyKind(end, DateTimeKind.Utc).ToLocalTime();
                userAppointmentInfo.Rows[i]["end"] = end;
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

            for (int i = 0; i < userAppointmentInfo.Rows.Count; i++)
            {
                DateTime start = (DateTime)userAppointmentInfo.Rows[i]["start"];
                start = DateTime.SpecifyKind(start, DateTimeKind.Utc).ToLocalTime();
                userAppointmentInfo.Rows[i]["start"] = start;

                DateTime end = (DateTime)userAppointmentInfo.Rows[i]["end"];
                end = DateTime.SpecifyKind(end, DateTimeKind.Utc).ToLocalTime();
                userAppointmentInfo.Rows[i]["end"] = end;
            }

            return appointmentInfo;
        }

        public static DataTable AppointmentsByUser(int userID)
        {
            DatabaseConnection db = new DatabaseConnection();
            
            userAppointmentInfo.Clear();

            string Query = $"SELECT appointmentID, customerID, title, type, description, location, contact, url, start, end FROM appointment WHERE userID = {userID}";

            MySqlDataAdapter adapter = new MySqlDataAdapter(db.DBCommand(Query));

            adapter.Fill(userAppointmentInfo);
            try
            {
                
                for (int i = 0; i < userAppointmentInfo.Rows.Count; i++)
                {
                DateTime start = (DateTime)userAppointmentInfo.Rows[i]["start"];
                start = DateTime.SpecifyKind(start, DateTimeKind.Utc).ToLocalTime();
                userAppointmentInfo.Rows[i]["start"] = start;

                DateTime end = (DateTime)userAppointmentInfo.Rows[i]["end"];
                end = DateTime.SpecifyKind(end, DateTimeKind.Utc).ToLocalTime();
                userAppointmentInfo.Rows[i]["end"] = end;
                }
            }
           

            catch 
            {
                
            }
           

            return userAppointmentInfo;
        }

        public static DataTable AppointmentsByCalendar(string selectedStartDate, string selectedEndDate)
        {
            DatabaseConnection db = new DatabaseConnection();

            calendarAppointmentInfo.Clear();

            string Query = $"SELECT appointmentID, customerID, userID, title, type, description, contact, url, start, end FROM appointment WHERE start >= '{selectedStartDate}' and end <= '{selectedEndDate}'";

            MySqlDataAdapter adapter = new MySqlDataAdapter(db.DBCommand(Query));

            adapter.Fill(calendarAppointmentInfo);


            return calendarAppointmentInfo;
        }




        public static void AddAppointment(Appointment appointment)
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();

                string Query = $"INSERT INTO appointment (appointmentID, customerID, userID, title, description, location, type, contact, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy ) VALUES ({appointment.appointmentID},{appointment.customerID}, {appointment.userID}, '{appointment.title}', '{appointment.description}', '{appointment.location}', '{appointment.Type}', '{appointment.contact}', '{appointment.url}', '{appointment.start.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', '{appointment.end.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', Now(), 'test', Now(), 'test')";

                db.DBCommand(Query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public static void UpdateAppointment(Appointment appointment)
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();

                string Query = $"UPDATE appointment SET customerID = {appointment.customerID}, userID = {appointment.userID}, title = '{appointment.title}', type = '{appointment.Type}', description = '{appointment.description}', contact = '{appointment.contact}', url = '{appointment.url}', location = '{appointment.location}', start = '{appointment.start.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', end = '{appointment.end.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}' WHERE appointmentID = {appointment.appointmentID}";

                db.DBCommand(Query);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void DeleteAppointment(int appointmentID)
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();

                string Query = $"DELETE FROM appointment WHERE appointmentID = {appointmentID}";

                db.DBCommand(Query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


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

            string qry = $"SELECT * FROM appointment WHERE userId = '{appointment.userID}' and appointmentid != {appointment.appointmentID} and ((start >= '{appointment.start.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}' and start <= '{appointment.end.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}') or (end >= '{appointment.start.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}' and end <= '{appointment.end.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}'))"; 

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
            DateTime businessEnd = DateTime.Today.AddHours(17).AddMinutes(1);

            DateTime appointmentStart = DateTime.Parse(appointment.start.ToString());
            DateTime appointmentEnd = DateTime.Parse(appointment.end.ToString());

            if (appointmentStart.TimeOfDay >= businessStart.TimeOfDay && appointmentStart.TimeOfDay <= businessEnd.TimeOfDay && appointmentEnd.TimeOfDay >= businessStart.TimeOfDay && appointmentEnd.TimeOfDay <= businessEnd.TimeOfDay)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void checkUserReminders(int userID)
        {
            DateTime currentUtc = DateTime.UtcNow;
            DatabaseConnection db = new DatabaseConnection();
            string query = $"SELECT *\r\nFROM appointment\r\nWHERE userid = {userID} and start BETWEEN NOW() AND NOW() + INTERVAL 15 MINUTE;";

            MySqlDataReader rdr = db.DBCommand(query).ExecuteReader();
            
            if (rdr.HasRows)
            {
                MessageBox.Show("You have an appointment within the next 15 minutes");
            }
        }
    }
}
