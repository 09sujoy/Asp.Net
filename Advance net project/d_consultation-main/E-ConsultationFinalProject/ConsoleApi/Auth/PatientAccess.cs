using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ConsoleApi.Auth
{
    public class PatientAccess : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers.Authorization;
            if (token == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.NotFound, "No Token Found");

            }
            else
            {
                var vt = AuthService.ValidToken(token.ToString());
                if (vt != "Patient")
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden, "Access Denied");

                }
            }
            base.OnAuthorization(actionContext);
        }
    }
}