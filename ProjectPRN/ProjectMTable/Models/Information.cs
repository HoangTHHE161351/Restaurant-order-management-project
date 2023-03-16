using System;
using System.Collections.Generic;

namespace ProjectMTable.Models
{
    public partial class Information
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }

        public virtual Account IdNavigation { get; set; } = null!;
    }
}
