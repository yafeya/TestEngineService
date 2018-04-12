using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaaS.Common;

namespace TaaS.TestEnginesService
{
    public class TestEngineFactory
    {
        private TestEngine mEngine;
        private object mEngineLocker = new object();
        private static TestEngineFactory mInstance = new TestEngineFactory();

        private TestEngineFactory()
        { }

        public static TestEngineFactory Instance
        {
            get { return mInstance; }
        }

        public void SetEngine(TestEngine engine)
        {
            lock (mEngineLocker)
            {
                mEngine = engine;
            }
        }

        public TestEngine GetEngine()
        {
            lock (mEngineLocker)
            {
                return mEngine;
            }
        }
    }
}
