using BlubLib.Serialization;

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
        public ushort Unk2 { get; set; }

        [BlubMember(4)]
        public ushort Unk3 { get; set; }

        [BlubMember(5)]
        public ushort ServerPort { get; set; }

        [BlubMember(6)]
        public uint ServerIP { get; set; }

        [BlubMember(7)]
        public byte[] Unk4 { get; set; }

        [BlubMember(8)]
        public byte[] Unk5 { get; set; }

        [BlubMember(9)]
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
