using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnjazDemo.Forms
{
    public class AttachmentForm
    {
        [Required]
        public string fullName { set; get; }
        [Required]
        public string nationIdentity { set; get; }
        [Required]
        public string carNumber { set; get; }
        [Required]
        [MaxLength(1)]
        public string carEnglishChar { set; get; }
        [Required]
        [MaxLength(1)]
        public string carArabicChar { set; get; }
        [Required]
        public string drivingLicenseNumber { set; get; }
    }
}
