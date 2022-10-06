using ServerCore;
using ProtoBuf;
using Mercenary.Auth.Data;

namespace AuthServer.Message
{
    [ServerMessage(4)]
    [ProtoContract]
    internal class AuthenticationAckMessage
    {

        [ProtoMember(1)]
        internal ushort ErrorCode { get; set; }

        [ProtoMember(2)]
        internal uint AuthErrorCode { get; set; }

        [ProtoMember(3)]
        internal byte[] Padding1 { get; set; }

        [ProtoMember(4)]
        internal uint CharacterSlots { get; set; }

        [ProtoMember(5)]                      // Was used back in the day when garena was organizing LAN tournaments in internet coffee shops 
        internal uint IsPCRoom { get; set; }  // Client actually expects 1 byte only since it's a boolean but them ape devs forgot to correctly cast it on their end *sigh*
                                    
        [ProtoMember(6)]
        internal uint AccountNumber { get; set; }

        [ProtoMember(7)]
        internal string Country { get; set; }

        [ProtoMember(8)]
        internal byte Unk1 { get; set; }

        [ProtoMember(10)]
        internal string TimeStamp { get; set; }

        internal AuthenticationAckMessage()
        {
            ErrorCode = 0;
            AuthErrorCode = 0;
            Padding1 = new byte[10];
        }
        internal AuthenticationAckMessage(ushort errorcode, ushort autherrorcode)
        {
            ErrorCode = errorcode;
            AuthErrorCode = autherrorcode;
        }

    }

    [ServerMessage(260)]
    [ProtoContract]
    internal class RetrieveCharacterAckMessage
    {
        [ProtoMember(1)]
        internal RetrieveCharacterInfoError ErrorCode { get; set; }

        [ProtoMember(2)]
        internal uint CharacterCount { get; set; }

        [ProtoMember(3)]
        internal byte[] Padding { get; set; }

        [ProtoMember(4)]
        internal string username { get; set; }

        internal RetrieveCharacterAckMessage()
        {
            Padding = new byte[16];
        }
        internal RetrieveCharacterAckMessage(RetrieveCharacterInfoError error)
        {
            ErrorCode = error;
        }
    }

    [ServerMessage(516)]
    [ProtoContract]
    internal class CharacterInfoAckMessage
    {
        [ProtoMember(1)]
        internal CharacterInfoError ErrorCode { get; set; }

        [ProtoMember(2)]
        internal uint Unk1 { get; set; }

        [ProtoMember(3)]
        internal string Nickname { get; set; }

        [ProtoMember(4)]
        internal ushort Level { get; set; }

        [ProtoMember(5)]
        internal CharacterHero Hero { get; set; }

        [ProtoMember(6)]
        internal uint Experience { get; set; }

        [ProtoMember(7)]
        internal uint BountyPoints { get; set; }

        [ProtoMember(8)]
        internal uint Unk2 { get; set; }

        [ProtoMember(9)]
        internal uint Kills { get; set; }

        [ProtoMember(10)]
        internal uint Deaths { get; set; }

        [ProtoMember(11)]
        internal uint Wins { get; set; }

        [ProtoMember(12)]
        internal int Losses { get; set; }

        [ProtoMember(13)]
        internal byte[] Padding { get; set; } // either a string or ape devs

        [ProtoMember(14)]
        internal uint Unk3 { get; set; }

        [ProtoMember(15)]
        internal uint Unk4 { get; set; }

        [ProtoMember(16)]
        internal string ClanName { get; set; }

        [ProtoMember(17)]
        internal string ClanMark { get; set; }

        [ProtoMember(18)]
        internal short SkinColor { get; set; }

        [ProtoMember(19)]
        internal byte ItemCount { get; set; }

        [ProtoMember(20)]
        internal CharacterItemsDto[] Items { get; set; }

        internal CharacterInfoAckMessage()
        {
            Padding = new byte[16];
        }
        internal CharacterInfoAckMessage(CharacterInfoError error)
        {
            ErrorCode = error;
        }
    }

    [ServerMessage(772)]
    [ProtoContract]
    internal class CharacterCreateAckMessage
    {
       [ProtoMember(1)]
        internal CharacterCreationError ErrorCode { get; set; }

        [ProtoMember(2)]
        internal uint Unk1 { get; set; } // Slot?

        internal CharacterCreateAckMessage(CharacterCreationError error)
        {
            ErrorCode = error;
        }
        internal CharacterCreateAckMessage()
        {

        }
    }

    [ServerMessage(1028)]
    [ProtoContract]
    internal class CharacterDeleteAckMessage
    {
        [ProtoMember(1)]
        internal CharacterScreenResult ScreenResult { get; set; }

        [ProtoMember(2)]
        internal uint Unk1 { get; set; }

        internal CharacterDeleteAckMessage(CharacterScreenResult result)
        {
            ScreenResult = result;
        }
        internal CharacterDeleteAckMessage()
        {

        }
    }

    [ServerMessage(1284)]
    [ProtoContract]
    internal class ServiceConnectAckMessage
    {
        [ProtoMember(1)]
        internal CharacterScreenResult ScreenResult { get; set; }

        [ProtoMember(2, IsPacked = true)]
        internal byte[] Unk1 { get; set; } // This is sent right back from the client on server join (Check LobbyServer.Messages => LoginReqMessage.Unk1)

        internal ServiceConnectAckMessage()
        {
            Unk1 = new byte[125];
        }
        internal ServiceConnectAckMessage(CharacterScreenResult result)
        {
            ScreenResult = result;
        }
    }

    [ServerMessage(1540)]
    [ProtoContract]
    internal class ServerListAckMessage
    {
        [ProtoMember(1)]
        internal ushort Padding { get; set; } // Message starts after 6 bytes of the payload so this is useless

        [ProtoMember(2)]
        internal byte ServerEntries { get; set; }

        [ProtoMember(3)]
        internal ServerInfoDto[] Servers { get; set; }

        internal ServerListAckMessage()
        {
            Padding = 0;
        }
    }

}
