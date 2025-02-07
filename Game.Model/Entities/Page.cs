using System;
using System.Collections.Generic;

namespace Game.Model.Entities
{
    public partial class Page
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Content { get; set; }
        public bool? Status { get; set; }
        public string? Image { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? NDChiTiet { get; set; }
    }
}
