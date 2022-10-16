using Mercenaries.Core;
using ProtoBuf;

namespace Mercenaries.Server.Auth.Messages
{
    [ClientMessage(4)]
    [ProtoContract]
    public class AuthenticationReqMessage
    {
        [ProtoMember(1)]
        public uint AccountNumber { get; set; }

        [ProtoMember(2)]
        public string Username { get; set; }
    }

    [ClientMessage(260)]
    [ProtoContract]
    public class CharacterListReqMessage
    {
       
    }

    [ClientMessage(516)]
    [ProtoContract]
    public class CharacterInfoReqMessage
    {
        [ProtoMember(1)]
        public uint CharacterId { get; set; }
    }

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
           so might as well add it here
         */
        [ProtoMember(1)]
        public uint Unk1 { get; set; }

        [ProtoMember(2)]
        public uint Unk2 { get; set; }

        [ProtoMember(3)]
        public uint Slot { get; set; }

    }

    [ClientMessage(1284)]
    [ProtoContract]
    public class ServiceConnectReqMessage
    {
        [ProtoMember(1)]
        public uint CharacterId { get; set; }

        [ProtoMember(2)]
        public byte[] Unk1 { get; set; }
    }
}
