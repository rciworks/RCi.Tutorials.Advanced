using RCi.Tutorials.Advanced.Environments;
using RCi.Tutorials.Advanced.Writables;

namespace RCi.Tutorials.Advanced
{
    public delegate void Write<TEnvironment, TWritable>(in TEnvironment environment, in TWritable writable)
        where TEnvironment : IEnvironment
        where TWritable : IWritable;
}
