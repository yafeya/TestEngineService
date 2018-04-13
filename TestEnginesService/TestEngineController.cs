using System;
using System.Web.Http;
using TaaS.Common;

namespace TaaS.TestEnginesService
{
    public class TestEngineController : ApiController
    {
        private static Type EngineType = typeof(TestEngine);

        [HttpPut]
        public void StartEngine(RawArg[] args)
        {
            var engine = GetTestEngine();
            var request = new RawRequest();
            if (args != null && args.Length > 0)
            {
                request.Args = args;
            }
            engine?.Start(request);
        }

        [HttpGet]
        public RawResponse GetStatus()
        {
            var engine = GetTestEngine();
            var response = engine?.GetStatus();
            return response;
        }

        private TestEngine GetTestEngine()
        {
            return Configuration.Properties[KnownConsts.Engine] as TestEngine;
        }
    }
}
