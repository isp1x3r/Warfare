using ServerCore;
using ProtoBuf;

namespace AuthServer.Message
{

    [ClientMessage(772)]
    [ProtoContract]
    public class CharacterCreateReqMessage
    {
        [ProtoMember(0)]
        public string Nickname { get; set; }

        [ProtoMember(1)]
        public CharacterHero Hero { get; set; }

        [ProtoMember(2)]
        public byte SkinColor { get; set; }
    }
}
