using System;
using System.Collections.Generic;

namespace PolyAPI.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public int UserRoleId { get; set; }
        public string? UserName { get; set; }
        public string? UserLogin { get; set; }
        public string? UserPassword { get; set; }

        public virtual Role UserRole { get; set; } = null!;
    }
}
