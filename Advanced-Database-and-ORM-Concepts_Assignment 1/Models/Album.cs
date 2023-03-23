using System.ComponentModel.DataAnnotations;

namespace Advanced_Database_and_ORM_Concepts_Assignment_1.Models
{
    public class Album
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(20, ErrorMessage = "Must be betweeen 3 and 20 characters", MinimumLength = 3)]
        public string Title { get; set; }

        public virtual HashSet<Song> Songs { get; set; } = new HashSet<Song>();
        public Album()
        {

        }
        public Album(string title)
        {

            Title = title;
        }
    }
}
