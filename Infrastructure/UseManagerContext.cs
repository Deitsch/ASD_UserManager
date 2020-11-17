using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class SQLiteContext : DbContext 
    {
        public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=userDataManager.db");

        //public SQLiteContext(DbContextOptions<SQLiteContext> options) : base(options)
        //{
        //    this.Database.EnsureCreated();
        //}
    }
}
