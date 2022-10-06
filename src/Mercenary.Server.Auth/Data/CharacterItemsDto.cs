using ProtoBuf;
namespace Mercenary.Auth.Data
{
    [ProtoContract]
    internal class CharacterItemsDto
    {
        [ProtoMember(1)]
        internal uint ItemCode { get; set; }

        [ProtoMember(2)]
        internal byte Type { get; set; }

        [ProtoMember(3)]
        internal ushort ItemNumber { get; set; }

        [ProtoMember(4)]
        internal uint Unk1 { get; set; }

        [ProtoMember(5)]
        internal byte Unk2 { get; set; }

        [ProtoMember(6)]
        internal byte Unk3 { get; set; }

        [ProtoMember(7)]
        internal uint MinutesLeft { get; set; }

        [ProtoMember(8)]
        internal ushort SecondsLeft { get; set; }


    }
}
