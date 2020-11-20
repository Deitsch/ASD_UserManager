using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public struct AccountInfo
    {
        public readonly Guid Id;

        public readonly string UserName;

        public readonly string FirstName;

        public readonly string LastName;

        public AccountInfo(Guid id, string userName, string firstName, string lastName)
        {
            Id = id;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
