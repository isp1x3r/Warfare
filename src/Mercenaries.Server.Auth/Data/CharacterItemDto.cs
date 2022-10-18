using BlubLib.Serialization;

namespace Mercenaries.Server.Auth.Data
{
    [BlubContract]
    public class CharacterItemDto
    {
        [BlubMember(1)]
        public uint ItemCode { get; set; }

        [BlubMember(2)]
        public byte Type { get; set; }

        [BlubMember(3)]
        public ushort ItemNumber { get; set; }

        [BlubMember(4)]
        public uint Unk1 { get; set; }

        [BlubMember(5)]
        public byte Unk2 { get; set; }

        [BlubMember(6)]
        public byte Unk3 { get; set; }

        [BlubMember(7)]
        public uint MinutesLeft { get; set; }

        [BlubMember(8)]
        public ushort SecondsLeft { get; set; }


    }
}
