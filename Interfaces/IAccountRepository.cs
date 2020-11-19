using System;
using Domain;

namespace Application.Contract
{
    public interface IAccountRepository: IRepo<Account>
    {
        Account Read(String username);
    }
}
