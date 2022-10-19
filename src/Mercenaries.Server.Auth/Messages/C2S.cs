using Mercenaries.Core;
using BlubLib.Serialization;
using BlubLib.Serialization.Serializers;

namespace Mercenaries.Server.Auth.Messages
{
    [ClientMessage(4)]
    [BlubContract]
    public class AuthenticationReqMessage
    {
        [BlubMember(1)]
        public uint AccountNumber { get; set; }

        [BlubMember(2, typeof(CStringSerializer))]
        public string Username { get; set; }
    }

    [ClientMessage(260)]
    [BlubContract]
    public class CharacterListReqMessage
    {
       
    }

    [ClientMessage(516)]
    [BlubContract]
    public class CharacterInfoReqMessage
    {
        [BlubMember(1)]
        public uint CharacterId { get; set; }
    }

    [ClientMessage(772)]
    [BlubContract]
    public class CharacterCreateReqMessage
    {
        [BlubMember(1)]
        public string Nickname { get; set; }

        [BlubMember(2)]
        public CharacterHero Hero { get; set; }

        [BlubMember(3)]
        public byte SkinColor { get; set; }
    }

    [ClientMessage(1028)]
    [BlubContract]
    public class CharacterDeleteReqMessage
    {
        /* Available only in JP version which is included in the client,
           so might as well add it here
         */
        [BlubMember(1)]
        public uint Unk1 { get; set; }

        [BlubMember(2)]
        public uint Unk2 { get; set; }

        [BlubMember(3)]
        public uint Slot { get; set; }

    }

    [ClientMessage(1284)]
    [BlubContract]
    public class ServiceConnectReqMessage
    {
        [BlubMember(1)]
        public uint CharacterId { get; set; }

        [BlubMember(2)]
        public byte[] Unk1 { get; set; }
    }
}
