﻿

namespace Mercenary.Core
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ServerMessageAttribute : Attribute
    {
        internal ushort _opCode;
        public ServerMessageAttribute(ushort opCode)
        {
            _opCode = opCode;
        }
    }
}
