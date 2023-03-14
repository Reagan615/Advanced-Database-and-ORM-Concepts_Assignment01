namespace Advanced_Database_and_ORM_Concepts_Assignment_1.Models
{
    public class PlaylistDetails
    {
        public Playlist Playlist { get; set; }
        public int TotalRuntimeSeconds { get; set; }
        public int NumSongs { get; set; }
        public List<SongDetails> SongDetails { get; set; }
    }
}
