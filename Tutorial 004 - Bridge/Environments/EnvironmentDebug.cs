using RCi.Tutorials.Advanced.Writables;

namespace RCi.Tutorials.Advanced.Environments
{
    public class EnvironmentDebug :
        Environment
    {
        public override void Write(IWritable writable) => writable.Write(this);

        public override void Write<TWritable>(in TWritable writable) => Write(this, writable);

        public void WriteLine(string text) => System.Diagnostics.Debug.WriteLine(text);
    }
}
