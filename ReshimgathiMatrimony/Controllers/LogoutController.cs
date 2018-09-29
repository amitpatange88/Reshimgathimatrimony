using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReshimgathiMatrimony.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult Index()
        {
            //SessionManagerController.Instance.ClearSession();
            ClearSession();
            return RedirectToAction("Index", "Login");
        }

        public void ClearSession()
        {
            Session["IsLogin"] = "block";
            Session["IsLogout"] = "none";
            Session["SessionId"] = string.Empty;
        }
    }
}