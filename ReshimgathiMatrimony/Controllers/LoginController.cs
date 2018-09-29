using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReshimgathiMatrimony.Models;

namespace ReshimgathiMatrimony.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {   
            return View(); 
        }

        [HttpPost]//[ValidateAntiForgeryToken]
        public ActionResult Index(ReshimgathiMatrimony.Models.Login model)
        {
            if (ModelState.IsValid)
            {
                LoginOperations loginOp = new LoginOperations();
                bool loginStatus = loginOp.IsLoggedUserPresent(model.UserName, model.Password);

                if (loginStatus)
                {
                    bool IsVerified = loginOp.IsLogInUserVerified(model.UserName, model.Password);
                    if(IsVerified)
                    {
                        UserType type = loginOp.LoggedUserType(model.UserName, model.Password);
                        if(type == UserType.User)
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
                    ModelState.AddModelError(string.Empty, "Username or password are not correct. Please try again with the correct details.");
                    //default Index Get view with ErrorMessage
                    //Username and password are wrong.
                }
            }

            return View();
        }
        
    }
}
