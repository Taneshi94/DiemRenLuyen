using System;
using System.Collections.Generic;

namespace AuthServer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        
        public int? FacultyId { get; set; }
        public Faculty? Faculty { get; set; }

        public int? ClassId { get; set; }
        public Class? Class { get; set; }

        public int? PositionId { get; set; }
        public Position? Position { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<AccountRole> AccountRoles { get; set; } = new List<AccountRole>();
    }
}