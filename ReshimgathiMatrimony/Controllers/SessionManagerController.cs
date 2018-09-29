using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace ReshimgathiMatrimony.Controllers
{
    public class SessionManagerController : Controller
    {
        private static SessionManagerController instance = null;
        private static readonly object obj = new object();

        public static SessionManagerController Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                            return new SessionManagerController();
                    }
                }

                return instance;
            }
        }

        private SessionManagerController()
        {
        }

        public string GetSession()
        {
            return Session.SessionID.ToString();
        }

        public void SetSession()
        {
            Session["SessionId"] = GetSession();
            Session["IsLogin"] = "none";
            Session["IsLogout"] = "block";
        }

        public void ClearSession()
        {
            Session["IsLogin"] = "block";
            Session["IsLogout"] = "none";
            Session["SessionId"] = string.Empty;
        }

        public void SetSessionVariable(string key, string value)
        {
            Session[key] = value;
        }

        public bool IsSessionSet()
        {
            string SessionId = System.Web.HttpContext.Current.Session["SessionId"].ToString();
            if (SessionId == null)
            {
                return false;
            }

            return true;
        }

        public void InitializeSession()
        {
            if (!IsSessionSet())
            {
                ClearSession();
            }
        }
    }
}