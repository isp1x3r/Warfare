﻿using System;

namespace Mercenaries.Core
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ClientMessageAttribute : Attribute
    {
        public ushort _opCode;
        public ClientMessageAttribute(ushort opCode)
        {
            _opCode = opCode;
        }
    }
}