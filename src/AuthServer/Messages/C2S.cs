using ServerCore;
using ProtoBuf;

namespace AuthServer.Message
{

    [ClientMessage(772)]
    [ProtoContract]
    internal class CharacterCreateReqMessage
    {
        [ProtoMember(1)]
        internal string Nickname { get; set; }

        [ProtoMember(2)]
        internal CharacterHero Hero { get; set; }

        [ProtoMember(3)]
        internal byte SkinColor { get; set; }
    }

    [ClientMessage(1028)]
    [ProtoContract]
    internal class CharacterDeleteReqMessage
    {
        /* Available only in JP version which is included in the client,
           so might as well add it here!
         */
        [ProtoMember(1)]
        internal uint Unk1 { get; set; }

        [ProtoMember(2)]
        internal uint Unk2 { get; set; }

        [ProtoMember(3)]
        internal CharacterHero Hero { get; set; }

        [ProtoMember(4)]
        internal byte Slot { get; set; }

    }
}
