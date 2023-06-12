using System.Text.RegularExpressions;

namespace MusicStreaming.Auth
{
	public static class Common
	{
		public static bool ValidateInput(string username, string password)
		{
			if (string.IsNullOrWhiteSpace(username))
			{
				MessageBox.Show("Please enter a username.");
				return false;
			}

			if (username.Contains(" "))
			{
				MessageBox.Show("Username cannot contain spaces.");
				return false;
			}


			if (string.IsNullOrWhiteSpace(password))
			{
				MessageBox.Show("Please enter a password.");
				return false;
			}

			return true;
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
	}
}
