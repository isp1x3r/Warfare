using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreNetwork
{
    public static class Extensions
    {
        public static byte ReadAuthServerOpCode(byte[] packet)
        {
            byte opCode;
            using (BinaryReader _r = new BinaryReader(new MemoryStream(packet)))
            {
                _r.BaseStream.Position = 3;
                opCode = _r.ReadByte();
            }
            return opCode;
        }
        public static short ReadGameServerOpCode(byte[] packet)
        {
            short opCode;
            using (BinaryReader _r = new BinaryReader(new MemoryStream(packet)))
            {
                _r.BaseStream.Position = 8;
                opCode = _r.ReadInt16();
            }
            return opCode;
        }
    }
}
