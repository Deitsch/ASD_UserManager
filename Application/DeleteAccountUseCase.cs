using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public interface IDeleteAccountUseCase : IUseCase<DeleteAccountUseCaseRequest, DeleteAccountUseCaseResponse>
    {
    }

    public struct DeleteAccountUseCaseRequest
    { }

    public struct DeleteAccountUseCaseResponse
    { }

    class DeleteAccountUseCase
    {
    }
}
