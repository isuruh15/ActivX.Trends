using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using DISPPARAMS = System.Runtime.InteropServices.ComTypes.DISPPARAMS;
using EXCEPINFO = System.Runtime.InteropServices.ComTypes.EXCEPINFO;

namespace EleSy.ActiveX.Interop
{
    [ComImport]
    [Guid("00020400-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDispatch
    {
        [PreserveSig]
        int GetTypeInfoCount(out int count);

        [PreserveSig]
        int GetTypeInfo
            (
            [MarshalAs(UnmanagedType.U4)] int iTInfo,
            [MarshalAs(UnmanagedType.U4)] int lcid,
            out ITypeInfo typeInfo
            );

        /*[PreserveSig]
        int GetIDsOfNames
            (
                ref Guid riid,
                [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)]
            string[] rgsNames,
                int cNames,
                int lcid,
                [MarshalAs(UnmanagedType.LPArray)] int[] rgDispId
            );*/
        [PreserveSig]
        int GetDispId(ref Guid riid, ref string name, int nameCount, int lcid, out int dispId);

        [PreserveSig]
        int Invoke
            (
            int dispIdMember,
            ref Guid riid,
            uint lcid,
            ushort wFlags,
            ref DISPPARAMS pDispParams,
            out dynamic pVarResult,
            ref EXCEPINFO pExcepInfo,
            IntPtr[] pArgErr
            );
    }
}