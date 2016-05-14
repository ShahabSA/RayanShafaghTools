using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace RayanShafagh.SecurityProvider
{
    public class AuthenticationException:Exception
    {
        private string message;
        private IAccount account;

        public AuthenticationException(IAccount account,string message)
        {
            this.account = account;
            this.message = message;
        }

        public override string Message
        {
            get { return this.message; }
        }

        public IAccount Account
        {
            get { return account; }
        }

        
    }
}
