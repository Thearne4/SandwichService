using System;
using System.Web.Http;
using TheArne4.SandwichService.Models;

namespace SandwichsService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            Console.WriteLine(SandwichProvider.GetSandwiches());
        }
    }
}
