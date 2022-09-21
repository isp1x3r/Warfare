using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCore
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    internal class ServerMessageAttribute : Attribute
    {
        internal ushort _opCode;
        ServerMessageAttribute(ushort opCode)
        {
            _opCode = opCode;
        }
    }
}
