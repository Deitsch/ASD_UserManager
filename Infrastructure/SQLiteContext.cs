using System;
using System.Reflection;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class SQLiteContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public SQLiteContext(DbContextOptions<SQLiteContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Account>()
                .Property(a => a.UserName);
            modelBuilder.Entity<Account>()
                .Property(a => a.FirstName);
            modelBuilder.Entity<Account>()
                .Property(a => a.LastName);
            modelBuilder.Entity<Account>()
                .Property("Password");
            modelBuilder.Entity<Account>()
                .Property("IsUserLoggedIn");


            base.OnModelCreating(modelBuilder);
        }
    }
}
