using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface ICreateAccountUseCase : IUseCase<CreateAccountUseCaseRequest, CreateAccountUseCaseResponse>
    {
    }

    public struct CreateAccountUseCaseRequest
    { }

    public struct CreateAccountUseCaseResponse
    { }

    public class CreateAccountUseCase : ICreateAccountUseCase
    {
        public Task<CreateAccountUseCaseResponse> Execute(CreateAccountUseCaseRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
