using IotApi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace IotApi
{
    public class BasicAuth: AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "Test");
                
            }
            else
            {
                string decode = Encoding.UTF8.GetString(Convert.FromBase64String(actionContext.Request.Headers.Authorization.Parameter));
                string [] a = decode.Split(':');
                if (!BasicAuthValidation.ValidateUserPassword(a[0],a[1]))
                { 
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "fail to login");
                }
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(a[0]), null);

            }
            base.OnAuthorization(actionContext);
        }
    }
}