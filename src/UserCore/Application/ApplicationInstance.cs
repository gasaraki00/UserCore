using System;
using System.ComponentModel;

namespace UserCore.Application
{
    public struct ApplicationInstance
    {
        public static readonly ApplicationInstance Current;
        public static readonly ApplicationInstance Null;

        static ApplicationInstance()
        {
            // Init null instance.
            Null = new ApplicationInstance(IntPtr.Zero);

            // Init current instance.
            var module = NativeFunctions.GetModuleHandle(null);
            if (module == IntPtr.Zero)
            {
                throw new Win32Exception();
            }

            Current = new ApplicationInstance(module);
        }

        public ApplicationInstance(IntPtr handle)
        {
            Handle = handle;
        }

        public IntPtr Handle
        {
            get;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Handle == ((ApplicationInstance)obj).Handle;
        }
        
        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        public static bool operator ==(ApplicationInstance a, ApplicationInstance b)
        {
            return a.Handle == b.Handle;
        }

        public static bool operator !=(ApplicationInstance a, ApplicationInstance b)
        {
            return a.Handle != b.Handle;
        }
    }
}
