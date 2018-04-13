using MockLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaaS.Common;

namespace MockTestEngine
{
    public class MockTestEngine : TestEngine
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
            response.Succeed = true;
            var worker = new Worker();
            var message = $"{Name} Started {worker.Work().ToString()}";
            Console.WriteLine(message);
            response.ProgressMessage = message;
            return response;
        }

        public override RawResponse Stop(RawRequest request)
        {
            var response = new RawResponse();
            response.Succeed = true;
            var message = $"{Name} Stopped.";
            response.ProgressMessage = message;
            Console.WriteLine(message);
            return response;
        }

        protected override RawConfigInfo GetConfigration()
        {
            var config = new RawConfigInfo
            {
                NeedArgs = false
            };
            return config;
        }

        protected override string GetDescription()
        {
            return "This is a mock test engine";
        }

        protected override string GetLocation()
        {
            return "Beijing Site A4-18";
        }

        protected override string GetName()
        {
            return "Mock-Test-Engine";
        }

        protected override int GetServingPort()
        {
            return 9250;
        }
    }
}
