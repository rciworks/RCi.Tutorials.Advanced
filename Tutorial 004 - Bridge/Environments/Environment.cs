using RCi.Bridge;
using RCi.Tutorials.Advanced.Writables;

namespace RCi.Tutorials.Advanced.Environments
{
    public abstract class Environment :
        IEnvironment
    {
        public abstract void Write(IWritable writable);

        public abstract void Write<TWritable>(in TWritable writable)
            where TWritable : IWritable;

        protected static void Write<TEnvironment, TWritable>(in TEnvironment environment, in TWritable writable)
            where TEnvironment : IEnvironment
            where TWritable : IWritable
        {
            Bridge<Write<TEnvironment, TWritable>>.Value(environment, writable);
        }
    }
}
