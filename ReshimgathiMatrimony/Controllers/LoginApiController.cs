using Newtonsoft.Json;
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
        [Route("userexistance")]
        [HttpPost]
        public bool CheckIfUserExist(string userName, string password)
        {
            bool IsUserExist = false;
            LoginOperations loginOp = new LoginOperations();
            IsUserExist = loginOp.IsLoggedUserPresent(userName, password);

            return IsUserExist;
        }

        [Route("userauthenticated")]
        [HttpPost]
        public bool CheckIfUserAuthenticated(string userName, string password)
        {
            bool IsUserAuthenticated = false;
            LoginOperations loginOp = new LoginOperations();
            IsUserAuthenticated = loginOp.IsLogInUserVerified(userName, password);

            return IsUserAuthenticated;
        }

        [Route("check")]
        [HttpPost]
        public HttpResponseMessage ValidateUserForLogin(string userName, string password)
        {
            bool IsDone = false;
            List<Customer> user = new List<Customer>();
            Customer cust = new Customer();

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

    /// <summary>
    /// Customer class
    /// </summary>
    public class Customer
    {
        [JsonProperty("LoginId")]
        public System.Guid Id { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("UserType")]
        public Nullable<bool> UserType { get; set; }

        [JsonProperty("IsVerified")]
        public Nullable<bool> IsVerified { get; set; }

        [JsonProperty("CreateDate")]
        public Nullable<System.DateTime> CreateDate { get; set; }

        [JsonProperty("UpdatedDate")]
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
