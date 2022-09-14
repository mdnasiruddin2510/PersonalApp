using AutoMapper;
using PersonalApp.Models.EntityModels;
using PersonalApp.Models.PersonalInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalApp.Profiles
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<PersonalInfo, PersonalCreate>();
            CreateMap<PersonalCreate,PersonalInfo>();
            CreateMap<PersonalInfo,PersonalInfoEditVM>();
            CreateMap<PersonalInfoEditVM,PersonalInfo >();
            CreateMap<PersonalInfoListVM, PersonalInfo>();
            CreateMap<PersonalInfo, PersonalInfoListVM>();
        }
    }
}
