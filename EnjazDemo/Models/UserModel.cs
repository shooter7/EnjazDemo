using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnjazDemo.Models
{
    public class UserModel 
    {
        [Key]
        public Guid Guid { set; get; }
        public string username { set; get; }
        public string password{set;get;}
        public string Role { set; get; }
    

    }
}
