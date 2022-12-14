using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalApp.Models.PersonalInfos
{
    public class PersonalCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string MobileNo { get; set; }
    }
}
