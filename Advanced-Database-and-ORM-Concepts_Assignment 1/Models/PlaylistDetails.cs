using System.ComponentModel.DataAnnotations;

namespace Advanced_Database_and_ORM_Concepts_Assignment_1.Models
{
    public class PlaylistDetails
    {
        public Playlist Playlist { get; set; }

        [Display(Name = "Total Runtime Seconds")]
        public int TotalRuntimeSeconds { get; set; }

        [Display(Name = "Total Number Of Songs")]
        public int NumSongs { get; set; }
        public List<SongDetails> SongDetails { get; set; }
    }
}
