using System;
using System.Collections.Generic;

namespace ProjectMTable.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int? UserOrder { get; set; }
        public string? TimeOrder { get; set; }
        public DateTime? DateOrder { get; set; }
        public string? NoteUser { get; set; }
        public int? EmployeeCf { get; set; }
        public DateTime? DateCf { get; set; }
        public int? Status { get; set; }
        public string? NoteEmployee { get; set; }
        public int? TableId { get; set; }

        public virtual Account? EmployeeCfNavigation { get; set; }
        public virtual Table? Table { get; set; }
        public virtual Account? UserOrderNavigation { get; set; }
    }
}
