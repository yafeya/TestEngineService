using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaaS.TestEnginesService
{
    class Program
    {
        static void Main(string[] args)
        {
            var pluginDir = ConfigurationManager.AppSettings["pluginDir"];
            var loader = new AddinLoader();
            var engines = loader.GetEngines(pluginDir);

            foreach (var engine in engines)
            {
                Console.WriteLine($"Engine: {engine.Name} -- {engine.Description}");
            }

            Console.ReadKey();
        }
    }
}
