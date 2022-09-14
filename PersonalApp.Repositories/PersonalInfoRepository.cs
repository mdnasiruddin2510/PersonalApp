using PersonalApp.Database.DbContexts;
using PersonalApp.Models.EntityModels;
using PersonalApp.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonalApp.Repositories
{
    public class PersonalInfoRepository :Repository<PersonalInfo>,IPersonalInfoRepository
    {
        PersonalAppDbContext db;
        public PersonalInfoRepository(PersonalAppDbContext db):base(db)
        {
            this.db = db;
        }
        public override PersonalInfo GetById(int id)
        {
            return db.PersonalInfos.FirstOrDefault(c => c.Id == id);
        }

        
    }
}
