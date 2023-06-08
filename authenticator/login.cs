using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace authenticator
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            password.UseSystemPasswordChar = true;
        }        
        SqlConnection con = new SqlConnection("Data Source = ACER\\SQLEXPRESS; Initial Catalog = AUTHENTICATION; Integrated Security = True");

        public void MaintainState()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                MaintainState();
                SqlCommand command = new SqlCommand("SELECT sPASSWORD FROM INFORMATION WHERE sUSERNAME=@usr", con);
                command.Parameters.AddWithValue("@usr", username.Text);
                
                object result = command.ExecuteScalar();
                con.Close();
                if (result != null)
                {
                    string decryptedPass = security.Decrypt(result.ToString());
                    if (decryptedPass == password.Text)
                    {
                        MessageBox.Show("Successfully login");
                    }
                    else
                    {
                        MessageBox.Show("error");
                    }                    
                }                                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void linktoRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            register register = new register();
            register.Show();
            this.Hide();
        }

        private void showpwd_CheckedChanged(object sender, EventArgs e)
        {
            if (showpwd.Checked)
            {
                password.UseSystemPasswordChar = false;
            }
            else
            {
                password.UseSystemPasswordChar = true;
            }
        }
    }
}
