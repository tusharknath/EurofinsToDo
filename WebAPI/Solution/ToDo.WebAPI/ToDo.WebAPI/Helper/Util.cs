using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;

namespace ToDo.WebAPI.Helper
{
    public static class Util
    {
        public static string GetUsername()
        {
            IPrincipal principal = Thread.CurrentPrincipal;
            IIdentity identity = principal == null ? null : principal.Identity;
            return identity == null ? null : identity.Name;
        }
    }
}