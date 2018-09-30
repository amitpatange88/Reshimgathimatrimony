using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReshimgathiMatrimony.Models
{
    public class RegistrationOperations
    {
        public bool Add(Registration model)
        {
            Login data = new Login();
            data.UserName = model.UserName;
            data.Password = model.Password;

            using (ReshimgathiMatrimonyEntities db = new ReshimgathiMatrimonyEntities())
            {
                //Create Login record first and return LoginId
                LoginOperations log = new LoginOperations();
                Guid LoginId = log.Add(data);

                if(LoginId == Guid.Empty)
                    throw new Exception("Login record is not created due to server error. Please try again.");

                RegistrationPhase1 record = new RegistrationPhase1();
                record.Id = Guid.NewGuid();
                record.LoginId = LoginId;
                record.ReshimgathiId = Reshimgathi.Instance.GenerateReshimgathiId();
                record.FirstName = model.FirstName;
                record.LastName = model.LastName;
                record.EmailId = model.EmailId;
                record.PhoneNumber = model.PhoneNumber;
                record.IsEmailVerified = false;
                record.IsPhoneVerified = false;
                record.CreateDate = DateTime.Now;
                record.UpdatedDate = DateTime.Now;

                var response = db.RegistrationPhase1.Add(record);
                db.SaveChanges();

                if (response != null)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CheckUserNameAvailability(string userName)
        {
            using (ReshimgathiMatrimonyEntities db = new ReshimgathiMatrimonyEntities())
            {
                var userDetails = db.Logins.Where(x => x.UserName == userName).FirstOrDefault();

                if (userDetails != null)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Validates input parameters of the model.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ValidateInputs(Registration model)
        {
            return true;
        }
    }
}