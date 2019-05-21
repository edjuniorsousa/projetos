using ProjetoDDD.API.Filters;
using ProjetoDDD.API.Handlers;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace ProjetoDDD.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Add Custom validation filters 
            config.Filters.Add(new CheckModelForNullAttribute());
            config.Filters.Add(new ValidateModelStateAttribute());
            config.MessageHandlers.Add(new ResponseWrappingHandler());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
        }
    }
}
