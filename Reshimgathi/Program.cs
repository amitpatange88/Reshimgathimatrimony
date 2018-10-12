using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Reshimgathi
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost loginService = new ServiceHost(typeof(WebService.LoginService));
            loginService.Open();
            Console.WriteLine("Login Host started @" + DateTime.Now.ToString());

            ServiceHost registrationPhaseIService = new ServiceHost(typeof(WebService.RegistrationPhaseI));
            registrationPhaseIService.Open();
            Console.WriteLine("Registration Host started @" + DateTime.Now.ToString());


            //Close function used to close the opened webservice connection.
            //loginService.Close();   registrationPhaseIService.Close();
            Console.ReadLine();
        }
    }
}
