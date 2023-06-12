using System.Text;
using System.Text.Json;

namespace MusicStreaming.Auth
{
	public partial class fmRegister : Form
	{
		private HttpClient httpClient;

		public fmRegister()
		{
			InitializeComponent();
			txtPassword.UseSystemPasswordChar = true;
			txtConfirmpwd.UseSystemPasswordChar = true;
			httpClient = new HttpClient();
		}

		private async void registerButton_Click(object sender, EventArgs e)
		{
			var username = txtUsername.Text;
			var password = txtPassword.Text;
			var comfirmPassword = txtConfirmpwd.Text;

			if (!Common.ValidateInput(username, password))
				return;

			if (!Common.IsValidPassword(password))
				return;

			if (comfirmPassword != password)
			{
				MessageBox.Show("Comfirm Password and Password is different");
				return;
			}

			var registerRequest = new
			{
				username,
				password
			};

			string json = JsonSerializer.Serialize(registerRequest);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			try
			{
				var response = await httpClient.PostAsync($"{Config.Config.ApiBaseUrl}/v1/register/token/", content);

				if (response.IsSuccessStatusCode)
				{
					string token = await response.Content.ReadAsStringAsync();
					MessageBox.Show("Registration successful!");
				}
				else
				{
					MessageBox.Show("Registration failed. Please try again.");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"An error occurred: {ex.Message}");
			}

		}

		private void showpwd_CheckedChanged(object sender, EventArgs e)
		{
			if (showpwd.Checked)
			{
				txtPassword.UseSystemPasswordChar = false;
				txtConfirmpwd.UseSystemPasswordChar = false;
			}
			else
			{
				txtPassword.UseSystemPasswordChar = true;
				txtConfirmpwd.UseSystemPasswordChar = true;
			}
		}

		private void linktoLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			fmLogin login = new fmLogin();
			login.Show();
			this.Hide();
		}


	}
}
