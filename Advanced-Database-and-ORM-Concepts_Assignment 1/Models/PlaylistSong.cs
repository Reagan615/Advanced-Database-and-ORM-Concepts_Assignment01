using System.ComponentModel.DataAnnotations;

namespace Advanced_Database_and_ORM_Concepts_Assignment_1.Models
{
    public class PlaylistSong
    {
        public int Id { get; set; }
        public int SongId { get; set; }
        public int PlaylistId { get; set; }
        public Song Song { get; set; }
        public Playlist Playlist { get; set; }

        [Display(Name = "Time Added")]
        public DateTime TimeAdded { get; set; }
        public PlaylistSong()
        {

        }
        public PlaylistSong(int songId, int playlistId, DateTime timeAdded)
        {

            SongId = songId;
            PlaylistId = playlistId;
            TimeAdded = timeAdded;
        }
    }
}
