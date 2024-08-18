namespace C969_Task1.Forms.Customer
{
    partial class EditCustomer
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
            this.label1 = new System.Windows.Forms.Label();
            this.customerNameTB = new System.Windows.Forms.TextBox();
            this.address1TB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.postalCodeTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.phoneNumberTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.address2TB = new System.Windows.Forms.TextBox();
            this.customerIDTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.activeCB = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer Name";
            // 
            // customerNameTB
            // 
            this.customerNameTB.Location = new System.Drawing.Point(119, 55);
            this.customerNameTB.Name = "customerNameTB";
            this.customerNameTB.Size = new System.Drawing.Size(100, 20);
            this.customerNameTB.TabIndex = 1;
            // 
            // address1TB
            // 
            this.address1TB.Location = new System.Drawing.Point(119, 91);
            this.address1TB.Name = "address1TB";
            this.address1TB.Size = new System.Drawing.Size(100, 20);
            this.address1TB.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Address";
            // 
            // postalCodeTB
            // 
            this.postalCodeTB.Location = new System.Drawing.Point(119, 154);
            this.postalCodeTB.Name = "postalCodeTB";
            this.postalCodeTB.Size = new System.Drawing.Size(100, 20);
            this.postalCodeTB.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Postal Code";
            // 
            // phoneNumberTB
            // 
            this.phoneNumberTB.Location = new System.Drawing.Point(119, 192);
            this.phoneNumberTB.Name = "phoneNumberTB";
            this.phoneNumberTB.Size = new System.Drawing.Size(100, 20);
            this.phoneNumberTB.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Phone Number";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Edit Customer";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(128, 254);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 254);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // address2TB
            // 
            this.address2TB.Location = new System.Drawing.Point(119, 113);
            this.address2TB.Name = "address2TB";
            this.address2TB.Size = new System.Drawing.Size(100, 20);
            this.address2TB.TabIndex = 11;
            // 
            // customerIDTB
            // 
            this.customerIDTB.Location = new System.Drawing.Point(119, 29);
            this.customerIDTB.Name = "customerIDTB";
            this.customerIDTB.ReadOnly = true;
            this.customerIDTB.Size = new System.Drawing.Size(100, 20);
            this.customerIDTB.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Customer ID";
            // 
            // activeCB
            // 
            this.activeCB.AutoSize = true;
            this.activeCB.Location = new System.Drawing.Point(135, 220);
            this.activeCB.Name = "activeCB";
            this.activeCB.Size = new System.Drawing.Size(56, 17);
            this.activeCB.TabIndex = 23;
            this.activeCB.Text = "Active";
            this.activeCB.UseVisualStyleBackColor = true;
            // 
            // EditCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 289);
            this.Controls.Add(this.activeCB);
            this.Controls.Add(this.customerIDTB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.address2TB);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.phoneNumberTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.postalCodeTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.address1TB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.customerNameTB);
            this.Controls.Add(this.label1);
            this.Name = "EditCustomer";
            this.Text = "EditCustomer";
            this.Load += new System.EventHandler(this.EditCustomer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox customerNameTB;
        private System.Windows.Forms.TextBox address1TB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox postalCodeTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox phoneNumberTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox address2TB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox activeCB;
        public System.Windows.Forms.TextBox customerIDTB;
    }
}