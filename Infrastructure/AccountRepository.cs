using System;
using Domain;
using System.Linq;
using Application.Contract;

namespace Infrastructure
{
    public class AccountRepository : IAccountRepository
    {

        private readonly SQLiteContext context;

        public AccountRepository(SQLiteContext context)
        {
            this.context = context;
        }

        public void Create(Account item)
        {
            context.Accounts.Add(item);
            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Account account = context.Accounts.First(a => a.Id == id);
            context.Accounts.Remove(account);
            context.SaveChanges();
        }

        public void Delete(string username)
        {
            Account account = context.Accounts.First(a => a.UserName == username);
            context.Accounts.Remove(account);
            context.SaveChanges();
        }

        public Account Read(Guid id)
        {
            return context.Accounts.First(a => a.Id == id);
        }

        public Account Read(string username)
        {
            var accounts = context.Accounts.ToList();
            return context.Accounts.AsEnumerable().FirstOrDefault(a => a.UserName == username);
        }

        public void Update(Account item)
        {
            context.Accounts.Update(item);
            context.SaveChanges();
        }
    }
}
