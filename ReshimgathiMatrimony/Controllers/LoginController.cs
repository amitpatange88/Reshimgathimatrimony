using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReshimgathiMatrimony.Controllers
{
    public class LoginController : Controller
    {
       
        public ActionResult Index()
        {   
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ReshimgathiMatrimony.Models.Login model)
        {
            if (ModelState.IsValid)
            {
                using (ReshimgathiMatrimonyEntities db = new ReshimgathiMatrimonyEntities())
                {
                    bool loginStatus = db.Logins.Select(x => x.UserName == model.UserName && x.Password == model.Password).FirstOrDefault();
                    var userDetails = db.Logins.Where(x => x.UserName == model.UserName && x.Password == model.Password).FirstOrDefault();

                    if (loginStatus && (bool)userDetails.IsVerified && userDetails.UserType == (bool)Enum.Parse(UserType.User.GetType(), UserType.User.ToString()))
                    {
                        Session["UserID"] = userDetails.Id;
                        return RedirectToAction("Index", "Dashboard");
                    }
                }
            }

            return View();
        }
        
    }
}
