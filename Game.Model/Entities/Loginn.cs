using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Model.Entities
{
    public partial class Login
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [MinLength(6, ErrorMessage = "Độ dài mật khẩu tối thiểu là 6 ký tự")]
        public string? Password { get; set; }
    }
}
