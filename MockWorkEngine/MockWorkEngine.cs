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
        public override RawResponse GetStatus(RawRequest request)
        {
            var response = new RawResponse();
            var worker = new Worker();
            response.Value = worker.Work().ToString();
            Console.WriteLine($"{Name}: curent status is {response.Value}");
            return response;
        }

        public override void Start(RawRequest request)
        {
            var response = new RawResponse();
            var worker = new Worker();
            Console.WriteLine($"{Name} Started {worker.Work().ToString()}");
        }

        protected override string GetDescription()
        {
            return "This is a mock worker engine";
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
