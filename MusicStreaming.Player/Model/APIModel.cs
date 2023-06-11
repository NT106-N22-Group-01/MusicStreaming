namespace MusicStreaming.Player.Model
{
	public class SongQueryModel
	{
		public int Id { get; set; }
		public int artist_id { get; set; }
		public string Artist { get; set; }
		public int album_id { get; set; }
		public string Album { get; set; }
		public string Title { get; set; }
		public int Track { get; set; }
		public string Format { get; set; }
		public int View { get; set; }
		public int Duration { get; set; }
	}

	public class ArtistModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	public class AlbumModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
