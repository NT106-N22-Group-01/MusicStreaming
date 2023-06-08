using Microsoft.VisualBasic.ApplicationServices;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace authenticator
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
            password.UseSystemPasswordChar = true;
            confirmpwd.UseSystemPasswordChar = true;
        }
        SqlConnection con = new SqlConnection("Data Source = ACER\\SQLEXPRESS; Initial Catalog = AUTHENTICATION; Integrated Security = True");

        public void MaintainState()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public static bool IsValidPassword(string password)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_.]).{8,24}$";
            if (Regex.IsMatch(password, pattern))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Password Requirements:\r\n\t" +
                    "- Length between 8 and 24\r\n\t" +
                    "- Include lowercase\r\n\t" +
                    "- Include uppercase\r\n\t" +
                    "- Include digit\r\n\t" +
                    "- Include special character\r\n");
                return false;
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {

            try
            {
                MaintainState();
                if (!string.IsNullOrEmpty(username.Text) && IsValidPassword(password.Text)) 
                
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO INFORMATION VALUES (@usr, @pwd)", con);
                    if (confirmpwd.Text == password.Text)
                    {
                        cmd.Parameters.AddWithValue("@usr", username.Text);
                        string encPass = security.Encrypt(password.Text);
                        cmd.Parameters.AddWithValue("@pwd", encPass);
                        int rowAffected = cmd.ExecuteNonQuery();   

                        if (rowAffected > 0)
                        {
                            MessageBox.Show("Successfully registered.");
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unsuccessfully confirmed.");
                        password.Clear();
                        confirmpwd.Clear();
                    }
                }

                else
                {
                    MessageBox.Show("Somethings failed. Check again.", "Note", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    password.Clear();
                    confirmpwd.Clear();
                    return;
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void showpwd_CheckedChanged(object sender, EventArgs e)
        {
            if (showpwd.Checked)
            {
                password.UseSystemPasswordChar = false;
                confirmpwd.UseSystemPasswordChar = false;
            }
            else
            {
                password.UseSystemPasswordChar = true;
                confirmpwd.UseSystemPasswordChar = true;
            }
        }

        private void linktoLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide();
        }


    }
}
