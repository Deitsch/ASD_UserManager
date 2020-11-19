using Application.Contract;
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
    }

    public struct CreateAccountUseCaseResponse
    { }

    public class CreateAccountUseCase : ICreateAccountUseCase
    {
        readonly IAccountRepository accountRepository;

        public CreateAccountUseCase(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public Task<CreateAccountUseCaseResponse> Execute(CreateAccountUseCaseRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
