﻿using System;

namespace Warfare.Core
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ServerMessageAttribute : Attribute
    {
        public ushort _opCode;
        public ServerMessageAttribute(ushort opCode)
        {
            _opCode = opCode;
        }
    }
}