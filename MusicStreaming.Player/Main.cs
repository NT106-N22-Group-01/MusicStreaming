using Mpv.NET.Player;
using MusicStreaming.Player;
using MusicStreaming.Player.Model;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;

namespace MusicStreaming
{
	public partial class Main : Form
	{
		private int borderSize = 2;
		private Size initialFormSize;

		private List<SongQueryModel> songs;
		private List<SongQueryModel> shuffledSongs;
		private Dictionary<int, ArtistModel> artists = new Dictionary<int, ArtistModel>();
		private Dictionary<int, AlbumModel> albums = new Dictionary<int, AlbumModel>();
		private int? selectedArtistID;
		private int? selectedAlbumID;
		private Random rng;

		public MpvPlayer mpvPlayer;
		private SongQueryModel currentSong;
		private bool isPlaying = false;
		private bool isMute = false;
		private bool isRepeat = false;
		private bool isShuffle = false;

		public Main(string Token)
		{
			InitializeComponent();
			TokenManager.AccessToken = Token;
		}

		#region Form Overload
		//Drag Form
		[DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
		private extern static void ReleaseCapture();
		[DllImport("user32.DLL", EntryPoint = "SendMessage")]
		private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
		private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
		{
			ReleaseCapture();
			SendMessage(this.Handle, 0x112, 0xf012, 0);
		}
		//Overridden methods
		protected override void WndProc(ref Message m)
		{
			const int WM_NCCALCSIZE = 0x0083;//Standar Title Bar - Snap Window
			const int WM_SYSCOMMAND = 0x0112;
			const int SC_MINIMIZE = 0xF020; //Minimize form (Before)
			const int SC_RESTORE = 0xF120; //Restore form (Before)
			const int WM_NCHITTEST = 0x0084;//Win32, Mouse Input Notification: Determine what part of the window corresponds to a point, allows to resize the form.
			const int resizeAreaSize = 10;
			#region Form Resize
			// Resize/WM_NCHITTEST values
			const int HTCLIENT = 1; //Represents the client area of the window
			const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
			const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
			const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
			const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
			const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
			const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
			const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
			const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right
			///<Doc> More Information: https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest </Doc>
			if (m.Msg == WM_NCHITTEST)
			{ //If the windows m is WM_NCHITTEST
				base.WndProc(ref m);
				if (this.WindowState == FormWindowState.Normal)//Resize the form if it is in normal state
				{
					if ((int)m.Result == HTCLIENT)//If the result of the m (mouse pointer) is in the client area of the window
					{
						Point screenPoint = new Point(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
						Point clientPoint = this.PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          
						if (clientPoint.Y <= resizeAreaSize)//If the pointer is at the top of the form (within the resize area- X coordinate)
						{
							if (clientPoint.X <= resizeAreaSize) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
								m.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
							else if (clientPoint.X < (this.Size.Width - resizeAreaSize))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
								m.Result = (IntPtr)HTTOP; //Resize vertically up
							else //Resize diagonally to the right
								m.Result = (IntPtr)HTTOPRIGHT;
						}
						else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
						{
							if (clientPoint.X <= resizeAreaSize)//Resize horizontally to the left
								m.Result = (IntPtr)HTLEFT;
							else if (clientPoint.X > (this.Width - resizeAreaSize))//Resize horizontally to the right
								m.Result = (IntPtr)HTRIGHT;
						}
						else
						{
							if (clientPoint.X <= resizeAreaSize)//Resize diagonally to the left
								m.Result = (IntPtr)HTBOTTOMLEFT;
							else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) //Resize vertically down
								m.Result = (IntPtr)HTBOTTOM;
							else //Resize diagonally to the right
								m.Result = (IntPtr)HTBOTTOMRIGHT;
						}
					}
				}
				return;
			}
			#endregion
			//Remove border and keep snap window
			if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
			{
				return;
			}
			//Keep form size when it is minimized and restored. Since the form is resized because it takes into account the size of the title bar and borders.
			if (m.Msg == WM_SYSCOMMAND)
			{
				/// <see cref="https://docs.microsoft.com/en-us/windows/win32/menurc/wm-syscommand"/>
				/// Quote:
				/// In WM_SYSCOMMAND messages, the four low - order bits of the wParam parameter 
				/// are used internally by the system.To obtain the correct result when testing 
				/// the value of wParam, an application must combine the value 0xFFF0 with the 
				/// wParam value by using the bitwise AND operator.
				int wParam = (m.WParam.ToInt32() & 0xFFF0);
				if (wParam == SC_MINIMIZE)  //Before
					initialFormSize = this.ClientSize;
				if (wParam == SC_RESTORE)// Restored form(Before)
					this.Size = initialFormSize;
			}
			base.WndProc(ref m);
		}
		//Private methods
		private void AdjustForm()
		{
			switch (this.WindowState)
			{
				case FormWindowState.Maximized: //Maximized form (After)
					this.Padding = new Padding(8, 8, 8, 8);
					break;
				case FormWindowState.Normal: //Restored form (After)
					if (this.Padding.Top != borderSize)
						this.Padding = new Padding(borderSize);
					break;
			}
		}
		private void btnExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void Main_Resize(object sender, EventArgs e)
		{
			AdjustForm();
			panelContainer.Invalidate();
		}

		private void btnMax_Click(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Normal)
			{
				initialFormSize = this.ClientSize;
				this.WindowState = FormWindowState.Maximized;
			}
			else
			{
				this.WindowState = FormWindowState.Normal;
				this.Size = initialFormSize;
			}
		}

		private void btnMin_Click(object sender, EventArgs e)
		{
			initialFormSize = Size;
			this.WindowState = FormWindowState.Minimized;
		}
		#endregion

		private void ActiveMenu(Button btn)
		{
			btn.BackColor = Color.FromArgb(255, 128, 0);
		}

		private void btnOpen_Click(object sender, EventArgs e)
		{
		}

		private void btnHome_Click(object sender, EventArgs e)
		{
		}

		private void btnCate_Click(object sender, EventArgs e)
		{
			ActiveMenu(sender as Button);
		}

		private void btnTop_Click(object sender, EventArgs e)
		{
			ActiveMenu(sender as Button);
		}

		private void btnBXH_Click(object sender, EventArgs e)
		{
			ActiveMenu(sender as Button);
		}

		private void btnPlaylist_Click(object sender, EventArgs e)
		{
			ActiveMenu(sender as Button);
		}

		#region Form Load Close Event
		private void Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			Stop();
		}

		private async void Main_Load(object sender, EventArgs e)
		{
			await PopulateModels("");
			await PopulateArtistNames();
			await PopulateAlbumName();
			await PopulateSong();
		}
		#endregion

		#region Trackbar Control
		private void trackBar_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && isPlaying)
			{
				var pos = TimeSpan.FromMilliseconds(trackBar.Value);
				mpvPlayer.SeekAsync(pos);
			}
		}

		private void trackBar_MouseUp(object sender, MouseEventArgs e)
		{
			/*			int trackBarWidth = trackbarVolume.Width - 20;
						int duration = (int)mpvWrapper.mpvPlayer.Duration.TotalMilliseconds;
						int newDuration = duration * e.X / trackBarWidth;

						newDuration = Math.Max(0, Math.Min(duration, newDuration));

						trackbarVolume.Value = newDuration;
						var pos = TimeSpan.FromMilliseconds(newDuration);
						mpvWrapper.mpvPlayer.SeekAsync(pos);*/
		}

		private void trackbarVolume_MouseUp(object sender, MouseEventArgs e)
		{
			int trackBarWidth = trackbarVolume.Width - 20;
			int newVolume = 100 * e.X / trackBarWidth;

			// Ensure the new volume is within the valid range of 0 to 100
			newVolume = Math.Max(0, Math.Min(100, newVolume));

			trackbarVolume.Value = newVolume;
			SetVolume(trackbarVolume.Value);
		}

		private void trackbarVolume_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				SetVolume(trackbarVolume.Value);
			}
		}
		#endregion

		#region Control Button
		private void btnPlay_Click(object sender, EventArgs e)
		{
			if (isPlaying)
			{
				TogglePauseResume();
			}
		}

		private void iconButtonMute_Click(object sender, EventArgs e)
		{
			if (isMute == false)
			{
				SetMute(true);
				iconButtonMute.IconChar = FontAwesome.Sharp.IconChar.VolumeMute;
				isMute = true;
			}
			else
			{
				SetMute(false);
				iconButtonMute.IconChar = FontAwesome.Sharp.IconChar.VolumeHigh;
				isMute = false;
			}
		}

		private void btbRepeat_Click(object sender, EventArgs e)
		{
			if (isRepeat == false)
			{
				btbRepeat.BackColor = Color.MediumVioletRed;
				isRepeat = true;
			}
			else
			{
				btbRepeat.BackColor = Color.Black;
				isRepeat = false;
			}
		}

		private void btnShuffle_Click(object sender, EventArgs e)
		{
			if (isShuffle == false)
			{
				ShufflePlaylist();
				btnShuffle.BackColor = Color.MediumVioletRed;
				isShuffle = true;
			}
			else
			{
				btnShuffle.BackColor = Color.Black;
				isShuffle = false;
			}
		}

		private void pbSong_Click(object sender, EventArgs e)
		{
			PictureBox clickedPictureBox = (PictureBox)sender;

			Form floatingPanelForm = new Form();
			PictureBox pictureBox = new PictureBox();

			pictureBox.Dock = DockStyle.Fill;
			pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
			pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
			var imageURL = $"{Config.Config.ApiBaseUrl}/v1/album/{currentSong.album_id}/artwork";
			pictureBox.Image = GetImageWithHeaders(imageURL, TokenManager.AccessToken);

			floatingPanelForm.ClientSize = pictureBox.Image.Size;
			floatingPanelForm.Controls.Add(pictureBox);

			floatingPanelForm.ShowDialog();
		}
		#endregion

		#region List View Event
		private async void listViewArtist_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listViewArtist.SelectedItems.Count <= 0)
			{
				return;
			}
			if (listViewArtist.SelectedItems[0].Text == "All")
			{
				selectedArtistID = null;
				await PopulateAlbumName();
				await PopulateSong();
			}
			else
			{
				ArtistModel selectedArtist = (ArtistModel)listViewArtist.SelectedItems[0].Tag;
				selectedArtistID = selectedArtist.Id;
				await PopulateAlbumName(selectedArtistID);
				await PopulateSong(selectedArtistID);
			}
		}

		private async void listViewAlbum_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listViewAlbum.SelectedItems.Count <= 0)
			{
				return;
			}
			if (listViewAlbum.SelectedItems[0].Text == "All")
			{
				selectedAlbumID = null;
				await PopulateSong(selectedArtistID);
			}
			else
			{
				AlbumModel selectedAlbum = (AlbumModel)listViewAlbum.SelectedItems[0].Tag;
				selectedAlbumID = selectedAlbum.Id;
				await PopulateSong(selectedArtistID, selectedAlbumID);
			}
		}

		private void listViewSongs_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (listViewSongs.SelectedItems.Count > 0)
			{
				ListViewItem selectedItem = listViewSongs.SelectedItems[0];

				SongQueryModel song = (SongQueryModel)selectedItem.Tag;
				currentSong = song;

				Play(song);
			}
		}
		#endregion

		#region CommonMethod
		private async Task PopulateModels(string query = "")
		{
			songs = await GetSongsFromApi(query);
			artists.Clear();
			albums.Clear();

			if (songs != null)
			{
				foreach (var song in songs)
				{
					if (!artists.ContainsKey(song.artist_id))
					{
						artists.Add(song.artist_id, new ArtistModel { Id = song.artist_id, Name = song.Artist });
					}

					if (!albums.ContainsKey(song.album_id))
					{
						albums.Add(song.album_id, new AlbumModel { Id = song.album_id, Name = song.Album, ArtistID = song.artist_id });
					}
				}
			}
		}

		private async Task<List<SongQueryModel>> GetSongsFromApi(string query)
		{
			using (HttpClient client = new HttpClient())
			{
				try
				{
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenManager.AccessToken);
					string apiUrl = $"{Config.Config.ApiBaseUrl}/v1/search/?q={query}";
					HttpResponseMessage response = await client.GetAsync(apiUrl);

					if (response.IsSuccessStatusCode)
					{
						var apiResponse = await response.Content.ReadAsStringAsync();
						List<SongQueryModel> songs = JsonConvert.DeserializeObject<List<SongQueryModel>>(apiResponse);
						return songs;
					}
					else
					{
						MessageBox.Show("Failed to fetch songs from API.");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("An error occurred: " + ex.Message);
				}
			}

			return null;
		}

		private async Task PopulateArtistNames()
		{
			listViewArtist.Items.Clear();

			List<ArtistModel> allArtists = artists.Values.ToList();
			listViewArtist.Items.Add(new ListViewItem("All"));
			foreach (var artist in allArtists)
			{
				ListViewItem item = new ListViewItem(artist.Name);
				item.Tag = artist;
				listViewArtist.Items.Add(item);
			}
		}

		private async Task PopulateAlbumName(int? artistID = null)
		{
			listViewAlbum.Items.Clear();

			List<AlbumModel> allAlbum = albums.Values.ToList();
			listViewAlbum.Items.Add(new ListViewItem("All"));
			foreach (var album in allAlbum)
			{
				if (album.ArtistID != artistID && artistID != null)
					continue;
				ListViewItem item = new ListViewItem(album.Name);
				item.Tag = album;
				listViewAlbum.Items.Add(item);
			}
		}

		private async Task PopulateSong(int? artistID = null, int? albumID = null)
		{
			listViewSongs.Items.Clear();
			foreach (SongQueryModel song in songs)
			{
				if (song.artist_id != artistID && artistID != null)
					continue;
				if (song.album_id != albumID && albumID != null)
					continue;
				ListViewItem item = new ListViewItem(song.Track.ToString());
				item.SubItems.Add(song.Title);
				item.SubItems.Add(song.Artist);
				item.SubItems.Add(song.Album);
				item.SubItems.Add(TimeSpan.FromMilliseconds(song.Duration).ToString("mm\\:ss"));
				item.SubItems.Add(song.View.ToString());
				item.SubItems.Add(song.Format);

				item.Tag = song;

				listViewSongs.Items.Add(item);
			}
		}

		private void Play(SongQueryModel song)
		{
			var songURL = $"{Config.Config.ApiBaseUrl}/v1/file/{song.Id}";
			Play(songURL, trackbarVolume.Value, TokenManager.AccessToken);
			var imageURL = $"{Config.Config.ApiBaseUrl}/v1/album/{song.album_id}/artwork";
			pbSong.Image = GetImageWithHeaders(imageURL, TokenManager.AccessToken);

			var duration = TimeSpan.FromMilliseconds(song.Duration);
			var formattedDuration = duration.ToString("mm':'ss");
			if (lbMaxTime.InvokeRequired)
			{
				lbMaxTime.Invoke((MethodInvoker)(() =>
				{
					lbMaxTime.Text = formattedDuration;
				}));
			}
			else
			{
				lbMaxTime.Text = formattedDuration;
			}

			trackBar.MaxValue = song.Duration;
			trackBar.Value = 0;

			timer.Interval = 1000;
			timer.Tick += PositionTimer_Tick!;
			timer.Start();

			isPlaying = true;
			mpvPlayer.MediaFinished += MediaFinished_Event;
		}

		private SongQueryModel GetNextSong()
		{
			int currentIndex = songs.FindIndex(song => song.Id == currentSong.Id);
			int nextIndex = (currentIndex + 1) % songs.Count;
			var nextSong = songs[nextIndex];
			return nextSong;
		}

		private Image GetImageWithHeaders(string imageUrl, string bearerToken)
		{
			using (WebClient client = new WebClient())
			{
				client.Headers.Add("Authorization", $"Bearer {bearerToken}");

				byte[] imageData = client.DownloadData(imageUrl);

				using (MemoryStream memoryStream = new MemoryStream(imageData))
				{
					return Image.FromStream(memoryStream);
				}
			}
		}

		public void ShufflePlaylist()
		{
			shuffledSongs = new List<SongQueryModel>(songs);
			rng = new Random();

			int n = shuffledSongs.Count;
			while (n > 1)
			{
				n--;
				int k = rng.Next(n + 1);
				SongQueryModel temp = shuffledSongs[k];
				shuffledSongs[k] = shuffledSongs[n];
				shuffledSongs[n] = temp;
			}
		}
		#endregion

		#region Common Event
		private void MediaFinished_Event(object sender, EventArgs e)
		{
			if (isRepeat)
			{
				Play(currentSong);
			}
			else if (isShuffle)
			{
				SongQueryModel nextSong = shuffledSongs[0];
				shuffledSongs.RemoveAt(0);
				currentSong = nextSong;
				Play(currentSong);
			}	
			else
			{
				currentSong = GetNextSong();
				Play(currentSong);
			}

		}

		private void PositionTimer_Tick(object sender, EventArgs e)
		{
			if (!isPlaying)
				return;
			lbMinTime.Text = mpvPlayer.Position.ToString("mm':'ss");
			trackBar.Value = (int)mpvPlayer.Position.TotalMilliseconds;
		}
		#endregion

		#region MPVWrapper
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
		}
		#endregion
	}
}
