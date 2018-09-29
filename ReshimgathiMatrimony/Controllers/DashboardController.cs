using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace ReshimgathiMatrimony.Controllers
{
    //[SessionState(SessionStateBehavior.Required)]
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            //SessionManagerController.Instance.InitializeSession();
            return View(); 
        }
    }
}
