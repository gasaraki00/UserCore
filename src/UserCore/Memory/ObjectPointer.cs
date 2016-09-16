using System;
using System.Runtime.InteropServices;

namespace UserCore.Memory
{
    public sealed class ObjectPointer : Pointer
    {
        readonly GCHandle handle;
        bool disposed;
        
        public ObjectPointer(object obj)
        {
            handle = GCHandle.Alloc(obj, GCHandleType.Pinned);
        }

        public override IntPtr Value
        {
            get { return handle.AddrOfPinnedObject(); }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            handle.Free();
            disposed = true;
        }
    }
}
