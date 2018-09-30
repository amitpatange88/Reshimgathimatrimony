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
    }
}