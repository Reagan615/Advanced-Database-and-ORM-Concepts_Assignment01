using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Advanced_Database_and_ORM_Concepts_Assignment_1.Data;
using Advanced_Database_and_ORM_Concepts_Assignment_1.Models;
using Advanced_Database_and_ORM_Concepts_Assignment_1.Models.ViewModels;

namespace Advanced_Database_and_ORM_Concepts_Assignment_1.Controllers
{
    public class PodcastsController : Controller
    {
        private readonly Advanced_Database_and_ORM_Concepts_Assignment_1Context _context;

        public PodcastsController(Advanced_Database_and_ORM_Concepts_Assignment_1Context context)
        {
            _context = context;
        }

        // GET: Podcasts
        public async Task<IActionResult> Index()
        {
            List<Podcast> podcasts = await _context.Podcast
              .Include(a => a.Artists)
              .Include(b => b.Episodes)
              .Include(c => c.ListenerLists)
              .ToListAsync();

            return View(podcasts);
        }

        public List<Episode> GetEpisode(int podcastId)
        {
            Podcast podcast = _context.Podcast
                .Include(a => a.Episodes)
                .FirstOrDefault(b => b.Id == podcastId);

            return podcast.Episodes;
        }
        // GET: Podcasts/Details/5
        public IActionResult Details(int? id, string sortFunction = null)
        {
            if (id == null)
            {
                return NotFound();
            }

            Podcast podcast = _context.Podcast
                .FirstOrDefault(a => a.Id == id);


            if (podcast == null)
            {
                return NotFound();
            }

            List<Episode> episodes = GetEpisode(podcast.Id);

            if (sortFunction == "chronological")
            {
                episodes = episodes.OrderBy(e => e.AirDate).ToList();
            }
            else if (sortFunction == "reverse-chronological")
            {
                episodes = episodes.OrderByDescending(e => e.AirDate).ToList();
            }

            EpisodeListVM vm = new EpisodeListVM
            {
                Episodes = episodes,
                SortFunction = sortFunction
            };

            return View(vm);
        }

        // GET: Podcasts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Podcasts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PodcastTitle")] Podcast podcast)
        {
            if (ModelState.IsValid)
            {
                _context.Add(podcast);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(podcast);
        }

        // GET: Podcasts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Podcast == null)
            {
                return NotFound();
            }

            var podcast = await _context.Podcast.FindAsync(id);
            if (podcast == null)
            {
                return NotFound();
            }
            return View(podcast);
        }

        // POST: Podcasts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PodcastTitle")] Podcast podcast)
        {
            if (id != podcast.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(podcast);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PodcastExists(podcast.Id))
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
            return View(podcast);
        }

        // GET: Podcasts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Podcast == null)
            {
                return NotFound();
            }

            var podcast = await _context.Podcast
                .FirstOrDefaultAsync(m => m.Id == id);
            if (podcast == null)
            {
                return NotFound();
            }

            return View(podcast);
        }

        // POST: Podcasts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Podcast == null)
            {
                return Problem("Entity set 'Advanced_Database_and_ORM_Concepts_Assignment_1Context.Podcast'  is null.");
            }
            var podcast = await _context.Podcast.FindAsync(id);
            if (podcast != null)
            {
                _context.Podcast.Remove(podcast);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PodcastExists(int id)
        {
          return (_context.Podcast?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public IActionResult AddToListenerList(int id)
        {
            Podcast podcast = _context.Podcast.Include(e => e.ListenerLists).FirstOrDefault(p => p.Id == id);
            if (podcast == null)
            {
                return NotFound();
            }

            List<ListenerList> listenerList = _context.ListenerList.Where(a => !a.Podcasts.Any(p => p.Id == id)).ToList();

            AddToListenerListVM vm = new AddToListenerListVM
            {
                Podcast = podcast,
                ListenerLists = listenerList
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult AddToListenerList(int id, int listenerListId)
        {
            Podcast podcast = _context.Podcast.Include(e => e.ListenerLists).FirstOrDefault(p => p.Id == id);
            if (podcast == null)
            {
                return NotFound();
            }

            ListenerList listenerList = _context.ListenerList.Include(l => l.Podcasts).FirstOrDefault(l => l.Id == listenerListId);
            if (listenerList == null)
            {
                return NotFound();
            }

            if (!listenerList.Podcasts.Any(a => a.Id == id))
            {
                listenerList.Podcasts.Add(podcast);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
