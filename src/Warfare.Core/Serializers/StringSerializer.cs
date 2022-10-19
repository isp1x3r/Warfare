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
    public class StringSerializer : ISerializerCompiler
    {
       private readonly int _size;

       public StringSerializer(int size)
       {
            _size = size;
       }
       public bool CanHandle(Type type)
       {
            return type == typeof(string);
       }
       public void EmitSerialize(Emit emiter, Local value)
       {
            emiter.LoadArgument(1);
            emiter.LoadLocal(value);
            emiter.LoadConstant(_size);
            emiter.Call(typeof(Extensions).GetMethod(nameof(Extensions.WriteCString),
                new[] { typeof(BinaryWriter), typeof(string), typeof(int) }));
        }
       public void EmitDeserialize(Emit emiter, Local value)
       {
            emiter.LoadArgument(1);
            emiter.LoadConstant(_size);
            emiter.Call(typeof(Extensions).GetMethod(nameof(Extensions.ReadCString)));
            emiter.StoreLocal(value);
        }
    }
}

