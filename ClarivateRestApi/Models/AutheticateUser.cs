using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClarivateRestApi.Models
{
    public class AutheticateUser
    {
        public static bool VaidateUser(string username, string password)
        {
            User objloginUser = new User();
            if (objloginUser.Username == username && objloginUser.Password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
