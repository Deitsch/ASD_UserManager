using Application.Contract;
using Application.Exceptions;
using Application.Extensions;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface ICreateAccountUseCase : IUseCase<CreateAccountRequest, CreateAccountResponse>
    { }

    public struct CreateAccountRequest
    {
        public readonly string FirstName;

        public readonly string LastName;

        public readonly string Username;

        public readonly string Password;

        public readonly string RepeatedPassword;

        public CreateAccountRequest(string firstName, string lastName, string username, string password, string repeatedPassword)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
            RepeatedPassword = repeatedPassword;
        }
    }

    public struct CreateAccountResponse
    {
        
    }

    public class CreateAccountUseCase : ICreateAccountUseCase
    {
        readonly IAccountRepository accountRepository;

        public CreateAccountUseCase(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public CreateAccountResponse Execute(CreateAccountRequest request)
        {
            var existingAccount = accountRepository.Read(request.Username);

            if (existingAccount != null)
                throw new ResourceAlreadyExistingException($"There is already existing an account with the username: {request.Username}!");

            var account = Account.Create(request.toNewAccount());
            accountRepository.Create(account);
            return new CreateAccountResponse();
        }
    }
}
