using System;
using System.Collections.Generic;

namespace Game.Model.Entities
{
    public partial class ChiTietDonHang
    {
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Discount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? PaymentMethod { get; set; }
        public string? PaymentStatus { get; set; }
        public decimal? TotalCost { get; set; }
        public DateTime? BillDate { get; set; }
        public string? Note { get; set; }

        public virtual DonHang? Order { get; set; }
        public virtual DanhMucSanPham? Product { get; set; }
    }
}
