﻿using System;
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
            //SessionManagerController.Instance.InitializeSession();
            
            ViewBag.Title = "Home Page";
            return View(); 
        }
    }
}
