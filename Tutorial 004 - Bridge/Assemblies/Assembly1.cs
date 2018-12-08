//using RCi.Tutorials.Advanced.Environments;
//using RCi.Tutorials.Advanced.Writables;

//namespace RCi.Tutorials.Advanced.Assemblies
//{
//    internal static class Assembly1
//    {
//        private const string ASSEMBLY_NAME = nameof(Assembly1);

//        private class AdapterDebugNumber :
//            EnvironmentWritableAdapter<EnvironmentDebug, WritableNumber>
//        {
//            public override void Write(in EnvironmentDebug environment, in WritableNumber writable)
//            {
//                environment.WriteLine($"{ASSEMBLY_NAME} Debug Number: {writable.Value}");
//            }
//        }

//        private class AdapterDebugText :
//            EnvironmentWritableAdapter<EnvironmentDebug, WritableText>
//        {
//            public override void Write(in EnvironmentDebug environment, in WritableText writable)
//            {
//                environment.WriteLine($"{ASSEMBLY_NAME} Debug Text: {writable.Value}");
//            }
//        }

//        private class AdapterConsoleNumber :
//            EnvironmentWritableAdapter<EnvironmentConsole, WritableNumber>
//        {
//            public override void Write(in EnvironmentConsole environment, in WritableNumber writable)
//            {
//                environment.WriteLine($"{ASSEMBLY_NAME} Console Number: {writable.Value}");
//            }
//        }

//        private class AdapterConsoleText :
//            EnvironmentWritableAdapter<EnvironmentConsole, WritableText>
//        {
//            public override void Write(in EnvironmentConsole environment, in WritableText writable)
//            {
//                environment.WriteLine($"{ASSEMBLY_NAME} Console Text: {writable.Value}");
//            }
//        }
//    }
//}
