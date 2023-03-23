using System.ComponentModel.DataAnnotations;

namespace Advanced_Database_and_ORM_Concepts_Assignment_1.Models
{
    public class Song
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Must be betweeen 3 and 50 characters", MinimumLength = 3)]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Duration Seconds")]
        public int DurationSeconds { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
        public virtual HashSet<PlaylistSong> PlaylistSongs { get; set; } = new HashSet<PlaylistSong>();
        public virtual HashSet<SongContributor> SongContributors { get; set; } = new HashSet<SongContributor>();
        public Song()
        {

        }
        public Song(string title, int durationSeconds, int albumId)
        {

            Title = title;
            DurationSeconds = durationSeconds;
            AlbumId = albumId;
        }
    }
}
