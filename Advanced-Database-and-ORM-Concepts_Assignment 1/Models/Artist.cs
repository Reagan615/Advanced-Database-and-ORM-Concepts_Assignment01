namespace Advanced_Database_and_ORM_Concepts_Assignment_1.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual HashSet<SongContributor> SongContributors { get; set; } = new HashSet<SongContributor>();
        public Artist()
        {

        }
        public Artist(string name)
        {

            Name = name;
        }
    }
}
