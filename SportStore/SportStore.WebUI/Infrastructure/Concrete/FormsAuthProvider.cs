using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using SportStore.WebUI.Infrastructure.Abstract;

namespace SportStore.WebUI.Infrastructure.Concrete
{
    public class FormsAuthProvider:IAuthProvider
    {
        /// <summary>
        /// Authenticates the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public bool Authenticate(string username, string password)
        {
            bool result = FormsAuthentication.Authenticate(username, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }
            return result;
        }

        /// <summary>
        /// Logouts this instance.
        /// </summary>
        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}