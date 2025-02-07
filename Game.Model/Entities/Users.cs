using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Model.Entities
{
    public partial class Users
    {
        
        public string Id { get; set; }
        
        public string Username { get; set; }
        
        
        public string Email { get; set; }
        public string? Password { get; set; }
        [Range(18, 99, ErrorMessage = "Số tuổi không hợp lệ. ")]
        public DateTime Age { get; set; }
    }
}
