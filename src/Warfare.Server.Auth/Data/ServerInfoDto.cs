using System;
using BlubLib.Serialization;
using Warfare.Core.Serializers;

namespace Warfare.Server.Auth.Data
{
    [BlubContract]
    public class ServerInfoDto
    {
        [BlubMember(1)]
        public byte Unk1 { get; set; } // Sorting ID?

        [BlubMember(2)]
        public byte Id { get; set; } // gotta check to make sure x')

        [BlubMember(3)]
        public ushort PlayerLimit { get; set; }

        [BlubMember(4)]
        public ushort PlayerCount { get; set; }

        [BlubMember(5)]
        public ushort ServerPort { get; set; }

        [BlubMember(6)]
        public uint ServerIP { get; set; }

        [BlubMember(7, typeof(BinarySerializer), 241)]
        public byte[] Unk4 { get; set; }

        [BlubMember(8, typeof(BinarySerializer), 241)]
        public byte[] Unk5 { get; set; }

        [BlubMember(9, typeof(BinarySerializer), 33)]
        public byte[] Unk6 { get; set; }

        public ServerInfoDto()
        {
            Unk4 = Array.Empty<byte>();
            Unk5 = Array.Empty<byte>();
            Unk6 = Array.Empty<byte>();
        }
    }
}
