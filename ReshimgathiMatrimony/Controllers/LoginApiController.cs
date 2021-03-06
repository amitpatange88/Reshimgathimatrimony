﻿using Newtonsoft.Json;
using ReshimgathiMatrimony.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ReshimgathiMatrimony.Controllers
{
    [RoutePrefix("api/login")]
    [SnatchException]
    public class LoginApiController : ApiController
    {
        [Route("IsLoggedUserPresent")]
        [HttpPost]
        public bool CheckIfUserExist(string userName, string password)
        {
            bool IsUserExist = false;
            LoginOperations loginOp = new LoginOperations();
            IsUserExist = loginOp.IsLoggedUserPresent(userName, password);

            return IsUserExist;
        }

        [Route("IsLogInUserVerified")]
        [HttpPost]
        public bool CheckIfUserAuthenticated(string userName, string password)
        {
            bool IsUserAuthenticated = false;
            LoginOperations loginOp = new LoginOperations();
            IsUserAuthenticated = loginOp.IsLogInUserVerified(userName, password);

            return IsUserAuthenticated;
        }

        [Route("GetUserDetails")]
        [HttpPost]
        public HttpResponseMessage GetUserDetails(string userName, string password)
        {
            bool IsDone = false;
            List<UserDetails> user = new List<UserDetails>();
            UserDetails cust = new UserDetails();

            if (CheckIfUserExist(userName, password))
                if (CheckIfUserAuthenticated(userName, password))
                    IsDone = true;
                    
            if (IsDone)
            {
                LoginOperations loginOp = new LoginOperations();
                var result = loginOp.GetUserDetails(userName, password);

                cust.Id = result.Id;
                cust.UserName = result.UserName;
                cust.UserType = result.UserType;
                cust.IsVerified = result.IsVerified;
                cust.CreateDate = result.CreateDate;
                cust.UpdatedDate = result.UpdatedDate;
            }
            else
            {
                user.Add(cust);
            }

            return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(user));
        }
    }
}
