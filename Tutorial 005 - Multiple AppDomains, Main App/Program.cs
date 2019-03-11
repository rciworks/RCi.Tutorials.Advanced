using System;
using System.Reflection;

namespace RCi.Tutorials.Advanced
{
    public class Program
    {
        private static AppDomain AppDomainExternalLib { get; set; }

        private static SomeClass SomeClass { get; set; }

        public static void Main()
        {
            while (ProcessCommand(Console.ReadLine()))
            {
            }
        }

        private static bool ProcessCommand(string cmd)
        {
            if (string.Equals(cmd, "exit"))
            {
                return false;
            }

            switch (cmd)
            {
                case "unload":
                    Unload();
                    break;

                case "load":
                    Load();
                    break;

                case "do":
                    Do();
                    break;
            }

            return true;
        }

        private static void Unload()
        {
            if (!(SomeClass is null))
            {
                SomeClass = default;
            }

            if (!(AppDomainExternalLib is null))
            {
                var appDomainExternalLibFriendlyName = AppDomainExternalLib.FriendlyName;
                AppDomain.Unload(AppDomainExternalLib);
                Console.WriteLine($"AppDomain \"{appDomainExternalLibFriendlyName}\" unloaded.");
                AppDomainExternalLib = default;
            }
        }

        private static void Load()
        {
            // ensure previous resources are disposed
            Unload();

            // create new domain
            AppDomainExternalLib = AppDomain.CreateDomain("AppDomainExternalLib");
            Console.WriteLine($"AppDomain \"{AppDomainExternalLib.FriendlyName}\" created.");

            // create proxy which can be accessed from both domains
            var typeSomeClass = typeof(SomeClass).FullName ?? throw new NullReferenceException();
            SomeClass = (SomeClass)AppDomainExternalLib.CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly().FullName, typeSomeClass);
            Console.WriteLine($"\"{typeof(SomeClass).Name}\" instance created.");
        }

        private static void Do()
        {
            if (SomeClass is null)
            {
                Console.WriteLine("External lib is not loaded.");
                return;
            }

            Console.WriteLine(SomeClass.GetSomething());
        }
    }
}
