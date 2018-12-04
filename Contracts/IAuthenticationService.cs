using FMB.Services;
using FMBPublic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMB.Controllers
{
    public interface IAuthenticationService
    {
        User Authenticate(string ConnectionString,string UserName, string Password);

        User GetUserByUserName(string ConnectionString,string UserName);
        List<WebInfoDatabaseAccess> GetAccessibleDatabases(string cs, string user);
    }
}
