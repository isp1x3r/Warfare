using ProtoBuf;

namespace Mercenary.Auth.Data
{
    [ProtoContract]
    internal class ServerInfoDto
    {
        [ProtoMember(1)]
        internal byte Unk1 { get; set; } // Sorting ID?

        [ProtoMember(2)]
        internal byte Id { get; set; } // gotta check to make sure x')

        [ProtoMember(3)]
        internal ushort Unk2 { get; set; }

        [ProtoMember(4)]
        internal ushort Unk3 { get; set; }

        [ProtoMember(5)]
        internal ushort ServerPort { get; set; }

        [ProtoMember(6)]
        internal uint ServerIP { get; set; }

        [ProtoMember(7, IsPacked = true)]
        internal byte[] Unk4 { get; set; }

        [ProtoMember(8, IsPacked = true)]
        internal byte[] Unk5 { get; set; }

        [ProtoMember(9, IsPacked = true)]
        internal byte[] Unk6 { get; set; }

        internal ServerInfoDto()
        {
            Unk2 = 0;
            Unk4 = new byte[241];
            Unk5 = new byte[241];
            Unk6 = new byte[33];
        }
    }
}
