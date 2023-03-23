using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Advanced_Database_and_ORM_Concepts_Assignment_1.Models;

namespace Advanced_Database_and_ORM_Concepts_Assignment_1.Data
{
    public class Advanced_Database_and_ORM_Concepts_Assignment_1Context : DbContext
    {
        public Advanced_Database_and_ORM_Concepts_Assignment_1Context (DbContextOptions<Advanced_Database_and_ORM_Concepts_Assignment_1Context> options)
            : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; } = default!;

        public DbSet<Artist> Artists { get; set; } = default!;
        public DbSet<LibrarySong> LibrarySongs { get; set; } = default!;
        public DbSet<Playlist> Playlists { get; set; } = default!;
        public DbSet<PlaylistSong> PlaylistSongs { get; set; } = default!;
        public DbSet<Song> Songs { get; set; } = default!;
        public DbSet<SongContributor> SongContributors { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Podcast> Podcast { get; set; } = default!;
        public DbSet<Episode> Episodes { get; set; } = default!;
        public DbSet<ListenerList> ListenerList { get; set; } = default!;

    }
}
