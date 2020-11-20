using Application.Contract;
using Application.Extensions;
using Domain;
using System;
using System.Threading.Tasks;

namespace Application
{
    public interface ILoginUseCase : IUseCase<LoginRequest, LoginResponse>
    {
    }

    public struct LoginRequest
    {
        public readonly string UserName;

        public readonly string Password;

        public LoginRequest(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }

    public struct LoginResponse
    {
        public readonly AccountInfo AccountInfo;

        public LoginResponse(AccountInfo accountInfo)
        {
            AccountInfo = accountInfo;
        }
    }

    public class LoginUseCase : ILoginUseCase
    {
        readonly IAccountRepository accountRepository;

        public LoginResponse Execute(LoginRequest request)
        {
            var account = accountRepository.Read(request.UserName);
            account.Login(request.Password);
            accountRepository.Update(account);
            return new LoginResponse(account.toAccountInfo());
        }
    }
}
