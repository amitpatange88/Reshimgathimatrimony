using ReshimgathiMatrimony;
using ReshimgathiMatrimony.Models;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoginService" in both code and config file together.
    public class LoginService : ILoginService
    {
        public bool IsLoggedUserPresent(string username, string password)
        {
            bool IsUserExist = false;
            LoginOperations loginOp = new LoginOperations();
            IsUserExist = loginOp.IsLoggedUserPresent(username, password);

            return IsUserExist;
        }

        public bool IsLogInUserVerified(string userName, string password)
        {
            bool IsUserAuthenticated = false;
            LoginOperations loginOp = new LoginOperations();
            IsUserAuthenticated = loginOp.IsLogInUserVerified(userName, password);

            return IsUserAuthenticated;
        }

        public UserDetails GetUserDetails(string userName, string password)
        {
            bool IsDone = false;
            UserDetails cust = new UserDetails();

            if (IsLoggedUserPresent(userName, password))
                if (IsLogInUserVerified(userName, password))
                    IsDone = true;

            if (IsDone)
            {
                LoginOperations loginOp = new LoginOperations();
                var result = loginOp.GetUserDetails(userName, password);

                cust.Id = result.Id;
                cust.UserName = result.UserName;
                cust.UserType = result.UserType;
                cust.IsVerified = result.IsVerified;
                cust.CreateDate = result.CreateDate;
                cust.UpdatedDate = result.UpdatedDate;
            }

            return cust;
        }

        public UserType LoggedUserType(string userName, string Password)
        {
            LoginOperations loginOp = new LoginOperations();

            return loginOp.LoggedUserType(userName, Password);
        }
    }
}
