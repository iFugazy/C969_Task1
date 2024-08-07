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
    public partial class EditCustomer : Form
    {
        MainCustomerForm main;
        public EditCustomer(MainCustomerForm mainCustomerForm)
        {
            InitializeComponent();
            this.main = mainCustomerForm;
        }

        private void EditCustomer_Load(object sender, EventArgs e)
        {
            textBox1.Text = main.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = main.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = main.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = main.dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
