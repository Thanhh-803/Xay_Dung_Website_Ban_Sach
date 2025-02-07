using System;
using System.Collections.Generic;

namespace Game.Model.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            DonHangs = new HashSet<DonHang>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? Note { get; set; }

        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
