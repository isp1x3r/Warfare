

namespace Mercenary.Core
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    internal class HandlerAttribute : Attribute
    {
        internal ushort _opCode;
        HandlerAttribute(ushort opCode)
        {
            _opCode = opCode;
        }
    }
}
