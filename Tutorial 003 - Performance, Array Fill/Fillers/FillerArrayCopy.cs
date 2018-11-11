using System;
using System.Runtime.CompilerServices;

namespace RCi.Tutorials.Advanced.Fillers
{
    public class FillerArrayCopy :
        IFiller
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Fill(byte[] array, byte value) => FillGeneric(array, value);

        public void FillGeneric<T>(T[] array, T value)
        {
            var length = array.Length;
            if (length == 0) return;

            // seed
            var seed = Math.Min(32, array.Length);
            for (var i = 0; i < seed; i++)
            {
                array[i] = value;
            }

            // copy by doubling
            int count;
            for (count = seed; count <= length / 2; count *= 2)
            {
                Array.Copy(array, 0, array, count, count);
            }

            // copy last part
            var leftover = length - count;
            if (leftover > 0)
            {
                Array.Copy(array, 0, array, count, leftover);
            }
        }
    }
}
