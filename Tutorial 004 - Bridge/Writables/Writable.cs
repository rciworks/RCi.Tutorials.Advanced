using RCi.Bridge;
using RCi.Tutorials.Advanced.Environments;

namespace RCi.Tutorials.Advanced.Writables
{
    public abstract class Writable :
        IWritable
    {
        public abstract void Write(IEnvironment environment);

        public abstract void Write<TEnvironment>(in TEnvironment environment)
            where TEnvironment : IEnvironment;

        protected static void Write<TEnvironment, TWritable>(in TEnvironment environment, in TWritable writable)
            where TEnvironment : IEnvironment
            where TWritable : IWritable
        {
            Bridge<Write<TEnvironment, TWritable>>.Value(environment, writable);
        }
    }

    public abstract class Writable<TValue> :
        Writable
    {
        public TValue Value { get; }

        protected Writable(TValue value) => Value = value;
    }
}
