using BlubLib.Serialization;
using Sigil;
using Sigil.NonGeneric;
using System;
using System.IO;
using Warfare.Core;

namespace Warfare.Network.Serializers
{
    public class StringWithPrefixSerializer : ISerializerCompiler
    {
        private readonly int _size;
        public StringWithPrefixSerializer()
        {

        }
        public StringWithPrefixSerializer(int size)
        {
            _size = size;
        }

        public bool CanHandle(Type type)
        {
            //throw new NotImplementedException();
            if (type == typeof(string))
                return true;
            return false;
        }

        public void EmitDeserialize(Emit emiter, Local value)
        {
            emiter.LoadArgument(1);
            emiter.Call(typeof(Extensions).GetMethod(nameof(Extensions.CReadString)));
            emiter.StoreLocal(value);
        }

        public void EmitSerialize(Emit emiter, Local value)
        {
            emiter.LoadArgument(1);
            emiter.LoadLocal(value);
            emiter.LoadConstant(_size);
            emiter.Call(typeof(Extensions).GetMethod(nameof(Extensions.CWriteString),
                 new[] { typeof(BinaryWriter), typeof(string), typeof(int) }));
        }
    }
}
