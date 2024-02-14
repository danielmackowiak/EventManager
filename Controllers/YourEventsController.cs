using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventManagment.Data;
using EventManagment.Models;

namespace EventManagment.Controllers {
  [Authorize]
  public class YourEventsController: Controller {
    private readonly ApplicationDbContext _context;
    private readonly UserManager < IdentityUser > _userManager;

    public YourEventsController(ApplicationDbContext context,
      UserManager < IdentityUser > userManager) {
      _context = context;
      _userManager = userManager;
    }

    public async Task < IActionResult >
      Index() {
        IdentityUser user = await _userManager.FindByNameAsync(User.Identity.Name);

        var yourEvents = await _context.YourEvent.Include(pe => pe.Event)
          .Where(pe => pe.UserId == user.Id)
          .ToListAsync();

        return View(yourEvents);
      }

    public async Task < IActionResult >
      UnmarkInterest(int eventId) {
        IdentityUser user = await _userManager.FindByNameAsync(User.Identity.Name);

        var existingInterest = await _context.YourEvent.FirstOrDefaultAsync(
          pe => pe.UserId == user.Id && pe.EventId == eventId);

        if (existingInterest != null) {
          _context.YourEvent.Remove(existingInterest);
          await _context.SaveChangesAsync();
        }

        return RedirectToAction("Index");
      }
  }
}