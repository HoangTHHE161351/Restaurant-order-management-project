using System;
using System.Collections.Generic;

namespace MTableWeb.Models
{
    public partial class Table
    {
        public Table()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Infor { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
