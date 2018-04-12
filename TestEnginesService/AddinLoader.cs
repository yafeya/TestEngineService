using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using TaaS.Common;

namespace TaaS.TestEnginesService
{
    class AddinLoader
    {
        private const string DllExtension = ".dll";
        public IEnumerable<TestEngine> GetEngines(string pluginDirectory)
        {
            var pluginList = new List<TestEngine>();
            if (Directory.Exists(pluginDirectory))
            {
                var directory = new DirectoryInfo(pluginDirectory);
                var files = directory.GetFiles();
                var dlls = files.Where(x => x.Extension.ToLower() == DllExtension);
                foreach (var dll in dlls)
                {
                    var testEngine = CreateTestEngine(dll);
                    if (testEngine != null)
                    {
                        pluginList.Add(testEngine);
                    }
                }
            }
            return pluginList;
        }

        private static TestEngine CreateTestEngine(FileInfo dll)
        {
            TestEngine testEngine = null;
            try
            {
                var assembly = Assembly.LoadFile(dll.FullName);
                var types = assembly.DefinedTypes;
                var testEnginType = types
                    .Where(x => typeof(TestEngine).IsAssignableFrom(x))
                    .FirstOrDefault();
                if (testEnginType != null)
                {
                    var assemblyName = assembly.GetName();
                    AppDomain.CurrentDomain.Load(assemblyName);
                    var constructorInfo = testEnginType.GetConstructor(new Type[] { });
                    testEngine = constructorInfo.Invoke(null) as TestEngine;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Load addin failed, error: ${Environment.NewLine}{ex}");
            }

            return testEngine;
        }
    }
}
