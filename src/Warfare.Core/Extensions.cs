using System;
using System.IO;
using System.Linq;
using System.Reflection;
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
        static Assembly GetAssemblyByName(string name)
        {
            return AppDomain.CurrentDomain.GetAssemblies().
                   SingleOrDefault(assembly => assembly.GetName().Name == name);
        }
    }
    
}
