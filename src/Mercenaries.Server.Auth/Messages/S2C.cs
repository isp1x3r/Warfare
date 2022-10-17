using Mercenaries.Core;
using Mercenaries.Server.Auth.Data;
using ProtoBuf;

namespace Mercenaries.Server.Auth.Messages
{
    [ServerMessage(4)]
    [ProtoContract]
    public class AuthenticationAckMessage
    {

        [ProtoMember(1)]
        public ushort ErrorCode { get; set; }

        [ProtoMember(2)]
        public uint AuthErrorCode { get; set; }

        [ProtoMember(3)]
        public byte[] Padding { get; set; }

        [ProtoMember(4)]
        public uint CharacterSlots { get; set; }

        [ProtoMember(5)]                      // Was used back in the day when garena was organizing LAN tournaments in internet coffee shops 
        public uint IsPCRoom { get; set; }    // Client actually expects 1 byte only since it's a boolean but them ape devs forgot to correctly cast it on their end *sigh*

        [ProtoMember(6)]
        public uint AccountNumber { get; set; }

        [ProtoMember(7)]
        public string Country { get; set; }

        [ProtoMember(8)]
        public byte Unk1 { get; set; }

        [ProtoMember(10)]
        public string TimeStamp { get; set; }

        public AuthenticationAckMessage()
        {
            ErrorCode = 0;
            AuthErrorCode = 0;
            Padding = new byte[10];
        }
        public AuthenticationAckMessage(ushort errorcode, ushort autherrorcode)
        {
            ErrorCode = errorcode;
            AuthErrorCode = autherrorcode;
        }

    }

    [ServerMessage(260)]
    [ProtoContract]
    public class CharacterListAckMessage
    {
        [ProtoMember(1)]
        public RetrieveCharacterInfoError ErrorCode { get; set; }

        [ProtoMember(2)]
        public uint CharacterCount { get; set; }

        [ProtoMember(3)]
        public byte[] Padding { get; set; }

        [ProtoMember(4)]
        public string Username { get; set; }

        public CharacterListAckMessage()
        {
            Padding = new byte[16];
        }
        public CharacterListAckMessage(RetrieveCharacterInfoError error)
        {
            ErrorCode = error;
        }
    }

    [ServerMessage(516)]
    [ProtoContract]
    public class CharacterInfoAckMessage
    {
        [ProtoMember(1)]
        public CharacterInfoError ErrorCode { get; set; }

        [ProtoMember(2)]
        public uint Unk1 { get; set; }

        [ProtoMember(3)]
        public string Nickname { get; set; }

        [ProtoMember(4)]
        public ushort Level { get; set; }

        [ProtoMember(5)]
        public CharacterHero Hero { get; set; }

        [ProtoMember(6)]
        public uint Experience { get; set; }

        [ProtoMember(7)]
        public uint BountyPoints { get; set; }

        [ProtoMember(8)]
        public uint Unk2 { get; set; }

        [ProtoMember(9)]
        public uint Kills { get; set; }

        [ProtoMember(10)]
        public uint Deaths { get; set; }

        [ProtoMember(11)]
        public uint Wins { get; set; }

        [ProtoMember(12)]
        public int Losses { get; set; }

        [ProtoMember(13)]
        public byte[] Padding { get; set; } // either a string or ape devs

        [ProtoMember(14)]
        public uint Unk3 { get; set; }

        [ProtoMember(15)]
        public uint Unk4 { get; set; }

        [ProtoMember(16)]
        public string ClanName { get; set; }

        [ProtoMember(17)]
        public uint ClanMark { get; set; }

        [ProtoMember(18)]
        public short SkinColor { get; set; }

        [ProtoMember(19)]
        public byte ItemCount { get; set; }

        [ProtoMember(20)]
        public CharacterItemDto[] Items { get; set; }

        public CharacterInfoAckMessage()
        {
            Padding = new byte[16];
        }
        public CharacterInfoAckMessage(CharacterInfoError error)
        {
            ErrorCode = error;
        }
    }

    [ServerMessage(772)]
    [ProtoContract]
    public class CharacterCreateAckMessage
    {
        [ProtoMember(1)]
        public CharacterCreationError ErrorCode { get; set; }

        [ProtoMember(2)]
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
    [ProtoContract]
    public class CharacterDeleteAckMessage
    {
        [ProtoMember(1)]
        public CharacterScreenResult ScreenResult { get; set; }

        [ProtoMember(2)]
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
    [ProtoContract]
    public class ServiceConnectAckMessage
    {
        [ProtoMember(1)]
        public CharacterScreenResult ScreenResult { get; set; }

        [ProtoMember(2, IsPacked = true)]
        public byte[] Unk1 { get; set; } // This is sent right back from the client on server join (Check Network.Message.Lobby => LoginReqMessage.Unk1)

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
    [ProtoContract]
    public class ServerListAckMessage
    {
        [ProtoMember(1)]
        public ushort Padding { get; set; } // Message starts after 6 bytes of the payload so this is useless

        [ProtoMember(2)]
        public byte ServerEntries { get; set; }

        [ProtoMember(3)]
        public ServerInfoDto[] Servers { get; set; }

        public ServerListAckMessage()
        {
            Padding = 0;
        }
    }

    [ServerMessage(1796)]
    [ProtoContract]
    public class ChannelListAckMessage
    {        

        public ChannelListAckMessage()
        {

        }
    }

    [ServerMessage(2820)]
    [ProtoContract]
    public class PlayerCashMessage
    {
        [ProtoMember(1)]
        public uint Unk1 { get; set; }

        [ProtoMember(2)]
        public uint PlayerCash { get; set; }

        public PlayerCashMessage(uint playercash)
        {
            Unk1 = 0;
            PlayerCash = playercash;
        }
    }

    [ServerMessage(65284)]
    [ProtoContract]
    public class NoticeMessage
    {
        [ProtoMember(1)]
        public string Message { get; set; }

        public NoticeMessage(string message)
        {
            Message = message;
        }
    }

    [ServerMessage(4612)]
    [ProtoContract]
    public class ErrorDetectedMessage
    {

    }

    [ServerMessage(3588)]
    [ProtoContract]
    public class UserBanMessage
    {
        [ProtoMember(1)]
        public uint Unk1 { get; set; }

        [ProtoMember(2)]
        public byte[] Padding { get; set; }

        [ProtoMember(3)]
        public string BanReason { get; set; }

        public UserBanMessage(string banreason)
        {
            Unk1 = 0;
            Padding = new byte[51];
            BanReason = banreason;
        }
    }

    [ServerMessage(39172)]
    [ProtoContract]
    public class LoadBannerMessage
    {
        [ProtoMember(1)]
        public string Unk1 { get; set; }

        [ProtoMember(2)]
        public string Unk2 { get; set; } // This is most likely the filename of the banner inside of Scene\Interface 
    }

}
