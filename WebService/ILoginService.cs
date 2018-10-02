using ReshimgathiMatrimony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILoginService" in both code and config file together.
    [ServiceContract]
    public interface ILoginService
    {
        [OperationContract]
        bool IsLoggedUserPresent(string username, string password);

        [OperationContract]
        bool IsLogInUserVerified(string userName, string password);

        [OperationContract]
        UserDetails GetUserDetails(string userName, string password);

        [OperationContract]
        UserType LoggedUserType(string userName, string Password);
    }
}
