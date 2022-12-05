using System;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using BlubLib;

namespace Warfare.Core
{
    public static class Extensions
    {   

        public static ushort ReadOpCodeFromPacket(byte[] packet)
        {
            using (var _r = new BinaryReader(new MemoryStream(packet)))
            {
                 _r.BaseStream.Position = 2;
                 return _r.ReadUInt16();

            }

        
        }
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
        public static void CWriteString(this BinaryWriter w, string value)
        {
            ushort size = Convert.ToUInt16(value.Length);
            byte[] strbytes = new byte[size + 2];
            strbytes = Encoding.ASCII.GetBytes(value);
            w.Write(size);
            w.Write(strbytes);
        }
        public static string CReadString(this BinaryReader r)
        {
            ushort size = r.ReadUInt16();
            byte[] strbytes = r.ReadBytes(size);
            return Encoding.ASCII.GetString(strbytes);
        }
    }
    
}
