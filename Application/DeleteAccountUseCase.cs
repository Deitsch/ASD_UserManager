using Application.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IDeleteAccountUseCase : IUseCase<DeleteAccountRequest, DeleteAccountResponse>
    {
    }

    public struct DeleteAccountRequest
    {
        public readonly Guid AccountId;

        public DeleteAccountRequest(Guid accountId)
        {
            AccountId = accountId;
        }
    }

    public struct DeleteAccountResponse
    { }

    public class DeleteAccountUseCase : IDeleteAccountUseCase
    {
        readonly IAccountRepository accountRepository;

        public DeleteAccountUseCase(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public DeleteAccountResponse Execute(DeleteAccountRequest request)
        {
            accountRepository.Delete(request.AccountId);
            return new DeleteAccountResponse();
        }
    }
}
