using System.Collections.Generic;

namespace AuthServer.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // "Admin", "Manager", "Student"
        public string? Description { get; set; }

        public ICollection<AccountRole> AccountRoles { get; set; } = new List<AccountRole>();
    }
}