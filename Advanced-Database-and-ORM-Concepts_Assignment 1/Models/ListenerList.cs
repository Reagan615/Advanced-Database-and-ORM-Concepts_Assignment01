using System.ComponentModel.DataAnnotations;

namespace Advanced_Database_and_ORM_Concepts_Assignment_1.Models
{
    public class ListenerList
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(20, ErrorMessage = "Must be betweeen 3 and 20 characters", MinimumLength = 3)]
        [Display(Name = "Listener List  Name")]
        public string ListenerListName { get; set; }
        public virtual HashSet<Podcast> Podcasts { get; set; } = new HashSet<Podcast>();
        public ListenerList() { }
        public ListenerList(string listenerListName)
        {
            ListenerListName = listenerListName;
        }
    }
}
