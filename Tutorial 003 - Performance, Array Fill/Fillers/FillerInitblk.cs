using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace RCi.Tutorials.Advanced.Fillers
{
    public class FillerInitblk :
        IFiller
    {
        private delegate void InitblkDelegate(IntPtr address, byte value, int count);

        private static readonly InitblkDelegate Initblk = CreateInitblk();

        private static InitblkDelegate CreateInitblk()
        {
            var dynamicMethod = new DynamicMethod
            (
                "Initblk",
                MethodAttributes.Public | MethodAttributes.Static,
                CallingConventions.Standard,
                typeof(void),
                new[] { typeof(IntPtr), typeof(byte), typeof(int), },
                typeof(FillerInitblk),
                false
            );

            var il = dynamicMethod.GetILGenerator();

            il.Emit(OpCodes.Ldarg_0);   // address
            il.Emit(OpCodes.Ldarg_1);   // init value
            il.Emit(OpCodes.Ldarg_2);   // number of bytes
            il.Emit(OpCodes.Initblk);
            il.Emit(OpCodes.Ret);

            return (InitblkDelegate)dynamicMethod.CreateDelegate(typeof(InitblkDelegate));
        }

        public void Fill(byte[] array, byte value)
        {
            var gcHandle = default(GCHandle);
            try
            {
                gcHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
                Initblk(gcHandle.AddrOfPinnedObject(), value, array.Length);
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
