using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Advanced_Database_and_ORM_Concepts_Assignment_1.Data;
using Advanced_Database_and_ORM_Concepts_Assignment_1.Models;

namespace Advanced_Database_and_ORM_Concepts_Assignment_1.Controllers
{
    public class PlaylistsController : Controller
    {
        private readonly Advanced_Database_and_ORM_Concepts_Assignment_1Context _context;

        public PlaylistsController(Advanced_Database_and_ORM_Concepts_Assignment_1Context context)
        {
            _context = context;
        }

        // GET: Playlists
        public async Task<IActionResult> Index()
        {
            List<Playlist> playlists = await _context.Playlists.Include(p => p.PlaylistSongs).ToListAsync();
            return View(playlists);
        }

        // GET: Playlists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Playlist playlist = _context.Playlists
                .Include(p => p.PlaylistSongs)
                .ThenInclude(ps => ps.Song)
                .ThenInclude(s => s.Album)
                .SingleOrDefault(p => p.Id == id);

            if (playlist == null)
            {
                return NotFound();
            }
            List<SongDetails> songDetails = new List<SongDetails>();
            int totalRuntimeSeconds = 0;

            foreach (PlaylistSong playlistSong in playlist.PlaylistSongs)
            {
                Song song = playlistSong.Song;
                int runtimeSeconds = song.DurationSeconds;
                songDetails.Add(new SongDetails
                {
                    Song = song,
                    RuntimeSeconds = runtimeSeconds
                });
                totalRuntimeSeconds = totalRuntimeSeconds + runtimeSeconds;
            }

            PlaylistDetails model = new PlaylistDetails
            {
                Playlist = playlist,
                TotalRuntimeSeconds = totalRuntimeSeconds,
                NumSongs = songDetails.Count,
                SongDetails = songDetails
            };

            return View(model);

        }

        [HttpPost]
        public IActionResult RemoveSong(int playlistId, int songId)
        {
            Playlist playlist = _context.Playlists.Include(p => p.PlaylistSongs).SingleOrDefault(p => p.Id == playlistId);
            if (playlist == null)
            {
                return NotFound();
            }

            PlaylistSong playlistSong = playlist.PlaylistSongs.SingleOrDefault(ps => ps.SongId == songId);
            if (playlistSong == null)
            {
                return NotFound();
            }

            _context.PlaylistSongs.Remove(playlistSong);
            _context.SaveChanges();

            return RedirectToAction("Details", new { id = playlistId });
        }
        // GET: Playlists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Playlists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,UserId")] Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playlist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(playlist);
        }

        // GET: Playlists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Playlists == null)
            {
                return NotFound();
            }

            var playlist = await _context.Playlists.FindAsync(id);
            if (playlist == null)
            {
                return NotFound();
            }
            return View(playlist);
        }

        // POST: Playlists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,UserId")] Playlist playlist)
        {
            if (id != playlist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playlist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaylistExists(playlist.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(playlist);
        }

        // GET: Playlists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Playlists == null)
            {
                return NotFound();
            }

            var playlist = await _context.Playlists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playlist == null)
            {
                return NotFound();
            }

            return View(playlist);
        }

        // POST: Playlists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Playlists == null)
            {
                return Problem("Entity set 'Advanced_Database_and_ORM_Concepts_Assignment_1Context.Playlists'  is null.");
            }
            var playlist = await _context.Playlists.FindAsync(id);
            if (playlist != null)
            {
                _context.Playlists.Remove(playlist);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaylistExists(int id)
        {
          return _context.Playlists.Any(e => e.Id == id);
        }

        public IActionResult AllSongs()
        {
            List<Song> songs = _context.Songs.Include(s => s.Album).ToList();
            return View(songs);
        }
    }
}
