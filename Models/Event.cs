using Microsoft.AspNetCore.Identity;

namespace EventManager.Models
{
    public class Event
    {
        public int Id { get; set; }
        public byte[]? Image { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Start { get; set; }

        public string Location { get; set; }

        public string? UserId { get; set; }

        public virtual IdentityUser? User { get; set; }
    }
}