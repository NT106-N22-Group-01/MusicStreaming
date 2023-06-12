using System;
using MusicStreaming.Player.Model;

namespace MusicStreaming.Player.Views
{
	public partial class BXH : UserControl
	{
		public BXH(List<SongQueryModel> songs)
		{
			InitializeComponent();
			PopulateSong(songs);
		}

		private async Task PopulateSong(List<SongQueryModel> songs)
		{
			listViewSongs.Items.Clear();
			foreach (SongQueryModel song in songs)
			{
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
	}
}
