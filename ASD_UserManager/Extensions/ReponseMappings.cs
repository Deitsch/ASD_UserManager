using Application;
using ASD_UserManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD_UserManager.Extensions
{
    public static class ReponseMappings
    {
        public static AccountInfo toAccountInfoViewModel(this LoginResponse response)
            => new AccountInfo(response.Id, response.UserName, response.FirstName, response.LastName);
    }
}
