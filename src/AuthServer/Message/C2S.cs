using ServerCore;
using ProtoBuf;

namespace AuthServer.Message
{

    [ClientMessage(772)]
    [ProtoContract]
    public class CharacterCreateReqMessage
    {
        [ProtoMember(1)]
        public string Nickname { get; set; }

        [ProtoMember(2)]
        public CharacterHero Hero { get; set; }

        [ProtoMember(3)]
        public byte SkinColor { get; set; }
    }

    [ClientMessage(1028)]
    [ProtoContract]
    public class CharacterDeleteReqMessage
    {
        /* Available only in JP version which is included in the client,
           so might as well add it here!
         */
        [ProtoMember(1)]
        public uint Unk1 { get; set; }

        [ProtoMember(2)]
        public uint Unk2 { get; set; }

        [ProtoMember(3)]
        public CharacterHero Hero { get; set; }

        [ProtoMember(4)]
        public byte Slot { get; set; }

    }
}
