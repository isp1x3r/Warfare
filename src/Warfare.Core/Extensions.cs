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

        public static string MakeString(this byte[] stringBytes)
        {
            var id = Array.FindIndex(stringBytes, x => x == (byte)0);
            //var id = stringBytes.FirstOrDefault(x => x == 0);
            if (id == -1)
                id = (byte)stringBytes.Length;
            return Encoding.ASCII.GetString(stringBytes, 0, id);
        }

        public static byte[] GetBytes(this string String)
        {
            if (String == null)
                return Array.Empty<byte>();

            return Encoding.ASCII.GetBytes(String);
        }

        public static void WriteString(this BinaryWriter w, string value, int length)
        {
            byte[] arr = new byte[length];
            arr = Encoding.ASCII.GetBytes(value);
            w.Write(arr);
        }

        public static string ReadString(this BinaryReader w, int length)
        {
            return w.ReadBytes(length).MakeString();
        }

    }
    
}
