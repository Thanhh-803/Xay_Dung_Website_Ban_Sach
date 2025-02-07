using System;
using System.Collections.Generic;

namespace Game.Model.Entities
{
    public partial class Menu
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public int? DisplayOrder { get; set; }
        public int? GroupId { get; set; }
        public bool? Status { get; set; }

        public virtual MenuGroup? Group { get; set; }
    }
}
