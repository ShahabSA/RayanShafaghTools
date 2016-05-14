using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;

namespace RayanShafagh.Web.Global.Session
{
    /// <summary>
    /// Provided by Rayan Shafagh Software Group
    /// to facilitate working with session state variables
    /// and avoid common mistakes...
    /// 
    /// Modified Date : 10/05/2015
    /// </summary>
    public static class Variables
    {
        #region Properties
		
        private static Dictionary<string,object> Defaults;

        /// <summary>
        /// Indicates logged in state of current session user.
        /// </summary>
        public static string LoggedIn
        {
            get
            {
                return "loggedin";
            }
        }

        /// <summary>
        /// Indicates UserID of current session user.
        /// </summary>
        public static string UserID
        {
            get
            {
                return "userid";
            }
        }

        /// <summary>
        /// Indicates DomainID of current session user.
        /// </summary>
        public static string DomainID
        {
            get
            {
                return "domainid";
            }
        }

        /// <summary>
        /// Indicates Permission Object of current session user.
        /// </summary>
        public static string Permissions
        {
            get
            {
                return "permissions";
            }
        }

        /// <summary>
        /// Indicates ShoppingCart Object of current session user.
        /// </summary>
        public static string ShoppingCart
        {
            get
            {
                return "shoppingcart";
            }
        }

        /// <summary>
        /// Indicates ID collection of items to be edited by current session user.
        /// </summary>
        public static string ItemToEditIDs
        {
            get
            {
                return "itemtoeditids";
            }
        }

        /// <summary>
        /// Indicates ID collection of items to be deleted by current session user.
        /// </summary>
        public static string ItemToDeleteIDs
        {
            get
            {
                return "itemtodeleteids";
            }
        }

        /// <summary>
        /// Indicates URL to which current session user should be reteurened.
        /// </summary>
        public static string ReturnURL
        {
            get
            {
                return "returnurl";
            }
        }

        /// <summary>
        /// Indicates URL to which current session user should be navigated.
        /// </summary>
        public static string RedirectURL
        {
            get
            {
                return "redirecturl";
            }
        }

        /// <summary>
        /// Indicates Message to be displayed to current session user.
        /// </summary>
        public static string DisplayMessage
        {
            get
            {
                return "diplaymessage";
            }
        }

        /// <summary>
        /// Indicates application level cache for site language info.
        /// </summary>
        public static string LanguageCache
        {
            get
            {
                return "languageCache";
            }
        }

        /// <summary>
        /// Indicates Language to be used for website.
        /// </summary>
        public static string CurrentLanguage
        {
            get
            {
                return "currentLanguage";
            }
        }

        /// <summary>
        /// Indicates captcha generated text for current user.
        /// </summary>
        public static string Captcha
        {
            get
            {
                return "CaptchaText";
            }
        }

	    #endregion
         
        #region Methods

        /// <summary>
        /// Initializes input HttpSessionState object with state variables and their defaults
        /// you can also set default values by calling static/shared "DeclareDefaultValues" method before
        /// calling this method or just call this method and use Rayan Shafagh defaults instead
        /// </summary>
        /// <param name="Session">An object of type System.Web.SessionStat.HttpSessionState which represents current user session</param>
        /// <returns>A System.Boolean which indicates if all defaults are set or an exception was thrown while setting defaults.
        /// It's strongly recommended to set defaults again if method returns false value.
        /// </returns>
        public static bool Initialize(HttpSessionState Session, bool isMVC = false)
        {
            try
            {
                if (Defaults == null)
                {
                    Session.Add(LoggedIn, false);
                    Session.Add(UserID, -1L);
                    Session.Add(DomainID, -1L);
                    Session.Add(ReturnURL, isMVC? "/" : "~");
                    Session.Add(RedirectURL, isMVC? "/" : "~");
                    Session.Add(Permissions, null);
                    Session.Add(DisplayMessage, "");
                    Session.Add(CurrentLanguage, "fa");
                    return true;
                }
                else
                {
                    Session.Add(LoggedIn, (bool)Defaults[LoggedIn]);
                    Session.Add(UserID, (long)Defaults[UserID]);
                    Session.Add(DomainID, (long)Defaults[DomainID]);
                    Session.Add(ReturnURL, Defaults[ReturnURL].ToString());
                    Session.Add(RedirectURL, Defaults[RedirectURL].ToString());
                    Session.Add(Permissions, Defaults[Permissions]);
                    Session.Add(DisplayMessage, Defaults[DisplayMessage].ToString());
                    Session.Add(CurrentLanguage, Defaults[CurrentLanguage].ToString());
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loggedIn">A System.Boolean which indicates default value for LoggedIn session state variable</param>
        /// <param name="userID">A System.Int64 which indicates default value for UserID session state variable</param>
        /// <param name="domainID">A System.Int64 which indicates default value for DomainID session state variable</param>
        /// <param name="returnURL">A System.String which indicates default value for ReturnURL session state variable</param>
        /// <param name="redirectURL">A System.String which indicates default value for RrdirectURL session state variable</param>
        /// <param name="permissions">A System.Object which indicates default value for Permissions collection session state variable</param>
        /// <param name="displayMessage">A System.String which indicates default value for DisplayMessage session state variable</param>
        public static void DeclareDefaultValues(bool loggedIn, 
                                                long userID, 
                                                long domainID,
                                                string returnURL, 
                                                string redirectURL, 
                                                object permissions,
                                                string displayMessage,
                                                string currentLanguage = "fa")
        {
            Defaults = new Dictionary<string, object>();
            Defaults.Add(LoggedIn, loggedIn);
            Defaults.Add(UserID, userID);
            Defaults.Add(DomainID, domainID);
            Defaults.Add(ReturnURL, returnURL);
            Defaults.Add(RedirectURL, redirectURL);
            Defaults.Add(Permissions, permissions);
            Defaults.Add(DisplayMessage, displayMessage);
            Defaults.Add(CurrentLanguage, currentLanguage);

        }

        /// <summary>
        /// Clears all declared default values.
        /// </summary>
        public static void RemoveDefaultValues()
        {
            Defaults = null;
        }

        #endregion

    }
}
