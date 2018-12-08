using RCi.Bridge;
using RCi.Tutorials.Advanced.Environments;
using RCi.Tutorials.Advanced.Writables;

namespace RCi.Tutorials.Advanced
{
    public abstract class EnvironmentWritableAdapter<TEnvironment, TWritable> :
        BridgeAdapter<Write<TEnvironment, TWritable>>
        where TEnvironment : IEnvironment
        where TWritable : IWritable
    {
        public override Write<TEnvironment, TWritable> BridgeValue => Write;

        public abstract void Write(in TEnvironment environment, in TWritable writable);
    }
}
