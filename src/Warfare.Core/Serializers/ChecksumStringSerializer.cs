using BlubLib.Serialization;
using Sigil;
using Sigil.NonGeneric;
using System;
using System.IO;
using Warfare.Core;

namespace Warfare.Core.Serializers
{
    public class ChecksumStringSerializer : ISerializerCompiler
    {
        public ChecksumStringSerializer()
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
            emiter.Call(typeof(Extensions).GetMethod(nameof(Extensions.ReadChecksum)));
            emiter.StoreLocal(value);
        }

        public void EmitSerialize(Emit emiter, Local value)
        {
            emiter.LoadArgument(1);
            emiter.LoadLocal(value);
            emiter.Call(typeof(Extensions).GetMethod(nameof(Extensions.WriteChecksum),
                new[] { typeof(BinaryWriter), typeof(string) }));
        }
    }
}
