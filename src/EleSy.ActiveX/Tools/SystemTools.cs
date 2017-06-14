using System;
using System.Reflection.Emit;

namespace EleSy.ActiveX.Tools
{
    /// <summary>
    /// Set of systems tools.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// 
    /// <para>
    /// The class is a container of different system tools, which are used
    ///             across the framework. Some of these tools are platform specific, so their
    ///             implementation is different on different platform, like .NET and Mono.
    /// </para>
    /// 
    /// </remarks>
    public static class MemTools
    {
        /// <summary>
        /// Copy block of unmanaged memory.
        /// 
        /// </summary>
        /// <param name="dst">Destination pointer.</param><param name="src">Source pointer.</param><param name="count">Memory block's length to copy.</param>
        /// <returns>
        /// Return's value of <paramref name="dst"/> - pointer to destination.
        /// </returns>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// This function is required because of the fact that .NET does
        ///              not provide any way to copy unmanaged blocks, but provides only methods to
        ///              copy from unmanaged memory to managed memory and vise versa.
        /// </para>
        /// 
        /// </remarks>
        public static unsafe IntPtr CopyUnmanagedMemory(IntPtr dst, IntPtr src, int count)
        {
            CopyUnmanagedMemory((byte*)dst.ToPointer(), (byte*)src.ToPointer(), count);
            return dst;
        }

        /// <summary>
        /// Copy block of unmanaged memory.
        /// 
        /// </summary>
        /// <param name="dst">Destination pointer.</param><param name="src">Source pointer.</param><param name="count">Memory block's length to copy.</param>
        /// <returns>
        /// Return's value of <paramref name="dst"/> - pointer to destination.
        /// </returns>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// This function is required because of the fact that .NET does
        ///             not provide any way to copy unmanaged blocks, but provides only methods to
        ///             copy from unmanaged memory to managed memory and vise versa.
        /// </para>
        /// 
        /// </remarks>
        public static unsafe void/*byte**/ CopyUnmanagedMemory(byte* dst, byte* src, int count)
        {
            /*return (byte*)*/
            Memcpy(dst, src, count);
        }

        /// <summary>
        /// Fill memory region with specified value.
        /// 
        /// </summary>
        /// <param name="dst">Destination pointer.</param><param name="filler">Filler byte's value.</param><param name="count">Memory block's length to fill.</param>
        /// <returns>
        /// Return's value of <paramref name="dst"/> - pointer to destination.
        /// </returns>
        public static unsafe IntPtr SetUnmanagedMemory(IntPtr dst, int filler, int count)
        {
            SetUnmanagedMemory((byte*)dst.ToPointer(), filler, count);
            return dst;
        }

        /// <summary>
        /// Fill memory region with specified value.
        /// 
        /// </summary>
        /// <param name="dst">Destination pointer.</param><param name="filler">Filler byte's value.</param><param name="count">Memory block's length to fill.</param>
        /// <returns>
        /// Return's value of <paramref name="dst"/> - pointer to destination.
        /// </returns>
        public static unsafe void/*byte**/ SetUnmanagedMemory(byte* dst, int filler, int count)
        {
            /*return (byte*)*/
            Memset(dst, filler, count);
        }

        /*
                [DllImport("ntdll.dll", CallingConvention = CallingConvention.Cdecl)]
                private static extern unsafe byte* memcpy(byte* dst, byte* src, int count);

                [DllImport("ntdll.dll", CallingConvention = CallingConvention.Cdecl)]
                private static extern unsafe byte* memset(byte* dst, int filler, int count);*/

        private static readonly MemCpyFunction Memcpy;
        private static readonly MemSetFunction Memset;

        static unsafe MemTools()
        {
            if (Memcpy == null)
            {
                var dynamicMethod = new DynamicMethod("memcpy", typeof(void),
                    new[] { typeof(void*), typeof(void*), typeof(int) },
                    typeof(MemTools));

                var ilGenerator = dynamicMethod.GetILGenerator();

                ilGenerator.Emit(OpCodes.Ldarg_0);
                ilGenerator.Emit(OpCodes.Ldarg_1);
                ilGenerator.Emit(OpCodes.Ldarg_2);
                ilGenerator.Emit(OpCodes.Cpblk);
                ilGenerator.Emit(OpCodes.Ret);

                Memcpy = (MemCpyFunction)dynamicMethod.CreateDelegate(typeof(MemCpyFunction));
            }

            if (Memset == null)
            {
                var dynamicMethod = new DynamicMethod("memset", typeof(void),
                    new[] { typeof(void*), typeof(int), typeof(int) },
                    typeof(MemTools));

                var ilGenerator = dynamicMethod.GetILGenerator();
                ilGenerator.Emit(OpCodes.Ldarg_0);
                ilGenerator.Emit(OpCodes.Ldarg_1);
                ilGenerator.Emit(OpCodes.Ldarg_2);
                ilGenerator.Emit(OpCodes.Initblk);
                ilGenerator.Emit(OpCodes.Ret);

                Memset = (MemSetFunction)dynamicMethod.CreateDelegate(typeof(MemSetFunction));
            }
        }

        private unsafe delegate void MemCpyFunction(void* des, void* src, int bytes);
        private unsafe delegate void MemSetFunction(void* dst, int filler, int count);
    }
}