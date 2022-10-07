using System;

namespace Mercenary.Core
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ClientMessageAttribute : Attribute
    {
        internal ushort _opCode;
        public ClientMessageAttribute(ushort opCode)
        {
            _opCode = opCode;
        }
    }
}
