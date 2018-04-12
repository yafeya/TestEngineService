using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaaS.Common
{
    public interface ITestEngine
    {
        void Start(RawRequest request);
        RawResponse GetStatus(RawRequest request);
    }

    public interface ITestEngineDescriptor
    {
        string Name { get; }
        string Description { get; }
        int ServingPort { get; }
    }

    public abstract class TestEngine : ITestEngine, ITestEngineDescriptor
    {
        public string Name
        {
            get { return GetName(); }
        }

        public string Description
        {
            get { return GetDescription(); }
        }

        public int ServingPort
        {
            get { return GetServingPort(); }
        }

        public abstract void Start(RawRequest request);
        public abstract RawResponse GetStatus(RawRequest request);

        protected abstract string GetName();
        protected abstract string GetDescription();
        protected abstract int GetServingPort();
    }
}
