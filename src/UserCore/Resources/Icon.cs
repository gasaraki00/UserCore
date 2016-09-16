using System.ComponentModel;
using UserCore.Application;

namespace UserCore.Resources
{
    public sealed class Icon : Image
    {
        bool shared;
        bool disposed;

        public Icon(ApplicationInstance app, Name resourceName, int width, int height, ImageLoadingFlags flags)
            : base(LoadImage(app, resourceName, 1, width, height, flags))
        {
            shared = flags.HasFlag(ImageLoadingFlags.Shared);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (!shared)
            {
                if (!NativeFunctions.DestroyIcon(Handle))
                {
                    throw new Win32Exception();
                }
            }

            disposed = true;
        }
    }
}
