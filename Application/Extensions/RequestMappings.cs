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
            => new NewAccount(request.FirstName, request.LastName, request.Username, PasswordHasher.Hash(request.Password), PasswordHasher.Hash(request.RepeatedPassword));

        public static NewPassword toNewPassword(this ChangeAccountPasswordRequest request)
            => new NewPassword(PasswordHasher.Hash(request.NewPassword), PasswordHasher.Hash(request.RepeatedPassword));
    }
}
