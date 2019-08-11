using System.Web.Http;
using ToDo.WebAPI.Authentication;
using ToDo.WebAPI.Handler;
using System.Web.Http.Cors;

namespace ToDo.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Filters.Add(new BasicAuthenticationAttribute());
            config.MessageHandlers.Add(new LogRequestAndResponseHandler());
            
            //config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
        }
    }
}
