using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnjazDemo.Models
{
    public class Attachment
    {
        [Key]
        public Guid Guid { set; get; }
        public string fullName { set; get; }
        public string nationIdentity { set; get; }
        public string carNumber { set; get; }
        public string carEnglishChar {set; get; }
        public string carArabicChar { set; get; }
        public string drivingLicenseNumber { set; get; }
        public string attachmentUrl { set; get; }
        public string fileUrl { set; get; }

    }
}
