using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EventManagment.Models
{
    public class ViewEvent
    {
        public Event? Event { get; set; }
        public IdentityUser? User { get; set; }
        public byte[]? Image => Event?.Image;
    }
}