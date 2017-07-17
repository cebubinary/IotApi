using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IotApi.Utils
{
    public class BasicAuthValidation
    {
        public static bool ValidateUserPassword(string username, string password) 
            => username == "username" && password == "password";
        
    }
}