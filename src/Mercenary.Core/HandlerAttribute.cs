

using System;

namespace Mercenary.Core
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class HandlerAttribute : Attribute
    {
        public ushort _opCode;
        public HandlerAttribute(ushort opCode)
        {
            _opCode = opCode;
        }
    }
}
