namespace C969_Task1.Forms
{
    partial class MainCustomerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.addBTN = new System.Windows.Forms.Button();
            this.editBTN = new System.Windows.Forms.Button();
            this.deleteBTN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(36, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(396, 340);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // addBTN
            // 
            this.addBTN.Location = new System.Drawing.Point(36, 392);
            this.addBTN.Name = "addBTN";
            this.addBTN.Size = new System.Drawing.Size(104, 23);
            this.addBTN.TabIndex = 1;
            this.addBTN.Text = "Add Customer";
            this.addBTN.UseVisualStyleBackColor = true;
            this.addBTN.Click += new System.EventHandler(this.addBTN_Click);
            // 
            // editBTN
            // 
            this.editBTN.Location = new System.Drawing.Point(186, 392);
            this.editBTN.Name = "editBTN";
            this.editBTN.Size = new System.Drawing.Size(95, 23);
            this.editBTN.TabIndex = 2;
            this.editBTN.Text = "Edit Customer";
            this.editBTN.UseVisualStyleBackColor = true;
            this.editBTN.Click += new System.EventHandler(this.editBTN_Click);
            // 
            // deleteBTN
            // 
            this.deleteBTN.Location = new System.Drawing.Point(321, 392);
            this.deleteBTN.Name = "deleteBTN";
            this.deleteBTN.Size = new System.Drawing.Size(111, 23);
            this.deleteBTN.TabIndex = 3;
            this.deleteBTN.Text = "Delete Customer";
            this.deleteBTN.UseVisualStyleBackColor = true;
            this.deleteBTN.Click += new System.EventHandler(this.deleteBTN_Click);
            // 
            // MainCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 450);
            this.Controls.Add(this.deleteBTN);
            this.Controls.Add(this.editBTN);
            this.Controls.Add(this.addBTN);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainCustomerForm";
            this.Text = "AddCustomerForm";
            this.Load += new System.EventHandler(this.AddCustomerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button addBTN;
        private System.Windows.Forms.Button editBTN;
        private System.Windows.Forms.Button deleteBTN;
        public System.Windows.Forms.DataGridView dataGridView1;
    }
}