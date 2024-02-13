using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventManagment.Data;
using EventManagment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace EventManagment.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public EventsController(ApplicationDbContext context,
                                 UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult>
        Index()
        {
            IdentityUser uzytkownik
                = _userManager.FindByNameAsync(User?.Identity?.Name).Result;

            return _context.Event != null
                       ? View(await _context.Event.Include(e => e.User)
                                   .Where(p => p.UserId == uzytkownik.Id)
                                   .ToListAsync())
                       : Problem("Entity set 'ApplicationDbContext.Event'  is null.");
        }

        public async Task<IActionResult>
        Details(int? id)
        {
            if (id == null || _context.Event == null)
            {
                return NotFound();
            }

            var @event = await _context.Event.FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        public IActionResult
        Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>
        Create([Bind("Title,Description,Start,Location,Image")] Event @event,
                IFormFile image)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);

                    if (user == null)
                    {
                        return RedirectToAction("Login", "Account");
                    }

                    @event.UserId = user.Id;

                    if (image != null && image.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            await image.CopyToAsync(ms);
                            @event.Image = ms.ToArray();
                        }
                    }
                    _context.Add(@event);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Create action: {ex.Message}");
            }

            return View(@event);
        }

        public async Task<IActionResult>
        Edit(int? id)
        {
            if (id == null || _context.Event == null)
            {
                return NotFound();
            }

            var @event = await _context.Event.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>
        Edit(int id,
              [Bind("Id,Title,Description,Start,Location, Image")] Event @event,
              IFormFile image)
        {
            if (id != @event.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.GetUserAsync(User);

                    if (user == null)
                    {
                        return RedirectToAction("Login", "Account");
                    }

                    @event.UserId = user.Id;

                    if (image != null && image.Length > 0){
                        using (var ms = new MemoryStream())
                        {
                            await image.CopyToAsync(ms);
                            @event.Image = ms.ToArray();
                        }
                    }

                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.Id))
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
            return View(@event);
        }

        public async Task<IActionResult>
        Delete(int? id)
        {
            if (id == null || _context.Event == null)
            {
                return NotFound();
            }

            var @event = await _context.Event.FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>
        DeleteConfirmed(int id)
        {
            if (_context.Event == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Event'  is null.");
            }
            var @event = await _context.Event.FindAsync(id);
            if (@event != null)
            {
                _context.Event.Remove(@event);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool
        EventExists(int id)
        {
            return (_context.Event?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}