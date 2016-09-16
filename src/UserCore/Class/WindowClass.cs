using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using UserCore.Application;
using UserCore.Procedure;
using UserCore.Resources;

namespace UserCore.Class
{
    public sealed class WindowClass : IDisposable
    {
        readonly ClassStyles styles;
        readonly WindowProc procedure;
        readonly int extraClassBytes;
        readonly int extraInstanceBytes;
        readonly ApplicationInstance app;
        readonly Icon icon;
        readonly Cursor cursor;
        ushort atom;
        bool disposed;

        public WindowClass(ClassStyles styles, WindowProc procedure, int extraClassBytes, int extraInstanceBytes, ApplicationInstance app, Icon icon, Cursor cursor)
        {
            this.styles = styles;
            this.procedure = procedure;
            this.extraClassBytes = extraClassBytes;
            this.extraInstanceBytes = extraInstanceBytes;
            this.app = app;
            this.icon = icon;
            this.cursor = cursor;

            Register();
        }

        ~WindowClass()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (atom != 0)
            {
                using (var name = Name.ToPointer(atom))
                {
                    if (!NativeFunctions.UnregisterClass(name.Value, app.Handle))
                    {
                        throw new Win32Exception();
                    }
                }
            }

            disposed = true;
        }

        void Register()
        {
            var details = new WNDCLASSEX
            {
                cbSize = (uint)Marshal.SizeOf<WNDCLASSEX>(),
                style = (uint)styles,
                lpfnWndProc = procedure,
                cbClsExtra = extraClassBytes,
                cbWndExtra = extraInstanceBytes,
                hInstance = app.Handle,
                hIcon = icon.Handle,
                hCursor = cursor.Handle
            };

            atom = NativeFunctions.RegisterClassEx(ref details);
            if (atom == 0)
            {
                throw new Win32Exception();
            }
        }
    }
}
