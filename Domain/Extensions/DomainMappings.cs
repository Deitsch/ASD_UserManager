using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Extensions
{
    public static class DomainMappings
    {
        public static AccountInfo toAccountInfo(this Account account)
            => new AccountInfo(account.Id, account.UserName, account.FirstName, account.LastName);
    }
}
