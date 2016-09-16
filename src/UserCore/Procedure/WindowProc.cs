using System;
using System.Runtime.InteropServices;

namespace UserCore.Procedure
{
    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    public delegate IntPtr WindowProc(IntPtr hwnd, uint uMsg, UIntPtr wParam, Int64 lParam);
}
