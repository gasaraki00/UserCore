using System;

namespace UserCore.Memory
{
    public sealed class RawPointer : Pointer
    {
        readonly IntPtr value;
        readonly Action<IntPtr> disposer;
        bool disposed;

        public RawPointer(IntPtr value)
            : this(value, null)
        {
        }

        public RawPointer(IntPtr value, Action<IntPtr> disposer)
        {
            this.value = value;
            this.disposer = disposer;
        }

        public override IntPtr Value
        {
            get { return value; }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                disposer?.Invoke(value);
            }

            disposed = true;
        }
    }
}
