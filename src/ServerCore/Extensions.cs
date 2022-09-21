using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCore
{
    public static class Extensions
    {

        public static void ReadAuthServerOpCode(byte[] packet, out short opCode)
        {
            using (BinaryReader _r = new BinaryReader(new MemoryStream(packet)))
            {
                _r.BaseStream.Position = 3;
                opCode = _r.ReadByte();
            }
        }
        public static void ReadGameServerOpCode(byte[] packet, out short opCode)
        {
            using (BinaryReader _r = new BinaryReader(new MemoryStream(packet)))
            {
                _r.BaseStream.Position = 8;
                opCode = _r.ReadInt16();
            }
        }
        // TODO
        /*public static byte ReadLobbyServerOpCode(byte[] packet)
        {

        }*/
    }
}
