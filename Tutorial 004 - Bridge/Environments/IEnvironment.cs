using RCi.Tutorials.Advanced.Writables;

namespace RCi.Tutorials.Advanced.Environments
{
    public interface IEnvironment
    {
        void Write(IWritable writable);

        void Write<TWritable>(in TWritable writable)
            where TWritable : IWritable;
    }
}
