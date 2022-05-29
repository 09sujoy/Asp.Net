using BLL.Entity;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ConsoleApi.Controllers
{
    public class AuthController : ApiController
    {
        [Route("api/Auth/Login")]
        [HttpPost]
        public HttpResponseMessage Login(userModel obj)
        {
            var data = AuthService.Authenticate(obj.u_name, obj.u_password);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
