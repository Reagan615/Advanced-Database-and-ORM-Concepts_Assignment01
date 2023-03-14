using Advanced_Database_and_ORM_Concepts_Assignment_1.Models;
using Microsoft.EntityFrameworkCore;

namespace Advanced_Database_and_ORM_Concepts_Assignment_1.Data
{
    public class SeedData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            Advanced_Database_and_ORM_Concepts_Assignment_1Context context = new Advanced_Database_and_ORM_Concepts_Assignment_1Context
                (serviceProvider.GetRequiredService<DbContextOptions<Advanced_Database_and_ORM_Concepts_Assignment_1Context>>());

            context.Database.EnsureDeleted();
            context.Database.Migrate();

            Artist artist01 = new Artist("Whitney Houston");
            Artist artist02 = new Artist("Taylor Swift");
            Artist artist03 = new Artist("Mariah Carey");

            if (!context.Artists.Any())
            {

                context.Artists.Add(artist01);
                context.Artists.Add(artist02);
                context.Artists.Add(artist03);
            }
            await context.SaveChangesAsync();

            Album album01 = new Album("Whitney Houston");
            Album album02 = new Album("I look to you");
            Album album03 = new Album("Red");
            Album album04 = new Album("Lover");
            Album album05 = new Album("Emotions");
            Album album06 = new Album("Butterfly");
            if (!context.Albums.Any())
            {

                context.Albums.Add(album01);
                context.Albums.Add(album02);
                context.Albums.Add(album03);
                context.Albums.Add(album04);
                context.Albums.Add(album05);
                context.Albums.Add(album06);
            }
            await context.SaveChangesAsync();

            Song song01 = new Song("You give good love", 277, album01.Id);
            Song song02 = new Song("Thinking about you", 324, album01.Id);
            Song song03 = new Song("Nobody loves me like you do", 228, album01.Id);
            Song song04 = new Song("Just the lonely talking again", 332, album02.Id);
            Song song05 = new Song("So emotional", 276, album02.Id);
            Song song06 = new Song("Where you are", 250, album02.Id);
            Song song07 = new Song("Red", 223, album03.Id);
            Song song08 = new Song("State of grace", 295, album03.Id);
            Song song09 = new Song("Lover", 277, album04.Id);
            Song song10 = new Song("The archer", 221, album04.Id);
            Song song11 = new Song("Emotions", 248, album05.Id);
            Song song12 = new Song("Make it happen", 307, album05.Id);
            Song song13 = new Song("Can't let go", 247, album05.Id);
            Song song14 = new Song("Make it happen", 307, album05.Id);
            Song song15 = new Song("So blessed", 253, album05.Id);
            Song song16 = new Song("Fantasy", 243, album06.Id);
            Song song17 = new Song("I am free", 187, album06.Id);
            Song song18 = new Song("Butterfly", 273, album06.Id);
            Song song19 = new Song("My all", 230, album06.Id);
            Song song20 = new Song("Fly away", 229, album06.Id);
            if (!context.Songs.Any())
            {

                context.Songs.Add(song01);
                context.Songs.Add(song02);
                context.Songs.Add(song03);
                context.Songs.Add(song04);
                context.Songs.Add(song05);
                context.Songs.Add(song06);
                context.Songs.Add(song07);
                context.Songs.Add(song08);
                context.Songs.Add(song09);
                context.Songs.Add(song10);
                context.Songs.Add(song11);
                context.Songs.Add(song12);
                context.Songs.Add(song13);
                context.Songs.Add(song14);
                context.Songs.Add(song15);
                context.Songs.Add(song16);
                context.Songs.Add(song17);
                context.Songs.Add(song18);
                context.Songs.Add(song19);
                context.Songs.Add(song20);


            }
            await context.SaveChangesAsync();

            SongContributor songContributor01 = new SongContributor(artist01.Id, song01.Id);
            SongContributor songContributor02 = new SongContributor(artist01.Id, song02.Id);
            SongContributor songContributor03 = new SongContributor(artist01.Id, song03.Id);
            SongContributor songContributor04 = new SongContributor(artist01.Id, song04.Id);
            SongContributor songContributor05 = new SongContributor(artist01.Id, song05.Id);
            SongContributor songContributor06 = new SongContributor(artist01.Id, song06.Id);
            SongContributor songContributor07 = new SongContributor(artist02.Id, song07.Id);
            SongContributor songContributor08 = new SongContributor(artist02.Id, song08.Id);
            SongContributor songContributor09 = new SongContributor(artist02.Id, song09.Id);
            SongContributor songContributor10 = new SongContributor(artist02.Id, song10.Id);
            SongContributor songContributor11 = new SongContributor(artist03.Id, song11.Id);
            SongContributor songContributor12 = new SongContributor(artist03.Id, song12.Id);
            SongContributor songContributor13 = new SongContributor(artist03.Id, song13.Id);
            SongContributor songContributor14 = new SongContributor(artist03.Id, song14.Id);
            SongContributor songContributor15 = new SongContributor(artist03.Id, song15.Id);
            SongContributor songContributor16 = new SongContributor(artist03.Id, song16.Id);
            SongContributor songContributor17 = new SongContributor(artist03.Id, song17.Id);
            SongContributor songContributor18 = new SongContributor(artist03.Id, song18.Id);
            SongContributor songContributor19 = new SongContributor(artist03.Id, song19.Id);
            SongContributor songContributor20 = new SongContributor(artist03.Id, song20.Id);
            if (!context.SongContributors.Any())
            {

                context.SongContributors.Add(songContributor01);
                context.SongContributors.Add(songContributor02);
                context.SongContributors.Add(songContributor03);
                context.SongContributors.Add(songContributor04);
                context.SongContributors.Add(songContributor05);
                context.SongContributors.Add(songContributor06);
                context.SongContributors.Add(songContributor07);
                context.SongContributors.Add(songContributor08);
                context.SongContributors.Add(songContributor09);
                context.SongContributors.Add(songContributor10);
                context.SongContributors.Add(songContributor11);
                context.SongContributors.Add(songContributor12);
                context.SongContributors.Add(songContributor13);
                context.SongContributors.Add(songContributor14);
                context.SongContributors.Add(songContributor15);
                context.SongContributors.Add(songContributor16);
                context.SongContributors.Add(songContributor17);
                context.SongContributors.Add(songContributor18);
                context.SongContributors.Add(songContributor19);
                context.SongContributors.Add(songContributor20);

            }
            await context.SaveChangesAsync();

            User user01 = new User("Jimmy Brown");
            User user02 = new User("Chris James");

            if (!context.Users.Any())
            {

                context.Users.Add(user01);
                context.Users.Add(user02);
            }
            await context.SaveChangesAsync();

            Playlist playlist01 = new Playlist("JimmyBrownList01", user01.Id);
            Playlist playlist02 = new Playlist("JimmyBrownList02", user01.Id);
            Playlist playlist03 = new Playlist("ChrisJamesList01", user02.Id);

            if (!context.Playlists.Any())
            {

                context.Playlists.Add(playlist01);
                context.Playlists.Add(playlist02);
                context.Playlists.Add(playlist03);
            }
            await context.SaveChangesAsync();


            PlaylistSong playlistSong01 = new PlaylistSong(song01.Id, playlist01.Id, new DateTime(2023, 03, 11));
            PlaylistSong playlistSong02 = new PlaylistSong(song02.Id, playlist01.Id, new DateTime(2023, 03, 11));
            PlaylistSong playlistSong03 = new PlaylistSong(song03.Id, playlist01.Id, new DateTime(2023, 03, 11));
            PlaylistSong playlistSong04 = new PlaylistSong(song04.Id, playlist02.Id, new DateTime(2023, 03, 11));
            PlaylistSong playlistSong05 = new PlaylistSong(song05.Id, playlist02.Id, new DateTime(2023, 03, 11));
            PlaylistSong playlistSong06 = new PlaylistSong(song06.Id, playlist02.Id, new DateTime(2023, 03, 11));
            PlaylistSong playlistSong07 = new PlaylistSong(song07.Id, playlist03.Id, new DateTime(2023, 03, 11));
            PlaylistSong playlistSong08 = new PlaylistSong(song08.Id, playlist03.Id, new DateTime(2023, 03, 11));
            PlaylistSong playlistSong09 = new PlaylistSong(song09.Id, playlist03.Id, new DateTime(2023, 03, 11));

            if (!context.PlaylistSongs.Any())
            {

                context.PlaylistSongs.Add(playlistSong01);
                context.PlaylistSongs.Add(playlistSong02);
                context.PlaylistSongs.Add(playlistSong03);
                context.PlaylistSongs.Add(playlistSong04);
                context.PlaylistSongs.Add(playlistSong05);
                context.PlaylistSongs.Add(playlistSong06);
                context.PlaylistSongs.Add(playlistSong07);
                context.PlaylistSongs.Add(playlistSong08);
                context.PlaylistSongs.Add(playlistSong09);

            }

            await context.SaveChangesAsync();



            context.SaveChanges();
        }

    }
}

