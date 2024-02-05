namespace EventManager.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<User> InterestedUsers { get; set; } = new List<User>();
    }

}
