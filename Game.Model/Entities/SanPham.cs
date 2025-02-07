using System;
using System.Collections.Generic;

namespace Game.Model.Entities
{
    public partial class SanPham
    {
        public SanPham()
        {
            DonHangs = new HashSet<DonHang>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? CategoryId { get; set; }
        public string? Image { get; set; }
        public decimal? Price { get; set; }
        public decimal? Discount { get; set; }
        public string? Promotion { get; set; }
        public string? Descriptions { get; set; }
        public string? MoTaCh { get; set; }
        public string? ImageMore { get; set; }
        public bool Status { get; set; }
        public int? ViewCount { get; set; }

        public virtual DanhMucSanPham? Category { get; set; }
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
