namespace authenticator
{
    partial class register
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
            label6 = new Label();
            registerButton = new Button();
            confirmpwd = new TextBox();
            password = new TextBox();
            label5 = new Label();
            linktoLogin = new LinkLabel();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            username = new TextBox();
            label1 = new Label();
            showpwd = new CheckBox();
            SuspendLayout();
            // 
            // label6
            // 
            label6.BackColor = SystemColors.Control;
            label6.BorderStyle = BorderStyle.FixedSingle;
            label6.Location = new Point(40, 283);
            label6.Name = "label6";
            label6.Size = new Size(384, 1);
            label6.TabIndex = 21;
            // 
            // registerButton
            // 
            registerButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            registerButton.Location = new Point(182, 240);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(100, 30);
            registerButton.TabIndex = 5;
            registerButton.Text = "Sign up";
            registerButton.UseVisualStyleBackColor = true;
            registerButton.Click += registerButton_Click;
            // 
            // confirmpwd
            // 
            confirmpwd.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            confirmpwd.Location = new Point(200, 180);
            confirmpwd.Name = "confirmpwd";
            confirmpwd.Size = new Size(200, 27);
            confirmpwd.TabIndex = 3;
            // 
            // password
            // 
            password.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            password.Location = new Point(200, 140);
            password.Name = "password";
            password.Size = new Size(200, 27);
            password.TabIndex = 2;
            // 
            // label5
            // 
            label5.BackColor = SystemColors.Control;
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Location = new Point(40, 78);
            label5.Name = "label5";
            label5.Size = new Size(384, 1);
            label5.TabIndex = 17;
            // 
            // linktoLogin
            // 
            linktoLogin.AutoSize = true;
            linktoLogin.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            linktoLogin.Location = new Point(95, 303);
            linktoLogin.Name = "linktoLogin";
            linktoLogin.Size = new Size(257, 20);
            linktoLogin.TabIndex = 6;
            linktoLogin.TabStop = true;
            linktoLogin.Text = "Already had the account? Just login";
            linktoLogin.TextAlign = ContentAlignment.MiddleCenter;
            linktoLogin.LinkClicked += linktoLogin_LinkClicked;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(160, 18);
            label4.Name = "label4";
            label4.Size = new Size(142, 45);
            label4.TabIndex = 15;
            label4.Text = "Register";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(50, 183);
            label3.Name = "label3";
            label3.Size = new Size(141, 21);
            label3.TabIndex = 14;
            label3.Text = "Confirm password:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(50, 143);
            label2.Name = "label2";
            label2.Size = new Size(79, 21);
            label2.TabIndex = 13;
            label2.Text = "Password:";
            // 
            // username
            // 
            username.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            username.Location = new Point(200, 100);
            username.Name = "username";
            username.Size = new Size(200, 27);
            username.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(50, 103);
            label1.Name = "label1";
            label1.Size = new Size(84, 21);
            label1.TabIndex = 11;
            label1.Text = "Username:";
            // 
            // showpwd
            // 
            showpwd.AutoSize = true;
            showpwd.Location = new Point(292, 215);
            showpwd.Name = "showpwd";
            showpwd.Size = new Size(108, 19);
            showpwd.TabIndex = 4;
            showpwd.Text = "Show password";
            showpwd.UseVisualStyleBackColor = true;
            showpwd.CheckedChanged += showpwd_CheckedChanged;
            // 
            // register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 341);
            Controls.Add(showpwd);
            Controls.Add(label6);
            Controls.Add(registerButton);
            Controls.Add(confirmpwd);
            Controls.Add(password);
            Controls.Add(label5);
            Controls.Add(linktoLogin);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(username);
            Controls.Add(label1);
            Name = "register";
            Text = "register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label6;
        private Button registerButton;
        private TextBox confirmpwd;
        private TextBox password;
        private Label label5;
        private LinkLabel linktoLogin;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox username;
        private Label label1;
        private CheckBox showpwd;
    }
}