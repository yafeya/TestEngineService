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
        public override RawResponse GetStatus(RawRequest request)
        {
            var response = new RawResponse();
            var worker = new Worker();
            response.Value = worker.Work().ToString();
            return response;
        }

        public override void Start(RawRequest request)
        { }

        protected override string GetDescription()
        {
            return "This is a mock test engine";
        }

        protected override string GetName()
        {
            return "Mock-TestEngine";
        }

        protected override int GetServingPort()
        {
            return 9250;
        }
    }
}
