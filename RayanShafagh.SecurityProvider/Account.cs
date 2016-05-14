using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace RayanShafagh.SecurityProvider
{
    public class Account:IAccount
    {

        public Account(string emailAddress, string password, string salt, HashAlgorithm algorithm)
        {
            this.loggedIn = false;
            this.emailAddress = emailAddress;
            this.password = password;
            this.algorithm = algorithm;
            this.salt = salt;
        }

        private string emailAddress, salt, password;
        private bool loggedIn;
        private HashAlgorithm algorithm;

        public string EmailAddress
        {
            get { return emailAddress; }
        }

        public string Password
        {
            get { return password; }
        }

        public bool LoggedIn
        {
            get { return loggedIn; }
        }

        public DateTime LoginDate { get; private set; }

        public bool Login(AuthenticationDelegate Authenticate)
        {
            try
            {
                this.loggedIn = Authenticate(this.salt, this.algorithm);
                if (loggedIn)
                {
                    LoginDate = DateTime.Now;
                }
                return this.loggedIn;
            }
            catch (Exception ex)
            {
                throw new AuthenticationException(this, 
                                                  string.Format(
                                                  "There is a problem in Authentication process, inner exception is: {0}.",
                                                  ex.ToString())
                                                  );
            }
        }

        public HashAlgorithm Algorithm
        {
            get { return algorithm; }
        }
    }
}
