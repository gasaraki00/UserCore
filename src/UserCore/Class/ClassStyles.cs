using System;

namespace UserCore.Class
{
    [Flags]
    public enum ClassStyles : uint
    {
        VerticalRedraw      = 0x00000001,
        HorizantalRedraw    = 0x00000002,
        DoubleClick         = 0x00000008,
        OwnDc               = 0x00000020,
        ClassDc             = 0x00000040,
        ParentDc            = 0x00000080,
        NoClose             = 0x00000200,
        SaveBits            = 0x00000800,
        ByteAlignClient     = 0x00001000,
        ByteAlignWindow     = 0x00002000,
        GlobalClass         = 0x00004000,
        DropShadow          = 0x00020000
    }
}
