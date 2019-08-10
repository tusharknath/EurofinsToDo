using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Mvc;
using ToDo.DomainLayer.Services;
using ToDo.WebAPI.Repository.UnitOfWork;

namespace ToDo.WebAPI.Authentication
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        private readonly IUserService _userService;

        public BasicAuthenticationAttribute()
        {
            IUnitOfWork _UoW = new UnitOfWork();
            IUserService userServiceParam = new UserService(_UoW);
            this._userService = userServiceParam;
        }
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (SkipAuthorization(actionContext)) return;

            var authHeader = actionContext.Request.Headers.Authorization;

            if (authHeader != null)
            {
                var authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                var decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                var usernamePasswordArray = decodedAuthenticationToken.Split(':');
                var userName = usernamePasswordArray[0];
                var password = usernamePasswordArray[1];

                var isValid = _userService.Authenticate(userName, password);

                if (isValid != null)
                {
                    //// setting current principle  
                    //Thread.CurrentPrincipal = new GenericPrincipal(
                    //new GenericIdentity(userName), null);

                    var identity = new GenericIdentity(userName);
                    SetPrincipal(new GenericPrincipal(identity, null));

                    return;
                }
                else
                {
                    actionContext.Response = actionContext.Request
                    .CreateResponse(HttpStatusCode.Unauthorized);
                }
            }

            HandleUnathorized(actionContext);
        }

        private static void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }

        private static void HandleUnathorized(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            actionContext.Response.Headers.Add("WWW-Authenticate", "Basic Scheme='Data' location = 'http://localhost:");
        }

        private static bool SkipAuthorization(HttpActionContext actionContext)
        {
            Contract.Assert(actionContext != null);

            return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()
                       || actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
        }

    }
}