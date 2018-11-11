namespace RCi.Tutorials.Advanced.Fillers
{
    public class FillerUnsafe :
        IFiller
    {
        public unsafe void Fill(byte[] array, byte value)
        {
            fixed (byte* ptrStart = array)
            {
                var ptrEnd = ptrStart + array.Length;
                for (var ptr = ptrStart; ptr < ptrEnd; ptr++)
                {
                    *ptr = value;
                }
            }
        }
    }
}
