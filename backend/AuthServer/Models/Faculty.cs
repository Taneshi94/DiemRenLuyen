using System.Collections.Generic;

namespace AuthServer.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;

        public ICollection<Class> Classes { get; set; } = new List<Class>();
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}