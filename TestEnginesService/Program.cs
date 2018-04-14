using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using TaaS.Common;

namespace TaaS.TestEnginesService
{
    class Program
    {
        static void Main(string[] args)
        {
            var pluginDir = ConfigurationManager.AppSettings["pluginDir"];
            var loader = new AddinLoader();
            var engines = loader.GetEngines(pluginDir);
            var appList = new List<IDisposable>();
            foreach (var engine in engines)
            {
                IDisposable app = StartServing(engine);
                if (app != null)
                {
                    appList.Add(app);
                }
            }
            Console.ReadKey();
            foreach (var app in appList)
            {
                app.Dispose();
            }
        }

        private static IDisposable StartServing(TestEngine engine)
        {
            var port = engine.ServingPort;
            if (port <= 0 || port > 65535) return null;
            var url = $"http://*:{port}";
            var options = new StartOptions(url);
            Action<IAppBuilder> startAction = appBuilder =>
            {
                var config = new HttpConfiguration();
                config.Properties[KnownConsts.Engine] = engine;
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{action}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );

                appBuilder.UseCors(CorsOptions.AllowAll);
                appBuilder.UseWebApi(config);
            };

            var app = WebApp.Start(options, startAction);
            Console.WriteLine($"{engine.Name} started...");
            return app;
        }
    }
}
