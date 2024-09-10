using AuthenticationService.DAL.Configurations;
using AuthenticationService.DAL.Entitys;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AuthenticationService.DAL
{
    public class AppDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        //public DbSet<AccessToken> AccessTokens { get; set; }
        //public DbSet<RefreshToken> RefreshToken { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
            //modelBuilder.ApplyConfiguration<AccessToken>(new AccessTokenConfiguration());
            //modelBuilder.ApplyConfiguration<RefreshToken>(new RefreshTokenConfiguration());
        }
    }
}
