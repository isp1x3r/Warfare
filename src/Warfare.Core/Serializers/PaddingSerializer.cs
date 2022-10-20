using System;
using System.Diagnostics.Metrics;
using System.IO;
using BlubLib.IO;
using BlubLib.Reflection;
using BlubLib.Serialization;
using Microsoft.VisualBasic;
using Sigil;
using Sigil.NonGeneric;


namespace Warfare.Core.Serializers
{
    public class PaddingSerializer : ISerializerCompiler
    {
        private readonly int _length;

        public PaddingSerializer(int length)
        {
            _length = length;
        }
        public bool CanHandle(Type type)
        {
            return false;
        }
        public void EmitSerialize(Emit emiter, Local value)
        {
            emiter.LoadArgument(1);
            emiter.LoadLocal(value);
            emiter.LoadConstant(_length);
            emiter.Call(typeof(Extensions).GetMethod(nameof(Extensions.SetPadding),
                new[] { typeof(BinaryWriter), typeof(byte[]), typeof(int) }));
        }
        public void EmitDeserialize(Emit emiter, Local value)
        {
            emiter.LoadArgument(1);
            emiter.LoadConstant(_length);
            emiter.Call(typeof(Extensions).GetMethod(nameof(Extensions.GetPadding)));
            emiter.StoreLocal(value);
        }
    }
}
