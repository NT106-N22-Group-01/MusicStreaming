using System.Text;
using System.Text.Json;
using MusicStreaming.Config;

namespace MusicStreaming
{
	public partial class fmLogin : Form
	{
		private HttpClient httpClient;

		public fmLogin()
		{
			InitializeComponent();
			httpClient = new HttpClient();
			txtPassword.UseSystemPasswordChar = true;
		}

		private async void loginButton_Click(object sender, EventArgs e)
		{
			var username = txtUername.Text;
			var password = txtPassword.Text;

			if (!Common.ValidateInput(username, password))
				return;

			var loginRequest = new
			{
				username,
				password
			};

			var json = JsonSerializer.Serialize(loginRequest);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			try
			{
				var response = await httpClient.PostAsync($"{Config.Config.ApiBaseUrl}/v1/login/token/", content);
				if (response.IsSuccessStatusCode)
				{
					string token = await response.Content.ReadAsStringAsync();
					MessageBox.Show("Login successful!");
				}
				else
				{
					MessageBox.Show("Login failed. Please check your credentials.");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"An error occurred: {ex.Message}");
			}
		}

		private void linktoRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var register = new fmRegister();
			register.Show();
			this.Hide();
		}

		private void showpwd_CheckedChanged(object sender, EventArgs e)
		{
			if (showpwd.Checked)
			{
				txtPassword.UseSystemPasswordChar = false;
			}
			else
			{
				txtPassword.UseSystemPasswordChar = true;
			}
		}
	}
}
