using System;

namespace Mercenaries.Core
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
