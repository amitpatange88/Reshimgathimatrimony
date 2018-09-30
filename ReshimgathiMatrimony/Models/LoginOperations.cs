using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReshimgathiMatrimony.Models
{
    public class LoginOperations
    {
        public Guid Add(ReshimgathiMatrimony.Models.Login data)
        {
            ReshimgathiMatrimony.Login record = new ReshimgathiMatrimony.Login();
            record.Id = Guid.NewGuid();
            record.UserName = data.UserName;
            record.Password = data.Password;
            record.UserType = false;
            record.IsVerified = false;
            record.CreateDate = DateTime.Now;
            record.UpdatedDate = DateTime.Now;

            using (ReshimgathiMatrimonyEntities db = new ReshimgathiMatrimonyEntities())
            {
                var response = db.Logins.Add(record);
                db.SaveChanges();
                if(response != null)
                {
                    return record.Id;
                }
            }

            return Guid.Empty;
        }

        public bool IsLoggedUserPresent(string UserName, string Password)
        {
            using (ReshimgathiMatrimonyEntities db = new ReshimgathiMatrimonyEntities())
            {
                var IsUSerPresent = db.Logins.Where(x => x.UserName == UserName && x.Password == Password).FirstOrDefault();

                if (IsUSerPresent != null)
                {
                    return true;
                }
            }

            return false;
        }


        public bool IsLogInUserVerified(string UserName, string Password)
        {
            using (ReshimgathiMatrimonyEntities db = new ReshimgathiMatrimonyEntities())
            {
                var userDetails = db.Logins.Where(x => x.UserName == UserName && x.Password == Password).FirstOrDefault();

                if ((bool)userDetails.IsVerified)
                {
                    return true;
                }
            }

            return false;
        }

        public UserType LoggedUserType(string UserName, string Password)
        {
            using (ReshimgathiMatrimonyEntities db = new ReshimgathiMatrimonyEntities())
            {
                var userDetails = db.Logins.Where(x => x.UserName == UserName && x.Password == Password).FirstOrDefault();
                bool userType = Convert.ToBoolean((int)Enum.Parse(UserType.User.GetType(), UserType.User.ToString()));

                if (userDetails.UserType == userType)
                {
                    return UserType.User;
                }
                else
                {
                    return UserType.Admin;
                }
            }
        }

        public ReshimgathiMatrimony.Login GetUserDetails(string UserName, string Password)
        {
            using (ReshimgathiMatrimonyEntities db = new ReshimgathiMatrimonyEntities())
            {
                var userDetails = db.Logins.Where(x => x.UserName == UserName && x.Password == Password).FirstOrDefault();

                return userDetails;
            }
        }
    }
}