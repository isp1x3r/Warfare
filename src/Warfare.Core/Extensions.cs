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
            w.Write(Encoding.ASCII.GetBytes(value, 0, length));         
        }

        public static string ReadString(this BinaryReader w, int length)
        {
            return Encoding.ASCII.GetString(w.ReadBytes(length));
        }
        public static int GetManagedSize(Type type)
        {
            // all this just to invoke one opcode with no arguments!
            var method = new DynamicMethod("GetManagedSizeImpl", typeof(uint), new Type[0], typeof(TypeExtensions), false);

            ILGenerator gen = method.GetILGenerator();

            gen.Emit(OpCodes.Sizeof, type);
            gen.Emit(OpCodes.Ret);

            var func = (Func<uint>)method.CreateDelegate(typeof(Func<uint>));
            return checked((int)func());
        }
    }
    
}
