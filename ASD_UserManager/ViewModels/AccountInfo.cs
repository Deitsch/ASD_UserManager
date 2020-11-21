using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD_UserManager.ViewModels
{
    public struct AccountInfo
    {
        public readonly string Id;

        public readonly string UserName;

        public readonly string FirstName;

        public readonly string LastName;

        public AccountInfo(string id, string userName, string firstName, string lastName)
        {
            Id = id;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
