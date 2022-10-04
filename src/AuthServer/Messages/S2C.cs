using ServerCore;
using ProtoBuf;


namespace AuthServer.Message
{
    [ServerMessage(4)]
    [ProtoContract]
    internal class AuthenticationAckMessage
    {

        [ProtoMember(1)]
        internal ushort Errorcode { get; set; }

        [ProtoMember(2)]
        internal uint AuthErrorCode { get; set; }

        [ProtoMember(3)]
        internal uint Unk1 { get; set; }

        [ProtoMember(4)]
        internal long Unk2 { get; set; } // Retarted devs

        [ProtoMember(5)]
        internal short Unk3 { get; set; } // Retarded devs v2

        [ProtoMember(6)]
        internal uint MaxCharacterSlots { get; set; }

        [ProtoMember(7)]
        internal byte Unk5 { get; set; }

        [ProtoMember(8)]
        internal uint Unk6 { get; set; }

        [ProtoMember(9)]
        internal uint Unk7 { get; set; }

        [ProtoMember(10)]
        internal uint Unk8 { get; set; } // Game Status or sth..

        [ProtoMember(11)]
        internal byte Unk9 { get; set; }

        [ProtoMember(12)]
        internal byte Unk10 { get; set; }

        [ProtoMember(13)]
        internal string ServerVersion { get; set; }

        internal AuthenticationAckMessage()
        {

        }
        internal AuthenticationAckMessage(ushort errorcode, ushort autherrorcode)
        {
            Errorcode = errorcode;
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
        internal byte[] padding { get; set; }

        [ProtoMember(4)]
        internal string username { get; set; }

        internal RetrieveCharacterAckMessage()
        {
            padding = new byte[16];
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
        internal ushort padding { get; set; } // Message starts after 6 bytes of the payload so this is useless

        [ProtoMember(2)]
        internal byte ServerEntries { get; set; }

        [ProtoMember(3)]
        internal byte Unk2 { get; set; } // Sorting ID?

        [ProtoMember(4)]
        internal byte Id { get; set; } // gotta check to make sure x')

        [ProtoMember(5)]
        internal ushort Unk3 { get; set; }

        [ProtoMember(6)]
        internal ushort Unk4 { get; set; }

        [ProtoMember(7)]
        internal ushort ServerPort { get; set; } 

        [ProtoMember(8)]
        internal uint ServerIP { get; set; }

        [ProtoMember(9)]
        internal byte[] Unk7 { get; set; } // 241 bytes x')

        [ProtoMember(10)]
        internal byte[] Unk8 { get; set; } // Same 241 bytes again!

        [ProtoMember(11)]
        internal byte[] Unk9 { get; set; } // Only 33 bytes this time

        internal ServerListAckMessage(byte id)
        {
            Unk2 = 0;
            Unk7 = new byte[241];
            Unk8 = new byte[241];
            Unk9 = new byte[33];
        }
    }

}
