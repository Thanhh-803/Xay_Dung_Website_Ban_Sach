using System;
using System.Collections.Generic;

namespace Game.Model.Entities
{
    public partial class DonHang
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? CustomeId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? TotalCost { get; set; }
        public bool? Status { get; set; }
        public decimal? Price { get; set; }
        public virtual Customer? Custome { get; set; }
        public virtual SanPham? CustomeNavigation { get; set; }
    }
}
