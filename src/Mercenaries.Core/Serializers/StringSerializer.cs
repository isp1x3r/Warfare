﻿using System;
using System.IO;
using BlubLib.Reflection;
using BlubLib.Serialization;
using Sigil;

namespace Mercenaries.Core.Serializers
{
    public class StringSerializer : ISerializerCompiler
    {
        public bool CanHandle(Type type)
        {
            return type == typeof(string);
        }

        public void EmitDeserialize(BlubLib.Serialization.CompilerContext context, Local value)
        {
            context.Emit.LoadReaderOrWriterParam();
            context.Emit.Call(ReflectionHelper.GetMethod((BinaryReader _) => _.ReadCString()));
            context.Emit.StoreLocal(value);
        }

        public void EmitSerialize(CompilerContext context, Local value)
        {
            var writeLabel = context.Emit.DefineLabel();

            // if (value != null) goto write
            context.Emit.LoadLocal(value);
            context.Emit.LoadNull();
            context.Emit.CompareEqual();
            context.Emit.BranchIfFalse(writeLabel);

            // value = string.Empty
            context.Emit.LoadField(typeof(string).GetField(nameof(string.Empty)));
            context.Emit.StoreLocal(value);

            // ProudNetBinaryWriterExtensions.WriteProudString(writer, value, false)
            context.Emit.MarkLabel(writeLabel);
            context.Emit.LoadReaderOrWriterParam();
            context.Emit.LoadLocal(value);
            context.Emit.LoadConstant(false);
            context.Emit.Call(ReflectionHelper.GetMethod((BinaryWriter _) => _.WriteProudString(default(string), default(bool))));
        }
    }
}

