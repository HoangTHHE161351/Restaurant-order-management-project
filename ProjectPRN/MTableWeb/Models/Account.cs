using System;
using System.Collections.Generic;

namespace MTableWeb.Models
{
    public partial class Account
    {
        public Account()
        {
            OrderEmployeeCfNavigations = new HashSet<Order>();
            OrderUserOrderNavigations = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int? Role { get; set; }
        public bool? Status { get; set; }

        public virtual Information? Information { get; set; }
        public virtual ICollection<Order> OrderEmployeeCfNavigations { get; set; }
        public virtual ICollection<Order> OrderUserOrderNavigations { get; set; }
    }
}
