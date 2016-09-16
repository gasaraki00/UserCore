using System;
using System.ComponentModel;
using UserCore.Application;

namespace UserCore.Resources
{
    public abstract class Image : IDisposable
    {
        protected Image(IntPtr handle)
        {
            Handle = handle;
        }

        ~Image()
        {
            Dispose(false);
        }

        public IntPtr Handle
        {
            get;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected static IntPtr LoadImage(ApplicationInstance app, Name resourceName, uint type, int width, int height, ImageLoadingFlags flags)
        {
            using (var name = resourceName.ToPointer())
            {
                var handle = NativeFunctions.LoadImage(app.Handle, name.Value, type, width, height, (uint)flags);
                if (handle == IntPtr.Zero)
                {
                    throw new Win32Exception();
                }

                return handle;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
        }
    }
}
