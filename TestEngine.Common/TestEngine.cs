using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaaS.Common
{
    public interface ITestEngine
    {
        RawResponse Start(RawRequest request);
        RawResponse GetStatus();
        RawResponse Stop(RawRequest request);
    }

    public interface ITestEngineDescriptor
    {
        string Name { get; }
        string Description { get; }
        int ServingPort { get; }
        string Location { get; }
        RawConfigInfo Configuration { get; }
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

        public string Location
        {
            get { return GetLocation(); }
        }

        public RawConfigInfo Configuration
        {
            get { return GetConfigration(); }
        }

        public abstract RawResponse Start(RawRequest request);
        public abstract RawResponse GetStatus();
        public abstract RawResponse Stop(RawRequest request);

        protected abstract string GetName();
        protected abstract string GetDescription();
        protected abstract int GetServingPort();
        protected abstract string GetLocation();
        protected abstract RawConfigInfo GetConfigration();
    }
}
