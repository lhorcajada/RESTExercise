using System.Diagnostics.CodeAnalysis;
using System.Web.Http;

namespace APIRest
{
    public static class WebApiConfig
    {
        [ExcludeFromCodeCoverage]

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            AutofacContainerConfig.Configure();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
