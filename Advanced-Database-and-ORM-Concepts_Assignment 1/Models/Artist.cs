using System.ComponentModel.DataAnnotations;

namespace Advanced_Database_and_ORM_Concepts_Assignment_1.Models
{
    public class Artist
    {
        public int Id { get; set; }


        [Required(AllowEmptyStrings = false)]
        [StringLength(20, ErrorMessage = "Must be betweeen 3 and 20 characters", MinimumLength = 3)]
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
