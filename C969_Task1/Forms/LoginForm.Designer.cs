namespace C969_Task1
{
    partial class LoginForm
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
            this.usernameTB = new System.Windows.Forms.TextBox();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.usernameLBL = new System.Windows.Forms.Label();
            this.passwordLBL = new System.Windows.Forms.Label();
            this.locationLBL = new System.Windows.Forms.Label();
            this.userLocationLBL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usernameTB
            // 
            this.usernameTB.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTB.Location = new System.Drawing.Point(114, 63);
            this.usernameTB.Name = "usernameTB";
            this.usernameTB.Size = new System.Drawing.Size(248, 25);
            this.usernameTB.TabIndex = 3;
            // 
            // passwordTB
            // 
            this.passwordTB.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTB.Location = new System.Drawing.Point(114, 123);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.Size = new System.Drawing.Size(248, 25);
            this.passwordTB.TabIndex = 4;
            // 
            // usernameLBL
            // 
            this.usernameLBL.AutoSize = true;
            this.usernameLBL.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLBL.Location = new System.Drawing.Point(32, 66);
            this.usernameLBL.Name = "usernameLBL";
            this.usernameLBL.Size = new System.Drawing.Size(70, 17);
            this.usernameLBL.TabIndex = 5;
            this.usernameLBL.Text = "Username";
            // 
            // passwordLBL
            // 
            this.passwordLBL.AutoSize = true;
            this.passwordLBL.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLBL.Location = new System.Drawing.Point(34, 126);
            this.passwordLBL.Name = "passwordLBL";
            this.passwordLBL.Size = new System.Drawing.Size(66, 17);
            this.passwordLBL.TabIndex = 6;
            this.passwordLBL.Text = "Password";
            // 
            // locationLBL
            // 
            this.locationLBL.AutoSize = true;
            this.locationLBL.Location = new System.Drawing.Point(13, 13);
            this.locationLBL.Name = "locationLBL";
            this.locationLBL.Size = new System.Drawing.Size(51, 13);
            this.locationLBL.TabIndex = 7;
            this.locationLBL.Text = "Location:";
            // 
            // userLocationLBL
            // 
            this.userLocationLBL.AutoSize = true;
            this.userLocationLBL.Location = new System.Drawing.Point(61, 13);
            this.userLocationLBL.Name = "userLocationLBL";
            this.userLocationLBL.Size = new System.Drawing.Size(55, 13);
            this.userLocationLBL.TabIndex = 8;
            this.userLocationLBL.Text = "TimeZone";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(397, 234);
            this.Controls.Add(this.userLocationLBL);
            this.Controls.Add(this.locationLBL);
            this.Controls.Add(this.passwordLBL);
            this.Controls.Add(this.usernameLBL);
            this.Controls.Add(this.passwordTB);
            this.Controls.Add(this.usernameTB);
            this.Name = "LoginForm";
            this.Text = "loginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label usernameLBL;
        private System.Windows.Forms.Label passwordLBL;
        private System.Windows.Forms.Label locationLBL;
        public System.Windows.Forms.Label userLocationLBL;
        public System.Windows.Forms.TextBox usernameTB;
        public System.Windows.Forms.TextBox passwordTB;
    }
}

