using RCi.Tutorials.Advanced.Environments;

namespace RCi.Tutorials.Advanced.Writables
{
    public class WritableText :
        Writable<string>
    {
        public WritableText(string value) :
            base(value)
        {
        }

        public override void Write(IEnvironment environment) => environment.Write(this);

        public override void Write<TEnvironment>(in TEnvironment environment) => Write(environment, this);
    }
}
