using ProtoBuf;

namespace Mercenaries.Network.Data.Auth
{
    [ProtoContract]
    public class CharacterItemDto
    {
        [ProtoMember(1)]
        public uint ItemCode { get; set; }

        [ProtoMember(2)]
        public byte Type { get; set; }

        [ProtoMember(3)]
        public ushort ItemNumber { get; set; }

        [ProtoMember(4)]
        public uint Unk1 { get; set; }

        [ProtoMember(5)]
        public byte Unk2 { get; set; }

        [ProtoMember(6)]
        public byte Unk3 { get; set; }

        [ProtoMember(7)]
        public uint MinutesLeft { get; set; }

        [ProtoMember(8)]
        public ushort SecondsLeft { get; set; }


    }
}
