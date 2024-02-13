using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EventManagment.Models;

namespace EventManagment.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EventManagment.Models.Event>? Event { get; set; }
        public DbSet<EventManagment.Models.YourEvent>? YourEvent { get; set; }
    }
}
