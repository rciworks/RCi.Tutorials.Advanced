using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace RCi.Tutorials.Advanced
{
    public class SomeClass :
        MarshalByRefObject
    {
        #region // loader

        private static Func<object> FuncConstructor { get; }

        private static Func<object, string> FuncGetSomething { get; }

        static SomeClass()
        {
            // load assembly into new domain
#if DEBUG
            var cfg = "Debug";
#else
            var cfg = "Release";
#endif
            var assemblyName = "Tutorial 005 - Multiple AppDomains, External Lib.dll";
            var assemblyPath = Path.GetFullPath(Path.Combine(@"..\..\..\Tutorial 005 - Multiple AppDomains, External Lib\bin", cfg, assemblyName));
            var assemblyBytes = File.ReadAllBytes(assemblyPath);
            var assembly = Assembly.Load(assemblyBytes);

            // get type of SomeClass
            var typeSomeClass = assembly.GetTypes().First(t => string.Equals(t.FullName, "RCi.Tutorials.Advanced.SomeClass"));

            // get constructor
            FuncConstructor = () => Activator.CreateInstance(typeSomeClass);

            // get GetSomething method
            var methodInfoGetSomething = typeSomeClass.GetMethods().First(m => string.Equals(m.Name, "GetSomething"));
            FuncGetSomething = instance => (string)methodInfoGetSomething.Invoke(instance, default);
        }

        #endregion

        #region // instance

        private object Instance { get; }

        public SomeClass() => Instance = FuncConstructor();

        public string GetSomething() => FuncGetSomething(Instance);

        #endregion
    }
}
