using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;
using System.Reflection;
using System.CodeDom.Compiler;

namespace Mercenaries.Core
{
    public static class Extensions
    {
        /// <summary>
        /// Gets the packet message by removing the first 4 bytes that are : 
        /// [-] ushort packetLength
        /// [-] ushort packetID
        /// </summary>
        /// <param name="packet">The entire packet</param>
        /// <returns>The packet message</returns>
        public static byte[]? GetMessageBuffer(byte[] packet, ServerType servertype)
        {
            using (var _r = new BinaryReader(new MemoryStream(packet)))
            {
                int length;
                byte[] messagebuffer;
                switch (servertype)
                {
                    case ServerType.AuthServer:
                        length = _r.ReadUInt16() - 4;
                        _r.BaseStream.Position += 2;
                        break;
                    case ServerType.LobbyServer:
                        length = _r.ReadUInt16() - 10;
                        _r.BaseStream.Position += 8;
                        break;
                        default:
                        return null;

                }
                messagebuffer = _r.ReadBytes(length);
                return messagebuffer;
            }
            return null;
        }

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
        public static string ReadCString(this BinaryReader @this)
        {
            byte[] buffer = @this.ReadBytes(17);
            return Encoding.ASCII.GetString(buffer);
        }

        public static string WriteCString2(string @string, int length)
        {
            // Do we need to fill the remaining bytes?
            int remaining = length - @string.Length;
            if (remaining > 0)
            {
                StringBuilder _builder = new StringBuilder(@string, length);
                byte[] padding = new byte[remaining];
                _builder.Append(Encoding.ASCII.GetString(padding));
                return _builder.ToString();
            }
            return @string;
        }
    }
    
}
