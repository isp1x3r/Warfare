﻿using Warfare.Core;
using Warfare.Network.Data.Auth;
using BlubLib.Serialization;
using Warfare.Network.Serializers;

namespace Warfare.Network.Message.Auth
{
    [BlubContract]
    public class AuthenticationErrorMessage : IAuthMessage
    {
        [BlubMember(1)]
        public ushort ErrorCode { get; set; }

        [BlubMember(2)]
        public uint AuthErrorCode { get; set; }

        public AuthenticationErrorMessage()
        { }
        public AuthenticationErrorMessage(int errorCode, int authErrorCode)
        {
            ErrorCode = (ushort)errorCode;
            AuthErrorCode = (uint)authErrorCode;
        }
    }

    [BlubContract]
    public class AuthenticationAckMessage : AuthenticationErrorMessage
    {

        [BlubMember(1, typeof(BinarySerializer), 10)]
        public byte[] Padding { get; set; }

        [BlubMember(2)]
        public uint CharacterSlots { get; set; }

        [BlubMember(3)]                      // Was used back in the day when garena was organizing LAN tournaments in internet coffee shops 
        public uint IsPCRoom { get; set; }    // Client actually expects 1 byte only since it's a boolean but them ape devs forgot to correctly cast it on their end *sigh*

        [BlubMember(4)]
        public byte Padding2 { get; set; }

        [BlubMember(5)]
        public uint AccountNumber { get; set; }

        [BlubMember(6, typeof(StringSerializer), 4)]
        public string Country { get; set; }

        [BlubMember(7)]
        public bool IsBanned { get; set; }

        [BlubMember(8)]
        public byte Unk1 { get; set; }

        [BlubMember(9, typeof(StringSerializer), 16)]
        public string TimeStamp { get; set; }

        public AuthenticationAckMessage() : base(0,0)
        {
            Padding = Array.Empty<byte>();
            Unk1 = 0;
        }

    }

    [BlubContract]
    public class CharacterListErrorMessage : IAuthMessage
    {
        [BlubMember(1)]
        public CharacterInfoError ErrorCode { get; set; }

        public CharacterListErrorMessage()
        { }
        public CharacterListErrorMessage(CharacterInfoError error)
        {
            ErrorCode = error;
        }
    }

    [BlubContract]
    public class CharacterListAckMessage : CharacterListErrorMessage
    {
        [BlubMember(1)]
        public uint CharacterCount { get; set; }

        [BlubMember(2, typeof(BinarySerializer), 12)]
        public byte[] Padding { get; set; }

        [BlubMember(3, typeof(StringSerializer), 68)]
        public string Nickname1 { get; set; }

        [BlubMember(4, typeof(StringSerializer), 68)]
        public string Nickname2 { get; set; }

        [BlubMember(5, typeof(StringSerializer), 68)]
        public string Nickname3 { get; set; }

        [BlubMember(6, typeof(StringSerializer), 68)]
        public string Nickname4 { get; set; }

        [BlubMember(7)]
        public byte Flag { get; set; }

        public CharacterListAckMessage() : base(0)
        {
            Padding = Array.Empty<byte>();
        }
 
    }

    [BlubContract]
    public class CharacterInfoErrorMessage : IAuthMessage
    {
        [BlubMember(1)]
        public CharacterInfoError ErrorCode { get; set; }

        public CharacterInfoErrorMessage()
        { }
        public CharacterInfoErrorMessage(CharacterInfoError error)
        {
            ErrorCode = error;
        }
    }

    [BlubContract]
    public class CharacterInfoAckMessage : CharacterInfoErrorMessage
    {   
        [BlubMember(1)]
        public uint CharacterID { get; set; }

        [BlubMember(2, typeof(StringSerializer), 17)]
        public string Nickname { get; set; }

        [BlubMember(3)]
        public ushort Level { get; set; }

        [BlubMember(4)]
        public CharacterHero Hero { get; set; }

        [BlubMember(5)]
        public uint Experience { get; set; }

        [BlubMember(6)]
        public uint BountyPoints { get; set; }

        [BlubMember(7)]
        public uint Unk1 { get; set; }

        [BlubMember(8)]
        public uint Kills { get; set; }

        [BlubMember(9)]
        public uint Deaths { get; set; }

        [BlubMember(10)]
        public uint Wins { get; set; }

        [BlubMember(11)]
        public int Losses { get; set; }

        [BlubMember(12, typeof(BinarySerializer), 16)]
        public byte[] Padding { get; set; } // either a string or ape devs

        [BlubMember(13)]
        public uint Unk2 { get; set; }

        [BlubMember(14)]
        public uint Unk3 { get; set; }

        [BlubMember(15, typeof(StringSerializer), 17)]
        public string ClanName { get; set; }

        [BlubMember(16)]
        public uint ClanMark { get; set; }

        [BlubMember(17)]
        public short SkinColor { get; set; }

        [BlubMember(18)]
        public byte ItemCount { get; set; }

       // [BlubMember(19, typeof(ArraySerializer))]
        //public CharacterItemDto[] Items { get; set; }

        public CharacterInfoAckMessage() : base()
        {
            Padding = Array.Empty<byte>();
            Unk1 = 0;
            Unk2 = 0;
            Unk3 = 0;
            //Items = Array.Empty<CharacterItemDto>();
        }
    }

    [BlubContract]
    public class CharacterCreationErrorMessage : IAuthMessage
    {
        [BlubMember(1)]
        public CharacterCreationError ErrorCode { get; set; }

        public CharacterCreationErrorMessage()
        { }
        public CharacterCreationErrorMessage(CharacterCreationError error)
        {
            ErrorCode = error;
        }
    }

    [BlubContract]
    public class CharacterCreateAckMessage : CharacterCreationErrorMessage
    {      
        [BlubMember(1)]
        public uint Unk1 { get; set; } // Slot?

        public CharacterCreateAckMessage() : base()
        {

        }
    }

    [BlubContract]
    public class CharacterDeleteErrorMessage : IAuthMessage
    {
        [BlubMember(1)]
        public CharacterScreenResult ScreenResult { get; set; }

        public CharacterDeleteErrorMessage()
        { }
        public CharacterDeleteErrorMessage(CharacterScreenResult result)
        {
            ScreenResult = result;
        }
    }
    [BlubContract]
    public class CharacterDeleteAckMessage : CharacterDeleteErrorMessage
    {
        [BlubMember(1)]
        public uint Unk1 { get; set; }

        public CharacterDeleteAckMessage() : base()
        {

        }
    }

    [BlubContract]
    public class ConnectErrorMessage : IAuthMessage
    {
        [BlubMember(1)]
        public CharacterScreenResult ScreenResult { get; set; }

        public ConnectErrorMessage()
        { }
        public ConnectErrorMessage(CharacterScreenResult result)
        {
            ScreenResult = result;
        }
    }

    [BlubContract]
    public class ConnectAckMessage : ConnectErrorMessage
    {     
        [BlubMember(1, typeof(BinarySerializer), 125)]
        public byte[] Unk1 { get; set; } // This is sent right back from the client on server join (Check Mercenary.Server.Lobby.Messages => LoginReqMessage.Unk1)

        public ConnectAckMessage() : base()
        {
            Unk1 = Array.Empty<byte>();
        }

    }

    [BlubContract]
    public class ServerListAckMessage : IAuthMessage
    {
        [BlubMember(1)]
        public ushort Padding { get; set; } // Message starts after 6 bytes of the payload so this is useless

        [BlubMember(2)]
        public byte ServerEntries { get; set; }

        [BlubMember(3, typeof(ArraySerializer))]
        public ServerInfoDto[] Servers { get; set; }

        public ServerListAckMessage()
        {
            
        }
    }

    [BlubContract]
    public class ChannelListAckMessage : IAuthMessage
    {
        [BlubMember(1, typeof(ArraySerializer))]
        public ChannelDto[] Channels { get; set; }

        public ChannelListAckMessage()
        {
            
        }
    }

    [BlubContract]
    public class PlayerCashMessage : IAuthMessage
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
            PlayerCash = playercash;
        }
    }

    [BlubContract]
    public class NoticeMessage : IAuthMessage
    {
        [BlubMember(1)]
        public string Message { get; set; }

        public NoticeMessage()
        {

        }

        public NoticeMessage(string message)
        {
            Message = message;
        }
    }

    [BlubContract]
    public class ErrorDetectedMessage : IAuthMessage
    {

    }

    [BlubContract]
    public class UserBanMessage : IAuthMessage
    {
        [BlubMember(1)]
        public uint Unk1 { get; set; }

        [BlubMember(2, typeof(BinarySerializer), 51)]
        public byte[] Padding { get; set; }

        [BlubMember(3)]
        public string BanReason { get; set; }

        public UserBanMessage()
        {

        }

        public UserBanMessage(string banreason)
        {
            Unk1 = 0;
            BanReason = banreason;
        }
    }

    [BlubContract]
    public class LoadBannerMessage : IAuthMessage
    {
        [BlubMember(1)]
        public string Unk1 { get; set; }

        [BlubMember(2)]
        public string Unk2 { get; set; } // This is most likely the filename of the banner inside of Scene\Interface 
    }

}
