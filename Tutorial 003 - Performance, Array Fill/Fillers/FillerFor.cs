using System.Runtime.CompilerServices;

namespace RCi.Tutorials.Advanced.Fillers
{
    public class FillerFor :
        IFiller
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Fill(byte[] array, byte value) => FillGeneric(array, value);

        public void FillGeneric<T>(T[] array, T value)
        {
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = value;
            }
        }
    }
}
