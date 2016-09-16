using System;

namespace UserCore.Resources
{
    [Flags]
    public enum ImageLoadingFlags : uint
    {
        DefaultColor        = 0x00000000,
        Monochrome          = 0x00000001,
        LoadFromFile        = 0x00000010,
        LoadTransparent     = 0x00000020,
        DefaultSize         = 0x00000040,
        VgaColor            = 0x00000080,
        LoadMap3DColors     = 0x00001000,
        CreateDibSection    = 0x00002000,
        Shared              = 0x00008000
    }
}
