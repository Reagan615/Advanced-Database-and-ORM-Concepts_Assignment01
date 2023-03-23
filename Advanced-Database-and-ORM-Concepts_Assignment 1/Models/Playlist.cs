using System.ComponentModel.DataAnnotations;

namespace Advanced_Database_and_ORM_Concepts_Assignment_1.Models
{
    public class Playlist
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(20, ErrorMessage = "Must be betweeen 3 and 20 characters", MinimumLength = 3)]
        public string Name { get; set; }
        public int UserId { get; set; }
        public HashSet<PlaylistSong> PlaylistSongs { get; set; } = new HashSet<PlaylistSong>();
        public Playlist()
        {

        }
        public Playlist(string name, int userId)
        {

            Name = name;
            UserId = userId;
        }
    }
}
