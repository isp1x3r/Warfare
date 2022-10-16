using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercenaries.Core
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
        public static string WriteCString(string @string, int length)
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
