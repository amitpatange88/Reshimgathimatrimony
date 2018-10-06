using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReshimgathiMatrimony.Models;

namespace ReshimgathiMatrimony.Controllers
{
    [SnatchException]
    [HandleError]
    public class SigninController : Controller
    {
        private static Guid UserLoginId = Guid.Empty;
        private static bool? BaseUserType;

        public ActionResult Index()
        {
            ReshimgathiMatrimony.Models.Login model = new ReshimgathiMatrimony.Models.Login();

            if (!string.IsNullOrEmpty(Session["SessionId"].ToString()))
            {
                if (BaseUserType == false)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else if (BaseUserType == true)
                {
                    //Admin user goes here.
                    return RedirectToAction("Index", "Admin");
                }
            }

            return View(model);
        }

        /// <summary>
        /// This login post index action being called when we submit the form data for login action.
        /// Here we use the WCF services hosted either by self hosting tech or windows services.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ReshimgathiMatrimony.Models.Login model)
        {
            if (ModelState.IsValid)
            {
                //LoginOperations loginOp = new LoginOperations();

                //use this WSHttpBinding_ILoginService for http protocol communication 
                LoginServices.LoginServiceClient client = new LoginServices.LoginServiceClient("WSHttpBinding_ILoginService");

                //use this NetTcpBinding_ILoginService when we want communication should be carried out through TCP protocol.
                //LoginServices.LoginServiceClient client = new LoginServices.LoginServiceClient("NetTcpBinding_ILoginService");

                bool loginStatus = client.IsLoggedUserPresent(model.UserName, model.Password);
                //bool loginStatus = loginOp.IsLoggedUserPresent(model.UserName, model.Password);

                if (loginStatus)
                {
                    //WCF service call.
                    //bool IsVerified = loginOp.IsLogInUserVerified(model.UserName, model.Password);
                    bool IsVerified = client.IsLogInUserVerified(model.UserName, model.Password);

                    if (IsVerified)
                    {
                        UserType type = (UserType)client.LoggedUserType(model.UserName, model.Password);
                        var userDetails = client.GetUserDetails(model.UserName, model.Password);

                        UserLoginId = userDetails.Id;
                        BaseUserType = userDetails.UserType;
                        SetSession();

                        if (type == UserType.User)
                        {
                            return RedirectToAction("Index", "Dashboard");
                        }
                        else
                        {
                            //Admin user goes here.
                            return RedirectToAction("Index", "Admin");
                        }
                    }
                    else
                    {
                        //User is not verified. He/she needs to verify account by his/her email address or Phone number. 
                        ModelState.AddModelError(string.Empty, "Signing user is not verified either by Email address or Phone number. Please verify the user.");
                    }
                }
                else
                {
                    //default Index Get view with ErrorMessage. Username and password are wrong.
                    ModelState.AddModelError(string.Empty, "Username or password are not correct. Please try again with the correct details.");
                }
            }

            return View(model);
        }

        public void SetSession()
        {
            Session["SessionId"] = GetSession();
            Session["IsLogin"] = "none";
            Session["IsLogout"] = "block";
            Session["LoginId"] = UserLoginId;
            Session["UserType"] = BaseUserType;
        }

        public string GetSession()
        {
            return Session.SessionID.ToString();
        }
    }
}
