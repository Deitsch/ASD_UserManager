using Application.Contract;
using Application.Exceptions;
using Domain;
using Domain.Extensions;
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
        public readonly string Id;

        public readonly string UserName;

        public readonly string FirstName;

        public readonly string LastName;

        public LoginResponse(AccountInfo accountInfo)
        {
            Id = accountInfo.Id.ToString();
            UserName = accountInfo.UserName;
            FirstName = accountInfo.FirstName;
            LastName = accountInfo.LastName;
        }
    }

    public class LoginUseCase : ILoginUseCase
    {
        readonly IAccountRepository accountRepository;
        int loginCounter = 0;

        public LoginUseCase(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public LoginResponse Execute(LoginRequest request)
        {
            if (loginCounter == 3)
                throw new InvalidOperationException("Too much login tries!");

            var account = accountRepository.Read(request.UserName);
            if (account == null)
                throw new ResourceNotExistingException("Username or password is wrong!");

            loginCounter++;
            account.Login(PasswordHasher.Hash(request.Password));
            accountRepository.Update(account);
            loginCounter = 0;
            return new LoginResponse(account.toAccountInfo());
        }
    }
}
