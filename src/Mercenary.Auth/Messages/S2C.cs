﻿using ServerCore;
using ProtoBuf;


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

        [ProtoMember(5)]                      
        internal uint IsPCRoom { get; set; } // Was used back in the day when garena was organizing LAN tournaments in internet coffee shops 

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
        internal byte[] Padding { get; set; } // Has a length of 16 (suspecting a string)

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

        internal CharacterInfoAckMessage()
        {
            Padding = new byte[16];
            ItemCount = 0; // For now
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
        internal byte Unk1 { get; set; } // Sorting ID?

        [ProtoMember(4)]
        internal byte Id { get; set; } // gotta check to make sure x')

        [ProtoMember(5)]
        internal ushort Unk2 { get; set; }

        [ProtoMember(6)]
        internal ushort Unk3 { get; set; }

        [ProtoMember(7)]
        internal ushort ServerPort { get; set; } 

        [ProtoMember(8)]
        internal uint ServerIP { get; set; }

        [ProtoMember(9, IsPacked = true)]
        internal byte[] Unk4 { get; set; } 

        [ProtoMember(10, IsPacked = true)]
        internal byte[] Unk5 { get; set; }

        [ProtoMember(11, IsPacked = true)]
        internal byte[] Unk6 { get; set; }

        internal ServerListAckMessage(byte id)
        {
            Padding = 0;
            Unk2 = 0;
            Unk4= new byte[241];
            Unk5 = new byte[241];
            Unk6 = new byte[33];
        }
    }

}