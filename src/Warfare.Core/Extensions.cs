using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;
using System.Reflection;
using System.CodeDom.Compiler;
using System.Reflection.Emit;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using BlubLib;
using System.Diagnostics;

namespace Warfare.Core
{
    public static class Extensions
    {   

        public static ushort ReadOpCodeFromPacket(byte[] packet, ServerType servertype)
        {
            using (var _r = new BinaryReader(new MemoryStream(packet)))
            {
                switch(servertype)
                {
                    case ServerType.AuthServer:
                        _r.BaseStream.Position = 2;
                        break;
                    case ServerType.LobbyServer:
                        _r.BaseStream.Position = 8;
                        break;
                    case ServerType.GameServer:
                        // TODO
                        break;
                }

                return _r.ReadUInt16();
            }
        }
        public static void ReadGameServerOpCode(byte[] packet, out ushort opCode)
        {
            using (BinaryReader _r = new BinaryReader(new MemoryStream(packet)))
            {
                _r.BaseStream.Position = 8;
                opCode = _r.ReadUInt16();
            }
        }
        // TODO
        /*public static byte ReadLobbyServerOpCode(byte[] packet)
        {

        }*/

        public static void WriteString(this BinaryWriter w, string value, int length)
        {
            if (value == null)
            {
                w.Write(new byte[length]);
                return;
            }
            byte[] a = new byte[length];
            a.ToBinaryWriter().Write(Encoding.ASCII.GetBytes(value));
            w.Write(a);
        }

        public static string ReadString(this BinaryReader r, int length)
        {
            return Encoding.ASCII.GetString(r.ReadBytes(length));
        }
        public static void WriteBSString(this BinaryWriter w, string value)
        {
            byte[] bs = new byte[value.Length + 1];
            bs = Encoding.ASCII.GetBytes(value);
            w.Write(bs);
        }
        public static string ReadBSString(this BinaryReader r)
        {
            return r.ReadString();
        }

    }
    
}
