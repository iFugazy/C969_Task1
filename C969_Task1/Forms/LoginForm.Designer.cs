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
            this.loginBTN = new System.Windows.Forms.Button();
            this.cancelBTN = new System.Windows.Forms.Button();
            this.englishRBTN = new System.Windows.Forms.RadioButton();
            this.spanishRBTN = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // usernameTB
            // 
            this.usernameTB.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTB.Location = new System.Drawing.Point(187, 66);
            this.usernameTB.Name = "usernameTB";
            this.usernameTB.Size = new System.Drawing.Size(248, 25);
            this.usernameTB.TabIndex = 3;
            // 
            // passwordTB
            // 
            this.passwordTB.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTB.Location = new System.Drawing.Point(187, 140);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.Size = new System.Drawing.Size(248, 25);
            this.passwordTB.TabIndex = 4;
            // 
            // usernameLBL
            // 
            this.usernameLBL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usernameLBL.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLBL.Location = new System.Drawing.Point(-37, 69);
            this.usernameLBL.Name = "usernameLBL";
            this.usernameLBL.Size = new System.Drawing.Size(218, 17);
            this.usernameLBL.TabIndex = 5;
            this.usernameLBL.Text = "Username";
            this.usernameLBL.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // passwordLBL
            // 
            this.passwordLBL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordLBL.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLBL.Location = new System.Drawing.Point(-33, 143);
            this.passwordLBL.Name = "passwordLBL";
            this.passwordLBL.Size = new System.Drawing.Size(214, 17);
            this.passwordLBL.TabIndex = 6;
            this.passwordLBL.Text = "Password";
            this.passwordLBL.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // locationLBL
            // 
            this.locationLBL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.locationLBL.Location = new System.Drawing.Point(8, 13);
            this.locationLBL.Name = "locationLBL";
            this.locationLBL.Size = new System.Drawing.Size(62, 13);
            this.locationLBL.TabIndex = 7;
            this.locationLBL.Text = "Location:";
            this.locationLBL.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // userLocationLBL
            // 
            this.userLocationLBL.AutoSize = true;
            this.userLocationLBL.Location = new System.Drawing.Point(66, 13);
            this.userLocationLBL.Name = "userLocationLBL";
            this.userLocationLBL.Size = new System.Drawing.Size(55, 13);
            this.userLocationLBL.TabIndex = 8;
            this.userLocationLBL.Text = "TimeZone";
            // 
            // loginBTN
            // 
            this.loginBTN.Location = new System.Drawing.Point(269, 182);
            this.loginBTN.Name = "loginBTN";
            this.loginBTN.Size = new System.Drawing.Size(75, 23);
            this.loginBTN.TabIndex = 9;
            this.loginBTN.Text = "Login";
            this.loginBTN.UseVisualStyleBackColor = true;
            this.loginBTN.Click += new System.EventHandler(this.loginBTN_Click);
            // 
            // cancelBTN
            // 
            this.cancelBTN.Location = new System.Drawing.Point(431, 229);
            this.cancelBTN.Name = "cancelBTN";
            this.cancelBTN.Size = new System.Drawing.Size(75, 23);
            this.cancelBTN.TabIndex = 10;
            this.cancelBTN.Text = "Cancel";
            this.cancelBTN.UseVisualStyleBackColor = true;
            this.cancelBTN.Click += new System.EventHandler(this.cancelBTN_Click);
            // 
            // englishRBTN
            // 
            this.englishRBTN.AutoSize = true;
            this.englishRBTN.Checked = true;
            this.englishRBTN.Location = new System.Drawing.Point(16, 229);
            this.englishRBTN.Name = "englishRBTN";
            this.englishRBTN.Size = new System.Drawing.Size(40, 17);
            this.englishRBTN.TabIndex = 11;
            this.englishRBTN.TabStop = true;
            this.englishRBTN.Text = "EN";
            this.englishRBTN.UseVisualStyleBackColor = true;
            // 
            // spanishRBTN
            // 
            this.spanishRBTN.AutoSize = true;
            this.spanishRBTN.Location = new System.Drawing.Point(68, 229);
            this.spanishRBTN.Name = "spanishRBTN";
            this.spanishRBTN.Size = new System.Drawing.Size(39, 17);
            this.spanishRBTN.TabIndex = 12;
            this.spanishRBTN.Text = "ES";
            this.spanishRBTN.UseVisualStyleBackColor = true;
            this.spanishRBTN.CheckedChanged += new System.EventHandler(this.spanishRBTN_CheckedChanged);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(518, 264);
            this.Controls.Add(this.spanishRBTN);
            this.Controls.Add(this.englishRBTN);
            this.Controls.Add(this.cancelBTN);
            this.Controls.Add(this.loginBTN);
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
        public System.Windows.Forms.Label userLocationLBL;
        public System.Windows.Forms.TextBox usernameTB;
        public System.Windows.Forms.TextBox passwordTB;
        public System.Windows.Forms.Label usernameLBL;
        public System.Windows.Forms.Label passwordLBL;
        public System.Windows.Forms.Button loginBTN;
        public System.Windows.Forms.Button cancelBTN;
        public System.Windows.Forms.RadioButton englishRBTN;
        public System.Windows.Forms.RadioButton spanishRBTN;
        public System.Windows.Forms.Label locationLBL;
    }
}

