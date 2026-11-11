using System.Collections.Generic;

namespace AuthServer.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}