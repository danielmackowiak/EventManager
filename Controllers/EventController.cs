using EventManager.Data;
using EventManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _context;

        public EventController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Event> events = _context.Events.Include(e => e.InterestedUsers).ToList();

            return View(events);
        }
    }
}
