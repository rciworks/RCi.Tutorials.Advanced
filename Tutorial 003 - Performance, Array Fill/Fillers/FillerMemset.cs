using System;
using System.Runtime.InteropServices;

namespace RCi.Tutorials.Advanced.Fillers
{
    public class FillerMemset :
        IFiller
    {
        [DllImport("msvcrt.dll", EntryPoint = "memset", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        private static extern IntPtr MemSet(IntPtr dest, int c, int byteCount);

        public void Fill(byte[] array, byte value)
        {
            var gcHandle = default(GCHandle);
            try
            {
                gcHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
                MemSet(gcHandle.AddrOfPinnedObject(), value, array.Length);
            }
            finally
            {
                if (gcHandle.IsAllocated)
                {
                    gcHandle.Free();
                }
            }
        }
    }
}
