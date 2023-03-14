namespace Advanced_Database_and_ORM_Concepts_Assignment_1.Models
{
    public class SongContributor
    {
        public int Id { get; set; }
        public Song Song { get; set; }
        public Artist Artist { get; set; }
        public int ArtistId { get; set; }
        public int SongId { get; set; }
        public SongContributor()
        {

        }
        public SongContributor(int artistId, int songId)
        {

            ArtistId = artistId;
            SongId = songId;
        }
    }
}
