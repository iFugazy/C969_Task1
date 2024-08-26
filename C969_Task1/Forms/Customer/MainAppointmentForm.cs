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

namespace C969_Task1.Forms.Customer
{
    public partial class MainAppointmentForm : Form
    {
        public MainAppointmentForm()
        {
            InitializeComponent();
            dataGridView1.DataSource = Appointment.AppointmentsByUser(1);
        }

        private void deleteBTN_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you would like to delete this appointmnet?", "Delete Appointment", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Appointment.DeleteAppointment(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                Appointment.RefreshData(Appointment.AppointmentsByUser(1), dataGridView1);
                return;
            }
            
        }

        private void addBTN_Click_1(object sender, EventArgs e)
        {
            AddAppointment addAppointment = new AddAppointment();
            addAppointment.Show();
            this.Hide();
        }
    }
}
