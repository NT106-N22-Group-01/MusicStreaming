namespace authenticator
{
    partial class login
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
            label4 = new Label();
            label5 = new Label();
            label1 = new Label();
            label2 = new Label();
            username = new TextBox();
            password = new TextBox();
            loginButton = new Button();
            label3 = new Label();
            linktoRegister = new LinkLabel();
            showpwd = new CheckBox();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(179, 15);
            label4.Name = "label4";
            label4.Size = new Size(104, 45);
            label4.TabIndex = 16;
            label4.Text = "Login";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.BackColor = SystemColors.Control;
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Location = new Point(40, 75);
            label5.Name = "label5";
            label5.Size = new Size(384, 1);
            label5.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(50, 100);
            label1.Name = "label1";
            label1.Size = new Size(84, 21);
            label1.TabIndex = 19;
            label1.Text = "Username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(50, 150);
            label2.Name = "label2";
            label2.Size = new Size(79, 21);
            label2.TabIndex = 20;
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
            // password
            // 
            password.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            password.Location = new Point(200, 150);
            password.Name = "password";
            password.Size = new Size(200, 27);
            password.TabIndex = 2;
            // 
            // loginButton
            // 
            loginButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            loginButton.Location = new Point(182, 215);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(100, 30);
            loginButton.TabIndex = 4;
            loginButton.Text = "Sign in";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // label3
            // 
            label3.BackColor = SystemColors.Control;
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Location = new Point(40, 260);
            label3.Name = "label3";
            label3.Size = new Size(384, 1);
            label3.TabIndex = 24;
            // 
            // linktoRegister
            // 
            linktoRegister.AutoSize = true;
            linktoRegister.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            linktoRegister.Location = new Point(104, 280);
            linktoRegister.Name = "linktoRegister";
            linktoRegister.Size = new Size(244, 20);
            linktoRegister.TabIndex = 5;
            linktoRegister.TabStop = true;
            linktoRegister.Text = "Haven't an account? Register now";
            linktoRegister.TextAlign = ContentAlignment.MiddleCenter;
            linktoRegister.LinkClicked += linktoRegister_LinkClicked;
            // 
            // showpwd
            // 
            showpwd.AutoSize = true;
            showpwd.Location = new Point(292, 195);
            showpwd.Name = "showpwd";
            showpwd.Size = new Size(108, 19);
            showpwd.TabIndex = 3;
            showpwd.Text = "Show Password";
            showpwd.UseVisualStyleBackColor = true;
            showpwd.CheckedChanged += showpwd_CheckedChanged;
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 321);
            Controls.Add(showpwd);
            Controls.Add(linktoRegister);
            Controls.Add(label3);
            Controls.Add(loginButton);
            Controls.Add(password);
            Controls.Add(username);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label5);
            Controls.Add(label4);
            Name = "login";
            Text = "login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private Label label5;
        private Label label1;
        private Label label2;
        private TextBox username;
        private TextBox password;
        private Button loginButton;
        private Label label3;
        private LinkLabel linktoRegister;
        private CheckBox showpwd;
    }
}