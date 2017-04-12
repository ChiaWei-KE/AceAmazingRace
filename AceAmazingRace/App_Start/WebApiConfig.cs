using System.Net.Http.Headers;
using System.Web.Http;

namespace AceAmazingRace
{
    public class WebApiConfig
    {
          public static void Register(HttpConfiguration configuration)
          {
                configuration.Formatters.JsonFormatter.SupportedMediaTypes
                    .Add(new MediaTypeHeaderValue("text/html") );
                
                configuration.MapHttpAttributeRoutes();

                configuration.Routes.MapHttpRoute("API Default", "api/{controller}/{id}",
                    new { id = RouteParameter.Optional });
          }
    }
}