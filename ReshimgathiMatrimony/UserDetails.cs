using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReshimgathiMatrimony
{
    /// <summary>
    /// Customer class
    /// </summary>
    public class UserDetails
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