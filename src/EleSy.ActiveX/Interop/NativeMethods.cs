using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace EleSy.ActiveX.Interop
{
    public static class NativeMethods
    {
        [StructLayout(LayoutKind.Sequential)]
        [Serializable]
        public struct MSG
        {
            public IntPtr hwnd;
            public int message;
            public IntPtr wParam;
            public IntPtr lParam;
            public int time;
            // pt was a by-value POINT structure 
            public int pt_x;
            public int pt_y;
        }

        [StructLayout(LayoutKind.Sequential)/*leftover(noAutoOffset)*/]
        public sealed class tagCONTROLINFO
        {
            [MarshalAs(UnmanagedType.U4)/*leftover(offset=0, cb)*/]
            public int cb = Marshal.SizeOf(typeof(tagCONTROLINFO));

            public IntPtr hAccel;

            [MarshalAs(UnmanagedType.U2)/*leftover(offset=8, cAccel)*/]
            public short cAccel;

            [MarshalAs(UnmanagedType.U4)/*leftover(offset=10, dwFlags)*/]
            public int dwFlags;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class COMRECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;

            public COMRECT()
            {
            }

            public COMRECT(Rectangle r)
            {
                left = r.X;
                top = r.Y;
                right = r.Right;
                bottom = r.Bottom;
            }


            public COMRECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }

            /* Unused
            public RECT ToRECT() { 
                return new RECT(left, top, right, bottom);
            } 
            */

            public static COMRECT FromXYWH(int x, int y, int width, int height)
            {
                return new COMRECT(x, y, x + width, y + height);
            }

            public override string ToString()
            {
                return "Left = " + left + " Top " + top + " Right = " + right + " Bottom = " + bottom;
            }
        }

        [StructLayout(LayoutKind.Sequential)/*leftover(noAutoOffset)*/]
        public sealed class tagOLEVERB
        {
            public int lVerb;

            [MarshalAs(UnmanagedType.LPWStr)/*leftover(offset=4, customMarshal="UniStringMarshaller", lpszVerbName)*/]
            public string lpszVerbName;

            [MarshalAs(UnmanagedType.U4)/*leftover(offset=8, fuFlags)*/]
            public int fuFlags;

            [MarshalAs(UnmanagedType.U4)/*leftover(offset=12, grfAttribs)*/]
            public int grfAttribs;
        }

        [StructLayout(LayoutKind.Sequential)/*leftover(noAutoOffset)*/]
        public sealed class tagSIZEL
        {
            public int cx;
            public int cy;
        }

        [StructLayout(LayoutKind.Sequential)/*leftover(noAutoOffset)*/]
        public sealed class tagLOGPALETTE
        {
            [MarshalAs(UnmanagedType.U2)/*leftover(offset=0, palVersion)*/]
            public short palVersion = 0;

            [MarshalAs(UnmanagedType.U2)/*leftover(offset=2, palNumEntries)*/]
            public short palNumEntries = 0;
        }
    }
}