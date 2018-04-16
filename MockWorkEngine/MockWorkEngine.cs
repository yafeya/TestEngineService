using MockLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaaS.Common;

namespace MockWorkEngine
{
    public class MockWorkEngine : TestEngine
    {
        public override RawResponse GetStatus()
        {
            var response = new RawResponse();
            var worker = new Worker();
            response.Value = worker.Work().ToString();
            Console.WriteLine($"{Name}: curent status is {response.Value}");
            return response;
        }

        public override RawResponse Start(RawRequest request)
        {
            var response = new RawResponse();
            var args = request.ToMap();
            var arg1 = args["Arg1"];
            var arg2 = args["Arg2"];
            if (arg1 == null || arg2 == null)
            {
                response.Succeed = false;
                response.ProgressMessage = "Lack of parameter.";
            }
            else
            {
                var worker = new Worker();
                var message = $"{Name} Started {worker.Work().ToString()}, Arg1 = {arg1.Value}, Arg2 = {arg2.Value}";
                Console.WriteLine(message);
                response.Succeed = true;
                response.ProgressMessage = message;
            }
            return response;
        }

        public override RawResponse Stop(RawRequest request)
        {
            var message = $"{Name} Stopped.";
            Console.WriteLine(message);
            var response = new RawResponse();
            response.Succeed = true;
            response.ProgressMessage = message;
            return response;
        }

        protected override RawConfigInfo GetConfigration()
        {
            var config = new RawConfigInfo();
            config.NeedArgs = true;
            config.TemplateArgs = new[] {
                new RawArg { Name = "Arg1", Type = RawTypes.StringType },
                new RawArg { Name = "Arg2", Type = RawTypes.NumberType }
            };
            return config;
        }

        protected override string GetDescription()
        {
            return "This is a mock worker engine";
        }

        protected override string GetLocation()
        {
            return "Beijing Site A4-18";
        }

        protected override string GetName()
        {
            return "Mock-Worker-Engine";
        }

        protected override int GetServingPort()
        {
            return 8250;
        }
    }
}
