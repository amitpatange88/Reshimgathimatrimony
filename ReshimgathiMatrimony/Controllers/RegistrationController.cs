using ReshimgathiMatrimony.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReshimgathiMatrimony.Controllers
{
    [SnatchException]
    public class RegistrationController : Controller
    {
        // GET: Registration

        public ActionResult Index()
        {
            Registration model = new Registration();

            InitializeSession();
            return View(model);
        }

        // Post: Registration
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ReshimgathiMatrimony.Models.Registration model)
        {
            bool IsRecordAdded = false;
            if (ModelState.IsValid)
            {
                RegistrationOperations Reg = new RegistrationOperations();
                bool IsUsernameExist = Reg.CheckUserNameAvailability(model.UserName);
                if(IsUsernameExist)
                {
                    ModelState.AddModelError(string.Empty, "Username is already exists. Please try another username.");
                }

                bool response = Reg.ValidateInputs(model);

                if (response)
                {
                   IsRecordAdded = Reg.Add(model);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Input validation failed. Please provide valida details.");
                }

                if(IsRecordAdded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server is busy. Please try again later.");
                }
            }

            return View(model);
        }

        public void ClearSession()
        {
            Session["IsLogin"] = "block";
            Session["IsLogout"] = "none";
            Session["SessionId"] = string.Empty;
        }

        public void InitializeSession()
        {
            if (Session["SessionId"] == null)
            {
                ClearSession();
            }
        }
    }
}