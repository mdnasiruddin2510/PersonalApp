using Microsoft.EntityFrameworkCore;
using PersonalApp.Models.EntityModels;

namespace PersonalApp.Database.DbContexts
{
    public class PersonalAppDbContext:DbContext /*IdentityDbContext<AppUser,AppRole,int>*/
    {
        public PersonalAppDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<PersonalInfo> PersonalInfos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder); 
        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    builder.Entity<AppUser>(b => b.ToTable("AppUsers"));
        //    builder.Entity<AppRole>(b => b.ToTable("AppRoles"));
        //}
    }
}
