using System;
using Domain;

namespace Interfaces
{
    public interface IAccountRepository: IRepo<Account>
    {
        Account Read(String username);
    }
}
