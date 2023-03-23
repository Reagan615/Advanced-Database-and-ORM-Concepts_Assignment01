using System.ComponentModel.DataAnnotations;

namespace Advanced_Database_and_ORM_Concepts_Assignment_1.Models
{
    public class Episode
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Must be betweeen 3 and 50 characters", MinimumLength = 3)]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Air Date")]
        public DateTime AirDate { get; set; }

        private int _durationSeconds;

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Duration Seconds")]
        public int DurationSeconds
        {
            get { return _durationSeconds; }
            set
            {
                if (_durationSeconds < 0)
                {
                    throw new Exception("Duration Seconds cannot be negative");
                }
                else
                {
                    _durationSeconds = value;
                }

            }
        }

        public virtual HashSet<Artist> GuestArtists { get; set; } = new HashSet<Artist>();
        public Episode() { }
        public Episode(string title, int durationSeconds, DateTime airDate, HashSet<Artist> guestArtists)
        {
            Title = title;
            DurationSeconds = durationSeconds;
            AirDate = airDate;
            GuestArtists = guestArtists;
        }
    }
}
