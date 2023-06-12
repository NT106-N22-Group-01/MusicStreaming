namespace MusicStreaming.Player.Views
{
	partial class BXH
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			listViewSongs = new ListView();
			columnNo = new ColumnHeader();
			columnSongName = new ColumnHeader();
			columnSongArtist = new ColumnHeader();
			columnSongAlbum = new ColumnHeader();
			columnSongDuration = new ColumnHeader();
			columnSongView = new ColumnHeader();
			columnSongFormat = new ColumnHeader();
			SuspendLayout();
			// 
			// listViewSongs
			// 
			listViewSongs.BackColor = Color.FromArgb(37, 38, 44);
			listViewSongs.Columns.AddRange(new ColumnHeader[] { columnNo, columnSongName, columnSongArtist, columnSongAlbum, columnSongDuration, columnSongView, columnSongFormat });
			listViewSongs.Dock = DockStyle.Fill;
			listViewSongs.Font = new Font("Open Sans", 10F, FontStyle.Bold, GraphicsUnit.Point);
			listViewSongs.ForeColor = Color.White;
			listViewSongs.FullRowSelect = true;
			listViewSongs.Location = new Point(0, 0);
			listViewSongs.Name = "listViewSongs";
			listViewSongs.Size = new Size(1241, 689);
			listViewSongs.TabIndex = 5;
			listViewSongs.UseCompatibleStateImageBehavior = false;
			listViewSongs.View = View.Details;
			// 
			// columnNo
			// 
			columnNo.Text = "No";
			// 
			// columnSongName
			// 
			columnSongName.Text = "Name";
			columnSongName.Width = 350;
			// 
			// columnSongArtist
			// 
			columnSongArtist.Text = "Artist";
			columnSongArtist.Width = 210;
			// 
			// columnSongAlbum
			// 
			columnSongAlbum.Text = "Album";
			columnSongAlbum.Width = 210;
			// 
			// columnSongDuration
			// 
			columnSongDuration.Text = "Duration";
			columnSongDuration.Width = 120;
			// 
			// columnSongView
			// 
			columnSongView.Text = "View";
			columnSongView.Width = 100;
			// 
			// columnSongFormat
			// 
			columnSongFormat.Text = "Format";
			columnSongFormat.Width = 90;
			// 
			// BXH
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(listViewSongs);
			Name = "BXH";
			Size = new Size(1241, 689);
			ResumeLayout(false);
		}

		#endregion

		private ListView listViewSongs;
		private ColumnHeader columnNo;
		private ColumnHeader columnSongName;
		private ColumnHeader columnSongArtist;
		private ColumnHeader columnSongAlbum;
		private ColumnHeader columnSongDuration;
		private ColumnHeader columnSongView;
		private ColumnHeader columnSongFormat;
	}
}
