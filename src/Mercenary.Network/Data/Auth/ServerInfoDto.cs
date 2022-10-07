using ProtoBuf;

namespace Mercenary.Network.Data.Auth
{
    [ProtoContract]
    public class ServerInfoDto
    {
        [ProtoMember(1)]
        public byte Unk1 { get; set; } // Sorting ID?

        [ProtoMember(2)]
        public byte Id { get; set; } // gotta check to make sure x')

        [ProtoMember(3)]
        public ushort Unk2 { get; set; }

        [ProtoMember(4)]
        public ushort Unk3 { get; set; }

        [ProtoMember(5)]
        public ushort ServerPort { get; set; }

        [ProtoMember(6)]
        public uint ServerIP { get; set; }

        [ProtoMember(7, IsPacked = true)]
        public byte[] Unk4 { get; set; }

        [ProtoMember(8, IsPacked = true)]
        public byte[] Unk5 { get; set; }

        [ProtoMember(9, IsPacked = true)]
        public byte[] Unk6 { get; set; }

        public ServerInfoDto()
        {
            Unk2 = 0;
            Unk4 = new byte[241];
            Unk5 = new byte[241];
            Unk6 = new byte[33];
        }
    }
}
