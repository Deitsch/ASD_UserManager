using Application.Contract;
using Application.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IChangeAccountPasswordUseCase : IUseCase<ChangeAccountPasswordRequest, ChangeAccountPasswordResponse>
    {
    }

    public struct ChangeAccountPasswordRequest
    {
        public readonly string UserName;

        public readonly string NewPassword;

        public readonly string RepeatedPassword;

        public ChangeAccountPasswordRequest(string userName, string newPassword, string repeatedPassword)
        {
            UserName = userName;
            NewPassword = newPassword;
            RepeatedPassword = repeatedPassword;
        }
    }

    public struct ChangeAccountPasswordResponse
    { }

    public class ChangeAccountPasswordUseCase : IChangeAccountPasswordUseCase
    {
        readonly IAccountRepository accountRepository;

        public ChangeAccountPasswordUseCase(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public ChangeAccountPasswordResponse Execute(ChangeAccountPasswordRequest request)
        {
            var account = accountRepository.Read(request.UserName);
            account.ChangePassword(request.toNewPassword());
            accountRepository.Update(account);
            return new ChangeAccountPasswordResponse();
        }
    }
}
