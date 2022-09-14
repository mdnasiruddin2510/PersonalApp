using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonalApp.Database.DbContexts;
using PersonalApp.Repositories;
using PersonalApp.Repositories.Abstractions;
using PersonalApp.Services;
using PersonalApp.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalApp.Configurations
{
    public class AppConfiguration
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PersonalAppDbContext>(c => c.UseSqlServer(@"Server=TEAMOS-PC;Database=PersonalAppDB;Integrated Security=true"));
            services.AddTransient<IPersonalInfoRepository, PersonalInfoRepository>();
            services.AddTransient<IPersonalInfoService, PersonalInfoService>();
        }
    }
}
