﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReshimgathiMatrimony.Controllers
{
    [SnatchException]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            InitializeSession();
            ViewBag.Title = "Home Page";
            return View(); 
        }

        /// <summary>
        /// Clear the session variables
        /// </summary>
        public void ClearSession()
        {
            Session["IsLogin"] = "block";
            Session["IsLogout"] = "none";
            Session["SessionId"] = string.Empty;
        }

        /// <summary>
        /// Initializ the session and if not then clear the session call.
        /// </summary>
        public void InitializeSession()
        {
            if(Session["SessionId"] == null)
            {
                ClearSession();
            }
        }
    }
}
