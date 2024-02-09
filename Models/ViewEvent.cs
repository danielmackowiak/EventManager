using Microsoft.AspNetCore.Identity;

namespace EventManager.Models
{
    public class ViewEvent
    {
        public Event Event { get; set; }

        public IdentityUser User { get; set; }

        public byte[] Image => Event.Image;
    }
}
