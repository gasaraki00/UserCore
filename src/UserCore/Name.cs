using System;
using UserCore.Memory;

namespace UserCore
{
    public struct Name
    {
        public static readonly Name Null = new Name();
        
        readonly ushort id;
        readonly string name;

        public Name(ushort id)
        {
            this.id = id;
            name = null;
        }

        public Name(string name)
        {
            this.name = name;
            id = 0;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (Name)obj;
            return id == other.id && name == other.name;
        }
        
        public override int GetHashCode()
        {
            return name != null ? name.GetHashCode() : id.GetHashCode();
        }

        public static Pointer ToPointer(ushort id)
        {
            return new Name(id).ToPointer();
        }

        public static Pointer ToPointer(string name)
        {
            return new Name(name).ToPointer();
        }

        public Pointer ToPointer()
        {
            if (name != null)
            {
                return new ObjectPointer(name);
            }
            else
            {
                return new RawPointer(new IntPtr(id));
            }
        }
    }
}
