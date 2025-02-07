using System;
using System.Collections.Generic;

namespace Game.Model.Entities
{
    public partial class Slide
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public string Url { get; set; } = null!;
        public int? DisplayOrder { get; set; }
    }
}
