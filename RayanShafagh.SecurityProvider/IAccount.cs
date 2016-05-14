using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace RayanShafagh.SecurityProvider
{
    public interface IAccount
    {
        string EmailAddress { get; }
        string Password { get; }
        bool LoggedIn { get; }
        bool Login(AuthenticationDelegate Authenticate);
    }

}
