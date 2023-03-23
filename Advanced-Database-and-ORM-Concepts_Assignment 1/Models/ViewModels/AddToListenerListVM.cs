namespace Advanced_Database_and_ORM_Concepts_Assignment_1.Models.ViewModels
{
    public class AddToListenerListVM
    {
        public Podcast Podcast { get; set; }
        public List<ListenerList> ListenerLists { get; set; } = new List<ListenerList>();
    }
}
