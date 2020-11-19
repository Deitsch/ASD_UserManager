using Application.Contract;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface ICreateAccountUseCase : IUseCase<CreateAccountUseCaseRequest, CreateAccountUseCaseResponse>
    { }

    public struct CreateAccountUseCaseRequest
    {
        public readonly string FirstName;

        public readonly string LastName;

        public readonly string Username;

        public readonly string Password;

        public readonly string PasswordRepeated;

        public CreateAccountUseCaseRequest(string firstName, string lastName, string username, string password, string passwordRepeated)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
            PasswordRepeated = passwordRepeated;
        }
    }

    public struct CreateAccountUseCaseResponse
    {
        public readonly string Message;

        public CreateAccountUseCaseResponse(string message)
        {
            Message = message;
        }
    }

    public class CreateAccountUseCase : ICreateAccountUseCase
    {
        readonly IAccountRepository accountRepository;

        public CreateAccountUseCase(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public CreateAccountUseCaseResponse Execute(CreateAccountUseCaseRequest request)
        {
            string message;
            if (request.Password != request.PasswordRepeated)
            {
                message = "Passwords are not matching";
            }
            else
            {
                var account = new Account(request.Username, request.Username, request.FirstName, request.LastName);
                accountRepository.Create(account);
                message = "Successfully created Account";
            }

            return new CreateAccountUseCaseResponse(message);
        }
    }

    public class UsernameMismatchException: Exception { }
}
