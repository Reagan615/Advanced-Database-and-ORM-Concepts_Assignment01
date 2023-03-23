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
    public class ListenerListsController : Controller
    {
        private readonly Advanced_Database_and_ORM_Concepts_Assignment_1Context _context;

        public ListenerListsController(Advanced_Database_and_ORM_Concepts_Assignment_1Context context)
        {
            _context = context;
        }

        // GET: ListenerLists
        public async Task<IActionResult> Index()
        {
            List<ListenerList> listenerLists = _context.ListenerList.ToList();
            return View(listenerLists);
        }

        public IActionResult PodcastsForListenerList(int id)
        {
            ListenerList listenerList = _context.ListenerList
                .Include(a => a.Podcasts)
                .ThenInclude(b => b.Episodes)
                .FirstOrDefault(e => e.Id == id);
            if (listenerList == null)
            {
                return NotFound();
            }



            return View(listenerList);
        }

        // GET: ListenerLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ListenerList == null)
            {
                return NotFound();
            }

            var listenerList = await _context.ListenerList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listenerList == null)
            {
                return NotFound();
            }

            return View(listenerList);
        }

        // GET: ListenerLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ListenerLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ListenerListName")] ListenerList listenerList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listenerList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listenerList);
        }

        // GET: ListenerLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ListenerList == null)
            {
                return NotFound();
            }

            var listenerList = await _context.ListenerList.FindAsync(id);
            if (listenerList == null)
            {
                return NotFound();
            }
            return View(listenerList);
        }

        // POST: ListenerLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ListenerListName")] ListenerList listenerList)
        {
            if (id != listenerList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listenerList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListenerListExists(listenerList.Id))
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
            return View(listenerList);
        }

        // GET: ListenerLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ListenerList == null)
            {
                return NotFound();
            }

            var listenerList = await _context.ListenerList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listenerList == null)
            {
                return NotFound();
            }

            return View(listenerList);
        }

        // POST: ListenerLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ListenerList == null)
            {
                return Problem("Entity set 'Advanced_Database_and_ORM_Concepts_Assignment_1Context.ListenerList'  is null.");
            }
            var listenerList = await _context.ListenerList.FindAsync(id);
            if (listenerList != null)
            {
                _context.ListenerList.Remove(listenerList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListenerListExists(int id)
        {
          return (_context.ListenerList?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
