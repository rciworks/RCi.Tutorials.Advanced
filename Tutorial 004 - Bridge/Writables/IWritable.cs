using RCi.Tutorials.Advanced.Environments;

namespace RCi.Tutorials.Advanced.Writables
{
    public interface IWritable
    {
        void Write(IEnvironment environment);

        void Write<TEnvironment>(in TEnvironment environment)
            where TEnvironment : IEnvironment;
    }
}
