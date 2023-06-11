using MusicStreaming;

namespace MusicStreaming.Player
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			Application.Run(new Main("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE2OTE4NjgwMDAsImlhdCI6MTY4NjUxMTIwMH0.IcNR7Gsx50kKtFoOBhpqVDyEd7RJLRjX1BTqOcykWt4"));
		}
	}
}