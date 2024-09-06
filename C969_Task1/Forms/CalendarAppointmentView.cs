using C969_Task1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Task1.Forms
{
    public partial class CalendarAppointmentView : Form
    {
        public string selectedStartDate { get; set; }
        public string selectedEndDate { get; set; }
        public CalendarAppointmentView(string selectedStartDate, string selectedEndDate)
        {
            InitializeComponent();
            this.selectedStartDate = selectedStartDate;
            this.selectedEndDate = selectedEndDate;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            this.Close();
            
        }

        private void CalendarAppointmentView_Load(object sender, EventArgs e)
        {
            dataGridView2.DataSource = Appointment.AppointmentsByCalendar(selectedStartDate, selectedEndDate);
        }
    }
}
