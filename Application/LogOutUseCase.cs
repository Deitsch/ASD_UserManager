using Application.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface ILogoutUseCase : IUseCase<LogoutRequest, LogoutResponse>
    {
    }

    public struct LogoutRequest
    {
        public readonly string UserName;

        public LogoutRequest(string userName)
        {
            UserName = userName;
        }
    }

    public struct LogoutResponse
    { }

    public class LogoutUseCase : ILogoutUseCase
    {
        readonly IAccountRepository accountRepository;

        public LogoutUseCase(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public LogoutResponse Execute(LogoutRequest request)
        {
            var account = accountRepository.Read(request.UserName);
            account.LogOut();
            accountRepository.Update(account);
            return new LogoutResponse();
        }
    }
}
