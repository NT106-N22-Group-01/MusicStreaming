using Mpv.NET.Player;

namespace MusicStreaming.Player.mpvWrapper
{
	internal class mpvWrapper
	{
		private MpvPlayer mpvPlayer;

		public void Play(string url, int Volume, string token = "")
		{
			Stop();

			mpvPlayer = new MpvPlayer();
			mpvPlayer.API.SetPropertyString("http-header-fields", $"Authorization:  Bearer {token}");
			mpvPlayer.API.SetPropertyString("audio-display", "no");
			mpvPlayer.API.SetPropertyString("video", "no");
			SetVolume(Volume);
			mpvPlayer.Load(url);
			mpvPlayer.Resume();
		}

		public void TogglePauseResume()
		{
			if (mpvPlayer != null)
			{
				if (mpvPlayer.IsPlaying)
				{
					mpvPlayer.Pause();
				}
				else
				{
					mpvPlayer.Resume();
				}
			}
		}

		public void SetVolume(int Volume)
		{
			mpvPlayer.Volume = Volume;
		}

		public void SetMute(bool Mute)
		{
			mpvPlayer.API.SetPropertyString("mute", Mute ? "yes" : "no");
		}

		public void Stop()
		{
			mpvPlayer?.Stop();
			mpvPlayer?.Dispose();
		}
	}
}
