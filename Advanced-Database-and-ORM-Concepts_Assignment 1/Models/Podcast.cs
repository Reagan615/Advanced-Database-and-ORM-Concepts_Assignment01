using System.ComponentModel.DataAnnotations;

namespace Advanced_Database_and_ORM_Concepts_Assignment_1.Models
{
    public class Podcast
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(20, ErrorMessage = "Must be betweeen 3 and 20 characters", MinimumLength = 3)]
        [Display(Name = "Podcast Title")]
        public string PodcastTitle { get; set; }
        public virtual HashSet<Artist> Artists { get; set; } = new HashSet<Artist>();
        public virtual List<Episode> Episodes { get; set; } = new List<Episode>();
        public virtual HashSet<ListenerList> ListenerLists { get; set; } = new HashSet<ListenerList>();
        public Podcast() { }
        public Podcast(string podcastTitle)
        {
            PodcastTitle = podcastTitle;
        }
    }
}
