using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;

namespace Advanced_Database_and_ORM_Concepts_Assignment_1.Models.ViewModels
{
    public class SongAddListVM
    {
        public HashSet<SelectListItem> AvailableSongs { get; set; } = new HashSet<SelectListItem>();
        public int SongId { get; set; }
        public HashSet<SelectListItem> Playlists { get; set; } = new HashSet<SelectListItem>();
        public int SelectedPlaylistId { get; set; }

        public void PopulateLists(IEnumerable<Playlist> playlists, IEnumerable<Song> songs)
        {
            foreach (Playlist p in playlists)
            {
                Playlists.Add(new SelectListItem(p.Name, p.Id.ToString()));
            }

            foreach(Song s in songs)
            {
                AvailableSongs.Add(new SelectListItem(s.Title, s.Id.ToString()));
            }
        }
        public SongAddListVM(ICollection<Playlist> playlists, ICollection<Song> songs)
        {
            PopulateLists(playlists, songs);
        }
        public SongAddListVM()
        {

        }
    }
}
