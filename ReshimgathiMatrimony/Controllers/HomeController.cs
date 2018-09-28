using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReshimgathiMatrimony.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ReshimgathiMatrimonyEntities dbContext = new ReshimgathiMatrimonyEntities();
            var appConstantsValues = dbContext.AppConstants.Take(1);
            ViewBag.Title = "Home Page";
            ViewBag.Company = appConstantsValues.Select(x=>x.Value).FirstOrDefault();

            return View(); 
        }
    }
}
