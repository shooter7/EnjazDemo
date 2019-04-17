using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnjazDemo.Forms
{
    public class CreateUserForm
    {
        [Required]
        public string Username { set; get; }
        [Required]
        [MinLength(4)]
        public string Password { set; get; }
        [Required]
        public string Role { set; get; }
    }
}
