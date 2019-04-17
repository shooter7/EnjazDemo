using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnjazDemo.Forms
{
    public class LoginForm
    {
        [Required]
        public string username { set; get; }
        [Required]
        [MinLength(6)]
        public string password { set; get; }
    }
}
