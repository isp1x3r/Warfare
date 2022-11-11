using Warfare.Core;
using BlubLib.Serialization;
using Warfare.Network.Serializers;

namespace Warfare.Network.Message.Auth
{
    [BlubContract]
    public class ReLoginReqMessage : IAuthMessage
    {
        [BlubMember(0)]
        public uint Unk1 { get; set; }

        [BlubMember(1)]
        public uint AccountNumber { get; set; }

        [BlubMember(2)]
        public byte Unk2 { get; set; }

        [BlubMember(3)]
        public byte Unk3 { get; set; }
    }

    [BlubContract]
    public class AuthenticationReqMessage : IAuthMessage
    {
        [BlubMember(0)]
        public uint AccountNumber { get; set; }

        [BlubMember(1, typeof(StringSerializer), 17)]
        public string Username { get; set; }

    }


    [BlubContract]
    public class CharacterListReqMessage : IAuthMessage
    {

    }

    [BlubContract]
    public class CharacterInfoReqMessage : IAuthMessage
    {
        [BlubMember(0)]
        public uint CharacterId { get; set; }
    }

    [BlubContract]
    public class CharacterCreateReqMessage : IAuthMessage
    {
        [BlubMember(0, typeof(StringSerializer), 17)]
        public string Nickname { get; set; }

        [BlubMember(1)]
        public CharacterHero Hero { get; set; }

        [BlubMember(2)]
        public byte SkinColor { get; set; }
    }

    [BlubContract]
    public class CharacterDeleteReqMessage : IAuthMessage
    {
        /* Available only in JP version which is included in the client,
           so might as well add it here
         */
        [BlubMember(0)]
        public uint Unk1 { get; set; }

        [BlubMember(1)]
        public uint Unk2 { get; set; }

        [BlubMember(2)]
        public uint Slot { get; set; }

    }

    [BlubContract]
    public class ConnectReqMessage : IAuthMessage
    {
        [BlubMember(0)]
        public uint CharacterId { get; set; }

        [BlubMember(1, typeof(BinarySerializer), 125)]
        public byte[] Unk1 { get; set; }
    }

    [BlubContract]
    public class ServerListReqMessage : IAuthMessage
    {

    }

    [BlubContract]
    public class ChannelListReqMessage : IAuthMessage
    {

    }

    [BlubContract]
    public class ChecksumMessage : IAuthMessage
    {
        [BlubMember(0)]
        public byte Unk1 { get; set; }
        [BlubMember(1, typeof(StringSerializer), 99)]
        public string Checksum { get; set; }
    }
}
