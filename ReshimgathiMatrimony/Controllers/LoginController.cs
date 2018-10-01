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
    public class LoginController : Controller
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ReshimgathiMatrimony.Models.Login model)
        {
            throw new Exception("Manual exception thrown.");
            if (ModelState.IsValid)
            {
                LoginOperations loginOp = new LoginOperations();
                bool loginStatus = loginOp.IsLoggedUserPresent(model.UserName, model.Password);

                if (loginStatus)
                {
                    bool IsVerified = loginOp.IsLogInUserVerified(model.UserName, model.Password);
                    if (IsVerified)
                    {
                        UserType type = loginOp.LoggedUserType(model.UserName, model.Password);
                        var userDetails = loginOp.GetUserDetails(model.UserName, model.Password);
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
                        ModelState.AddModelError(string.Empty, "Logging user is not verified either by Email address or Phone number. Please verify the user.");
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
