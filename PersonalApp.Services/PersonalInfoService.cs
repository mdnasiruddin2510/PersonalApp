using PersonalApp.Models.EntityModels;
using PersonalApp.Repositories.Abstractions;
using PersonalApp.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalApp.Services
{
    public class PersonalInfoService :Service<PersonalInfo>, IPersonalInfoService
    {
        IPersonalInfoRepository _personalInfoRepo;
        public PersonalInfoService(IPersonalInfoRepository personalInfoRepo):base(personalInfoRepo)
        {
            _personalInfoRepo = personalInfoRepo;
        }
        
    }
}
