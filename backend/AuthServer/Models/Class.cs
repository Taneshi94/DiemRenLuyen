using System.Collections.Generic;

namespace AuthServer.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;

        public int FacultyId { get; set; }
        public Faculty? Faculty { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}