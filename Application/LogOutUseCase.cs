using Application.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface ILogoutUseCase : IUseCase<LogOutRequest, LogOutResponse>
    {
    }

    public struct LogOutRequest
    {
        public readonly string UserName;

        public LogOutRequest(string userName)
        {
            UserName = userName;
        }
    }

    public struct LogOutResponse
    { }

    public class LogOutUseCase : IUseCase<LogOutRequest, LogOutResponse>
    {
        readonly IAccountRepository accountRepository;

        public LogOutResponse Execute(LogOutRequest request)
        {
            var account = accountRepository.Read(request.UserName);
            account.LogOut();
            accountRepository.Update(account);
            return new LogOutResponse();
        }
    }
}
