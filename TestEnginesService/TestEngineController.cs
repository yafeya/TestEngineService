using System;
using System.Web.Http;
using TaaS.Common;

namespace TaaS.TestEnginesService
{
    public class TestEngineController : ApiController
    {
        private static Type EngineType = typeof(TestEngine);

        [HttpPut]
        public RawResponse StartEngine(RawArg[] args)
        {
            var engine = GetTestEngine();
            var request = new RawRequest();
            var response = new RawResponse();
            if (args != null && args.Length > 0)
            {
                request.Args = args;
            }
            if (engine != null)
            {
                var result = engine.Start(request);
                response.BindTo(result);
            }
            return response;
        }

        [HttpPut]
        public RawResponse StopEngine(RawArg[] args)
        {
            var engine = GetTestEngine();
            var request = new RawRequest();
            var response = new RawResponse();
            if (args != null && args.Length > 0)
            {
                request.Args = args;
            }
            if (engine != null)
            {
                var result = engine.Stop(request);
                response.BindTo(result);
            }
            return response;
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
