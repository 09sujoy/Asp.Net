using BLL.Entity;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        public static string ValidToken(string key)
        {
            var data = DataAccessFactory.TokenDataAccess().Get(key);
            if (data != null && data.expireat == null)
            {
                if(data.user.u_category == "Admin")
                {
                    return "Admin";
                }
                else if(data.user.u_category == "Supervisor")
                {
                    return "Supervisor";
                }
                else if(data.user.u_category == "Doctor")
                {
                    return "Doctor";
                }
                else if(data.user.u_category == "Patient")
                {
                    return "Patient";
                }
               
            }
            return null;
        }
        public static string Authenticate(string uname, string upass)
        {
            var data = DataAccessFactory.AuthDataAccess().Authenticate(uname,upass);
            if(data != null)
            {
                return "Successfuly Loggedin";
            }
            return "Something Went Wrong";
        }
    }
}
