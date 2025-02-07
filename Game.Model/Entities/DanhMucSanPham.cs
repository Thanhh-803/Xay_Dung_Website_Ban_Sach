using System;
using System.Collections.Generic;

namespace Game.Model.Entities
{
    public partial class DanhMucSanPham
    {
        public DanhMucSanPham()
        {
            SanPhams = new HashSet<SanPham>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? MoTa { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
