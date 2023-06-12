namespace MusicStreaming.Auth
{
	partial class fmRegister
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
			txtConfirmpwd = new TextBox();
			txtPassword = new TextBox();
			label5 = new Label();
			linktoLogin = new LinkLabel();
			label4 = new Label();
			label3 = new Label();
			label2 = new Label();
			txtUsername = new TextBox();
			label1 = new Label();
			showpwd = new CheckBox();
			SuspendLayout();
			// 
			// label6
			// 
			label6.BackColor = SystemColors.Control;
			label6.BorderStyle = BorderStyle.FixedSingle;
			label6.Location = new Point(57, 472);
			label6.Margin = new Padding(4, 0, 4, 0);
			label6.Name = "label6";
			label6.Size = new Size(548, 0);
			label6.TabIndex = 21;
			// 
			// registerButton
			// 
			registerButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
			registerButton.Location = new Point(260, 400);
			registerButton.Margin = new Padding(4, 5, 4, 5);
			registerButton.Name = "registerButton";
			registerButton.Size = new Size(143, 50);
			registerButton.TabIndex = 5;
			registerButton.Text = "Sign up";
			registerButton.UseVisualStyleBackColor = true;
			registerButton.Click += registerButton_Click;
			// 
			// txtConfirmpwd
			// 
			txtConfirmpwd.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			txtConfirmpwd.Location = new Point(286, 300);
			txtConfirmpwd.Margin = new Padding(4, 5, 4, 5);
			txtConfirmpwd.Name = "txtConfirmpwd";
			txtConfirmpwd.Size = new Size(284, 37);
			txtConfirmpwd.TabIndex = 3;
			// 
			// txtPassword
			// 
			txtPassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			txtPassword.Location = new Point(286, 233);
			txtPassword.Margin = new Padding(4, 5, 4, 5);
			txtPassword.Name = "txtPassword";
			txtPassword.Size = new Size(284, 37);
			txtPassword.TabIndex = 2;
			// 
			// label5
			// 
			label5.BackColor = SystemColors.Control;
			label5.BorderStyle = BorderStyle.FixedSingle;
			label5.Location = new Point(57, 130);
			label5.Margin = new Padding(4, 0, 4, 0);
			label5.Name = "label5";
			label5.Size = new Size(548, 0);
			label5.TabIndex = 17;
			// 
			// linktoLogin
			// 
			linktoLogin.AutoSize = true;
			linktoLogin.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
			linktoLogin.Location = new Point(136, 505);
			linktoLogin.Margin = new Padding(4, 0, 4, 0);
			linktoLogin.Name = "linktoLogin";
			linktoLogin.Size = new Size(394, 31);
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
			label4.Location = new Point(229, 30);
			label4.Margin = new Padding(4, 0, 4, 0);
			label4.Name = "label4";
			label4.Size = new Size(213, 65);
			label4.TabIndex = 15;
			label4.Text = "Register";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			label3.Location = new Point(71, 305);
			label3.Margin = new Padding(4, 0, 4, 0);
			label3.Name = "label3";
			label3.Size = new Size(211, 32);
			label3.TabIndex = 14;
			label3.Text = "Confirm password:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			label2.Location = new Point(71, 238);
			label2.Margin = new Padding(4, 0, 4, 0);
			label2.Name = "label2";
			label2.Size = new Size(116, 32);
			label2.TabIndex = 13;
			label2.Text = "Password:";
			// 
			// txtUsername
			// 
			txtUsername.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			txtUsername.Location = new Point(286, 167);
			txtUsername.Margin = new Padding(4, 5, 4, 5);
			txtUsername.Name = "txtUsername";
			txtUsername.Size = new Size(284, 37);
			txtUsername.TabIndex = 1;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(71, 172);
			label1.Margin = new Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new Size(126, 32);
			label1.TabIndex = 11;
			label1.Text = "Username:";
			// 
			// showpwd
			// 
			showpwd.AutoSize = true;
			showpwd.Location = new Point(417, 358);
			showpwd.Margin = new Padding(4, 5, 4, 5);
			showpwd.Name = "showpwd";
			showpwd.Size = new Size(164, 29);
			showpwd.TabIndex = 4;
			showpwd.Text = "Show password";
			showpwd.UseVisualStyleBackColor = true;
			showpwd.CheckedChanged += showpwd_CheckedChanged;
			// 
			// register
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(663, 568);
			Controls.Add(showpwd);
			Controls.Add(label6);
			Controls.Add(registerButton);
			Controls.Add(txtConfirmpwd);
			Controls.Add(txtPassword);
			Controls.Add(label5);
			Controls.Add(linktoLogin);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(txtUsername);
			Controls.Add(label1);
			Margin = new Padding(4, 5, 4, 5);
			Name = "register";
			Text = "register";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label6;
		private Button registerButton;
		private TextBox txtConfirmpwd;
		private TextBox txtPassword;
		private Label label5;
		private LinkLabel linktoLogin;
		private Label label4;
		private Label label3;
		private Label label2;
		private TextBox txtUsername;
		private Label label1;
		private CheckBox showpwd;
	}
}