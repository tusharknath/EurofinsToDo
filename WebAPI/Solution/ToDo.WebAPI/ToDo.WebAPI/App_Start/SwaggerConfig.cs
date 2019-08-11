using System.Web.Http;
using WebActivatorEx;
using ToDo.WebAPI;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace ToDo.WebAPI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
           .EnableSwagger(c => c.SingleApiVersion("V1", "EuroFinsTodo"))
           .EnableSwaggerUi();
        }

    }
}
