using Warfare.Core;
using Warfare.Server.Auth.Data;
using BlubLib.Serialization;
using Warfare.Core.Serializers;
using BlubLib.Serialization.Serializers;
using System;

namespace Warfare.Server.Auth.Messages
{
    [ServerMessage(4)]
    [BlubContract]
    public class AuthenticationAckMessage
    {

        [BlubMember(1)]
        public ushort ErrorCode { get; set; }

        [BlubMember(2)]
        public uint AuthErrorCode { get; set; }

        [BlubMember(3, typeof(ByteArraySerializer), 10)]
        public byte[] Padding { get; set; }

        [BlubMember(4)]
        public uint CharacterSlots { get; set; }

        [BlubMember(5)]                      // Was used back in the day when garena was organizing LAN tournaments in internet coffee shops 
        public uint IsPCRoom { get; set; }    // Client actually expects 1 byte only since it's a boolean but them ape devs forgot to correctly cast it on their end *sigh*

        [BlubMember(6)]
        public uint AccountNumber { get; set; }

        [BlubMember(7, typeof(StringSerializer), 4)]
        public string Country { get; set; }

        [BlubMember(8)]
        public bool IsBanned { get; set; }

        [BlubMember(10, typeof(StringSerializer), 7)]
        public string TimeStamp { get; set; }

        public AuthenticationAckMessage() : this(0, 0)
        {
            Padding = Array.Empty<byte>();

        }
        public AuthenticationAckMessage(int errorcode, int autherrorcode)
        {
            ErrorCode = (ushort)errorcode;
            AuthErrorCode = (ushort)autherrorcode;

        }

    }

    [ServerMessage(260)]
    [BlubContract]
    public class CharacterListAckMessage
    {
        [BlubMember(1)]
        public RetrieveCharacterInfoError ErrorCode { get; set; }

        [BlubMember(2)]
        public uint CharacterCount { get; set; }

        [BlubMember(3, typeof(ByteArraySerializer), 16)]
        public byte[] Padding { get; set; }

        [BlubMember(4, typeof(StringSerializer), 17)]
        public string Nickname { get; set; }

        public CharacterListAckMessage()
        {
            Padding = Array.Empty<byte>();
        }
        public CharacterListAckMessage(RetrieveCharacterInfoError error) : this()
        {
            ErrorCode = error;
        }
    }

    [ServerMessage(516)]
    [BlubContract]
    public class CharacterInfoAckMessage
    {
        [BlubMember(1)]
        public CharacterInfoError ErrorCode { get; set; }

        [BlubMember(2)]
        public uint Unk1 { get; set; }

        [BlubMember(3, typeof(StringSerializer), 17)]
        public string Nickname { get; set; }

        [BlubMember(4)]
        public ushort Level { get; set; }

        [BlubMember(5)]
        public CharacterHero Hero { get; set; }

        [BlubMember(6)]
        public uint Experience { get; set; }

        [BlubMember(7)]
        public uint BountyPoints { get; set; }

        [BlubMember(8)]
        public uint Unk2 { get; set; }

        [BlubMember(9)]
        public uint Kills { get; set; }

        [BlubMember(10)]
        public uint Deaths { get; set; }

        [BlubMember(11)]
        public uint Wins { get; set; }

        [BlubMember(12)]
        public int Losses { get; set; }

        [BlubMember(13, typeof(ByteArraySerializer), 16)]
        public byte[] Padding { get; set; } // either a string or ape devs

        [BlubMember(14)]
        public uint Unk3 { get; set; }

        [BlubMember(15)]
        public uint Unk4 { get; set; }

        [BlubMember(16)]
        public string ClanName { get; set; }

        [BlubMember(17)]
        public uint ClanMark { get; set; }

        [BlubMember(18)]
        public short SkinColor { get; set; }

        [BlubMember(19)]
        public byte ItemCount { get; set; }

        [BlubMember(20)]
        public CharacterItemDto[] Items { get; set; }

        public CharacterInfoAckMessage()
        {
            Unk1 = 0;
            Unk2 = 0;
            Unk3 = 0;
            Unk4 = 0;
        }
        public CharacterInfoAckMessage(CharacterInfoError error)
        {
            ErrorCode = error;
        }
    }

    [ServerMessage(772)]
    [BlubContract]
    public class CharacterCreateAckMessage
    {
        [BlubMember(1)]
        public CharacterCreationError ErrorCode { get; set; }

        [BlubMember(2)]
        public uint Unk1 { get; set; } // Slot?

        public CharacterCreateAckMessage(CharacterCreationError error)
        {
            ErrorCode = error;
        }
        public CharacterCreateAckMessage()
        {

        }
    }

    [ServerMessage(1028)]
    [BlubContract]
    public class CharacterDeleteAckMessage
    {
        [BlubMember(1)]
        public CharacterScreenResult ScreenResult { get; set; }

        [BlubMember(2)]
        public uint Unk1 { get; set; }

        public CharacterDeleteAckMessage(CharacterScreenResult result)
        {
            ScreenResult = result;
        }
        public CharacterDeleteAckMessage()
        {

        }
    }

    [ServerMessage(1284)]
    [BlubContract]
    public class ServiceConnectAckMessage
    {
        [BlubMember(1)]
        public CharacterScreenResult ScreenResult { get; set; }

        [BlubMember(2)]
        public byte[] Unk1 { get; set; } // This is sent right back from the client on server join (Check Mercenary.Server.Lobby.Messages => LoginReqMessage.Unk1)

        public ServiceConnectAckMessage()
        {
            Unk1 = new byte[125];
        }
        public ServiceConnectAckMessage(CharacterScreenResult result)
        {
            ScreenResult = result;
        }
    }

    [ServerMessage(1540)]
    [BlubContract]
    public class ServerListAckMessage
    {
        [BlubMember(1)]
        public ushort Padding { get; set; } // Message starts after 6 bytes of the payload so this is useless

        [BlubMember(2)]
        public byte ServerEntries { get; set; }

        [BlubMember(3)]
        public ServerInfoDto[] Servers { get; set; }

        public ServerListAckMessage()
        {
            Padding = 0;
        }
    }

    [ServerMessage(1796)]
    [BlubContract]
    public class ChannelListAckMessage
    {        

        public ChannelListAckMessage()
        {

        }
    }

    [ServerMessage(2820)]
    [BlubContract]
    public class PlayerCashMessage
    {
        [BlubMember(1)]
        public uint Unk1 { get; set; }

        [BlubMember(2)]
        public uint PlayerCash { get; set; }

        public PlayerCashMessage()
        {

        }
        public PlayerCashMessage(uint playercash)
        {
            Unk1 = 0;
            PlayerCash = playercash;
        }
    }

    [ServerMessage(65284)]
    [BlubContract]
    public class NoticeMessage
    {
        [BlubMember(1)]
        public string Message { get; set; }

        public NoticeMessage(string message)
        {
            Message = message;
        }
    }

    [ServerMessage(4612)]
    [BlubContract]
    public class ErrorDetectedMessage
    {

    }

    [ServerMessage(3588)]
    [BlubContract]
    public class UserBanMessage
    {
        [BlubMember(1)]
        public uint Unk1 { get; set; }

        [BlubMember(2, typeof(ByteArraySerializer), 51)]
        public byte[] Padding { get; set; }

        [BlubMember(3)]
        public string BanReason { get; set; }

        public UserBanMessage(string banreason)
        {
            Unk1 = 0;
            BanReason = banreason;
        }
    }

    [ServerMessage(39172)]
    [BlubContract]
    public class LoadBannerMessage
    {
        [BlubMember(1)]
        public string Unk1 { get; set; }

        [BlubMember(2)]
        public string Unk2 { get; set; } // This is most likely the filename of the banner inside of Scene\Interface 
    }

}
