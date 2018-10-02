using ReshimgathiMatrimony;
using ReshimgathiMatrimony.Models;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoginService" in both code and config file together.
    public class LoginService : ILoginService
    {
        public bool CheckIfUserExist(string username, string password)
        {
            bool IsUserExist = false;
            LoginOperations loginOp = new LoginOperations();
            IsUserExist = loginOp.IsLoggedUserPresent(username, password);

            return IsUserExist;
        }

        public bool CheckIfUserAuthenticated(string userName, string password)
        {
            bool IsUserAuthenticated = false;
            LoginOperations loginOp = new LoginOperations();
            IsUserAuthenticated = loginOp.IsLogInUserVerified(userName, password);

            return IsUserAuthenticated;
        }

        public List<UserDetails> ValidateUserForLogin(string userName, string password)
        {
            bool IsDone = false;
            List<UserDetails> user = new List<UserDetails>();
            UserDetails cust = new UserDetails();

            if (CheckIfUserExist(userName, password))
                if (CheckIfUserAuthenticated(userName, password))
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
            else
            {
                user.Add(cust);
            }

            return user;
        }
    }
}
