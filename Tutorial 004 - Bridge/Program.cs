using System;
using System.Linq;
using RCi.Tutorials.Advanced.Environments;
using RCi.Tutorials.Advanced.Writables;

namespace RCi.Tutorials.Advanced
{
    internal class Program
    {
        private static void Main()
        {
            var environments = new IEnvironment[]
            {
                new EnvironmentDebug(),
                new EnvironmentConsole(),
            };
            var writables = new IWritable[]
            {
                new WritableNumber(42),
                new WritableText("Hello World!"),
            };

            var pairs = environments.SelectMany(e => writables.Select(w => (Environment: e, Writable: w)));
            foreach (var (environment, writable) in pairs)
            {
                environment.Write(writable);
                writable.Write(environment);
            }

            Console.ReadKey();
        }
    }
}
