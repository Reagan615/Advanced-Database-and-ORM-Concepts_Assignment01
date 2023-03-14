namespace Advanced_Database_and_ORM_Concepts_Assignment_1.Models
{
    public class LibrarySong
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SongId { get; set; }
        public LibrarySong()
        {

        }
        public LibrarySong(int userId, int songId)
        {

            UserId = userId;
            SongId = songId;
        }
    }
}
