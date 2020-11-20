using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class RequestMappings
    {
        public static NewAccount toNewAccount(this CreateAccountRequest request)
            => new NewAccount(request.FirstName, request.LastName, request.Username, request.Password, request.RepeatedPassword);

        public static NewPassword toNewPassword(this ChangeAccountPasswordRequest request)
            => new NewPassword(request.NewPassword, request.RepeatedPassword);

        public static AccountInfo toAccountInfo(this Account account)
            => new AccountInfo(account.Id, account.UserName, account.FirstName, account.LastName);
    }
}
