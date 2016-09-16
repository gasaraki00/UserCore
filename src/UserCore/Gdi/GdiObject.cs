using System;

namespace UserCore.Gdi
{
    public abstract class GdiObject : IDisposable
    {
        bool disposed;

        protected GdiObject(IntPtr handle, bool isStockObject)
        {
            Handle = handle;
            IsStockObject = isStockObject;
        }

        ~GdiObject()
        {
            Dispose(false);
        }

        public IntPtr Handle
        {
            get;
        }

        public bool IsStockObject
        {
            get;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected static IntPtr GetStockObject(int id)
        {
            var handle = NativeFunctions.GetStockObject(id);
            if (handle == IntPtr.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Value is not a valid stock object.");
            }

            return handle;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (!IsStockObject && Handle != IntPtr.Zero)
            {
                if (!NativeFunctions.DeleteObject(Handle))
                {
                    throw new InvalidOperationException("The handle is not valid or still selected into a DC.");
                }
            }

            disposed = true;
        }
    }
}
