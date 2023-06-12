using MusicStreaming.Player;
using System.Resources;

namespace MusicStreaming.Auth
{
	partial class fmLogin
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			label4 = new Label();
			label5 = new Label();
			label1 = new Label();
			label2 = new Label();
			txtUername = new TextBox();
			txtPassword = new TextBox();
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
			label4.Location = new Point(256, 25);
			label4.Margin = new Padding(4, 0, 4, 0);
			label4.Name = "label4";
			label4.Size = new Size(155, 65);
			label4.TabIndex = 16;
			label4.Text = "Login";
			label4.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			label5.BackColor = SystemColors.Control;
			label5.BorderStyle = BorderStyle.FixedSingle;
			label5.Location = new Point(57, 125);
			label5.Margin = new Padding(4, 0, 4, 0);
			label5.Name = "label5";
			label5.Size = new Size(548, 0);
			label5.TabIndex = 18;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(71, 167);
			label1.Margin = new Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new Size(126, 32);
			label1.TabIndex = 19;
			label1.Text = "Username:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			label2.Location = new Point(71, 250);
			label2.Margin = new Padding(4, 0, 4, 0);
			label2.Name = "label2";
			label2.Size = new Size(116, 32);
			label2.TabIndex = 20;
			label2.Text = "Password:";
			// 
			// txtUername
			// 
			txtUername.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			txtUername.Location = new Point(286, 167);
			txtUername.Margin = new Padding(4, 5, 4, 5);
			txtUername.Name = "txtUername";
			txtUername.Size = new Size(284, 37);
			txtUername.TabIndex = 1;
			// 
			// txtPassword
			// 
			txtPassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			txtPassword.Location = new Point(286, 250);
			txtPassword.Margin = new Padding(4, 5, 4, 5);
			txtPassword.Name = "txtPassword";
			txtPassword.Size = new Size(284, 37);
			txtPassword.TabIndex = 2;
			// 
			// loginButton
			// 
			loginButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
			loginButton.Location = new Point(260, 358);
			loginButton.Margin = new Padding(4, 5, 4, 5);
			loginButton.Name = "loginButton";
			loginButton.Size = new Size(143, 50);
			loginButton.TabIndex = 4;
			loginButton.Text = "Sign in";
			loginButton.UseVisualStyleBackColor = true;
			loginButton.Click += loginButton_Click;
			// 
			// label3
			// 
			label3.BackColor = SystemColors.Control;
			label3.BorderStyle = BorderStyle.FixedSingle;
			label3.Location = new Point(57, 433);
			label3.Margin = new Padding(4, 0, 4, 0);
			label3.Name = "label3";
			label3.Size = new Size(548, 0);
			label3.TabIndex = 24;
			// 
			// linktoRegister
			// 
			linktoRegister.AutoSize = true;
			linktoRegister.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
			linktoRegister.Location = new Point(149, 467);
			linktoRegister.Margin = new Padding(4, 0, 4, 0);
			linktoRegister.Name = "linktoRegister";
			linktoRegister.Size = new Size(374, 31);
			linktoRegister.TabIndex = 5;
			linktoRegister.TabStop = true;
			linktoRegister.Text = "Haven't an account? Register now";
			linktoRegister.TextAlign = ContentAlignment.MiddleCenter;
			linktoRegister.LinkClicked += linktoRegister_LinkClicked;
			// 
			// showpwd
			// 
			showpwd.AutoSize = true;
			showpwd.Location = new Point(417, 325);
			showpwd.Margin = new Padding(4, 5, 4, 5);
			showpwd.Name = "showpwd";
			showpwd.Size = new Size(162, 29);
			showpwd.TabIndex = 3;
			showpwd.Text = "Show Password";
			showpwd.UseVisualStyleBackColor = true;
			showpwd.CheckedChanged += showpwd_CheckedChanged;
			// 
			// fmLogin
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ActiveCaption;
			ClientSize = new Size(663, 535);
			Controls.Add(showpwd);
			Controls.Add(linktoRegister);
			Controls.Add(label3);
			Controls.Add(loginButton);
			Controls.Add(txtPassword);
			Controls.Add(txtUername);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(label5);
			Controls.Add(label4);
			Margin = new Padding(4, 5, 4, 5);
			Name = "fmLogin";
			Text = "Music Streaming";
			ResumeLayout(false);
			PerformLayout();
			Icon = (Icon)resources.GetObject("$this.Icon");
		}

		#endregion

		private Label label4;
		private Label label5;
		private Label label1;
		private Label label2;
		private TextBox txtUername;
		private TextBox txtPassword;
		private Button loginButton;
		private Label label3;
		private LinkLabel linktoRegister;
		private CheckBox showpwd;
	}
}