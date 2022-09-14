using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalApp.Models.EntityModels;
namespace PersonalApp.Models.PersonalInfos
{
    public class PersonalInfoListVM
    {
        public string Title { get; set; }
        public List<PersonalInfo> PerList { get; set; }
    }
}
