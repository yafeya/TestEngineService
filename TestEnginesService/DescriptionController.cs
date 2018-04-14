using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using TaaS.Common;

namespace TaaS.TestEnginesService
{
    public class DescriptionController : ApiController
    {
        [HttpGet]
        public TestEngineDescription GetEngineDescription()
        {
            var engine = GetTestEngine();
            var description = new TestEngineDescription
            {
                Name = engine.Name,
                Description = engine.Description,
                Location = engine.Location,
                Configuration = engine.Configuration
            };
            return description;
        }

        private TestEngine GetTestEngine()
        {
            return Configuration.Properties[KnownConsts.Engine] as TestEngine;
        }
    }

    public class TestEngineDescription
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public RawConfigInfo Configuration { get; set; }
    }
}
