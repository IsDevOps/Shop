using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Services.AppUser.Model;

namespace Shop.Services.AuthAPI.Database
{
    public class DatabaseContext : IdentityDbContext<AppUserModel>
    {

        public DbSet<AppUserModel> AppUserModel   { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);           
        }
    }
}
