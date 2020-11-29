using System;
using System.Linq;
using Application.Contract;
using Domain;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Infrastructure.Tests
{
    public class AccountRepositoryTests : IDisposable
    {
        DbContextOptions<SQLiteContext> options;
        SqliteConnection connection;

        public AccountRepositoryTests()
        {
            this.connection = new SqliteConnection("DataSource=:memory:");
            this.connection.Open();
            this.options = new DbContextOptionsBuilder<SQLiteContext>().UseSqlite(connection).Options;

            using (var context = new SQLiteContext(this.options))
            {
                context.Database.EnsureCreated();
            }

        }

        public void Dispose()
        {
            connection.Close();
        }

        [Fact]
        public void Create_IsSaved()
        {
            try
            {
                // Run the test against one instance of the context
                using (var context = new SQLiteContext(options))
                {
                    IAccountRepository repository = new AccountRepository(context);
                    var newAcc = new NewAccount("Jon", "Doe", "jondoe", "password", "password");
                    var acc = Account.Create(newAcc);
                    repository.Create(acc);
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new SQLiteContext(options))
                {
                    Assert.Equal(1, context.Accounts.Count());
                    Assert.Equal("jondoe", context.Accounts.Single().UserName);
                }
            }
            finally { }
        }

        [Fact]
        public void Delete_IsSaved()
        {
            try
            {
                Guid id;
                using (var context = new SQLiteContext(options))
                {
                    var newAcc = new NewAccount("Jon", "Doe", "jondoe", "password", "password");
                    var acc = Account.Create(newAcc);
                    id = acc.Id;

                    context.Accounts.Add(acc);
                    context.SaveChanges();
                }

                using (var context = new SQLiteContext(options))
                {
                    Assert.Equal(1, context.Accounts.Count());
                    Assert.Equal("jondoe", context.Accounts.Single().UserName);
                }

                using (var context = new SQLiteContext(options))
                {
                    IAccountRepository repository = new AccountRepository(context);
                    repository.Delete(id);
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new SQLiteContext(options))
                {
                    Assert.Equal(0, context.Accounts.Count());
                }
            }
            finally { }
        }
    }
}
