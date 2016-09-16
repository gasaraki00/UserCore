using System;

namespace UserCore.Memory
{
    public abstract class Pointer : IDisposable
    {
        protected Pointer()
        {
        }

        ~Pointer()
        {
            Dispose(false);
        }

        public abstract IntPtr Value
        {
            get;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }
    }
}
