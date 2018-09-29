using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.Mvc;

namespace ReshimgathiMatrimony
{
    public sealed class SessionManager
    {
        private static SessionManager instance = null;
        private static readonly object obj = new object();
        private static HttpContextBase _context = null;

        public static HttpContextBase Context
        {
            get
            {
                return _context;
            }
            set
            {
                _context = value;
            }
        }

        public static SessionManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                            return new SessionManager();
                    }
                }

                return instance;
            }
        }

        private SessionManager()
        {
        }

        public string GetSession()
        {
            HttpSessionState sessionValue = HttpContext.Current.Session;
            string SessionId =sessionValue.SessionID.ToString();

            return SessionId;
        }

        public void SetSession()
        {
            _context.Session["SessionId"] = GetSession();
            _context.Session["IsLogin"] = "none";
            _context.Session["IsLogout"] = "block";
        }

        public void ClearSession()
        {
            _context.Session["IsLogin"] = "block";
            _context.Session["IsLogout"] = "none";
            _context.Session["SessionId"] = string.Empty;
        }

        public void SetSessionVariable(string key, string value)
        {
            _context.Session[key] = value;
        }
    }
}