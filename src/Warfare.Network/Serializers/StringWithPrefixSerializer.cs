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
        public StringWithPrefixSerializer()
        {

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
            emiter.Call(typeof(Extensions).GetMethod(nameof(Extensions.CWriteString),
                 new[] { typeof(BinaryWriter), typeof(string)}));
        }
    }
}
