using ServerCore;
using ProtoBuf;


namespace AuthServer.Message
{
    [ServerMessage(4)]
    [ProtoContract]
    public class AuthenticationAckMessage
    {

        [ProtoMember(1, IsRequired = false)]
        public ushort Errorcode { get; set; }

        [ProtoMember(2, IsRequired = false)]
        public uint AuthErrorCode { get; set; }

        [ProtoMember(3)]
        public uint Unk1 { get; set; }

        [ProtoMember(4)]
        public long Unk2 { get; set; } // Retarted devs

        [ProtoMember(5)]
        public short Unk3 { get; set; } // Retarded devs v2

        [ProtoMember(6)]
        public uint MaxCharacterSlots { get; set; }

        [ProtoMember(7)]
        public byte Unk5 { get; set; }

        [ProtoMember(8)]
        public uint Unk6 { get; set; }

        [ProtoMember(9)]
        public uint Unk7 { get; set; }

        [ProtoMember(10)]
        public uint Unk8 { get; set; } // Game Status or sth..

        [ProtoMember(11)]
        public byte Unk9 { get; set; }

        [ProtoMember(12)]
        public byte Unk10 { get; set; }

        [ProtoMember(13)]
        public string ServerVersion { get; set; }

        public AuthenticationAckMessage(ushort errorcode, ushort autherrorcode)
        {
            Errorcode = errorcode;
            AuthErrorCode = autherrorcode;
        }
        public AuthenticationAckMessage()
        {

        }

    }

    [ServerMessage(260)]
    [ProtoContract]
    public class RetrieveCharacterAckMessage
    {
        [ProtoMember(1, IsRequired = false)]
        public RetrieveCharacterInfoError ErrorCode { get; set; }

        [ProtoMember(2)]
        public uint CharacterCount { get; set; }

        [ProtoMember(3)]
        public byte[] padding { get; set; }

        [ProtoMember(4)]
        public string username { get; set; }

        public RetrieveCharacterAckMessage(RetrieveCharacterInfoError error )
        {
            ErrorCode = error;
        }
        public RetrieveCharacterAckMessage()
        {
            padding = new byte[16];
        }
    }

    [ServerMessage(516)]
    [ProtoContract]
    public class CharacterInfoAckMessage
    {
        [ProtoMember(1, IsRequired = false)]
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
        public byte[] Padding { get; set; } // Has a length of 16 (suspecting a string)

        [ProtoMember(14)]
        public uint Unk3 { get; set; }

        [ProtoMember(15)]
        public uint Unk4 { get; set; }

        [ProtoMember(16)]
        public string ClanName { get; set; }

        [ProtoMember(17)]
        public string ClanMark { get; set; }

        [ProtoMember(18)]
        public short SkinColor { get; set; }

        [ProtoMember(19)]
        public byte ItemCount { get; set; }

        public CharacterInfoAckMessage(CharacterInfoError error)
        {
            ErrorCode = error;
        }
        public CharacterInfoAckMessage()
        {
            Padding = new byte[16];
            ItemCount = 0; // For now
        }
    }

    [ServerMessage(772)]
    [ProtoContract]
    public class CharacterCreateAckMessage
    {
       [ProtoMember(1, IsRequired = false)]
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
        [ProtoMember(1, IsRequired = false)]
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
        [ProtoMember(1, IsRequired = false)]
        public CharacterScreenResult ScreenResult { get; set; }

        [ProtoMember(2)]
        public byte[] Unk1 { get; set; }

        public ServiceConnectAckMessage(CharacterScreenResult result)
        {
            ScreenResult = result;
        }
        public ServiceConnectAckMessage()
        {
            Unk1 = new byte[125];
        }
    }

    [ServerMessage(1540)]
    [ProtoContract]
    public class ServerListAckMessage
    {
        [ProtoMember(1)]
        public ushort padding { get; set; } // Message starts after 6 bytes of the payload so this is useless

        [ProtoMember(2)]
        public byte ServerEntries { get; set; }

        [ProtoMember(3)]
        public byte Unk2 { get; set; } 

        [ProtoMember(4)]
        public byte Id { get; set; } // gotta check to make sure x')

        [ProtoMember(5)]
        public ushort Unk3 { get; set; }

        [ProtoMember(6)]
        public ushort Unk4 { get; set; }

        [ProtoMember(7)]
        public short Unk5 { get; set; } // ServerPort Maybe?

        [ProtoMember(8)]
        public uint Unk6 { get; set; } // ServerIP Maybe?

        [ProtoMember(9)]
        public byte[] Unk7 { get; set; } // 241 bytes x')

        [ProtoMember(10)]
        public byte[] Unk8 { get; set; } // Same 241 bytes again!

        [ProtoMember(11)]
        public byte[] Unk9 { get; set; } // Only 33 bytes this time

        public ServerListAckMessage(byte id)
        {
            Unk2 = 0;
            Unk7 = new byte[241];
            Unk8 = new byte[241];
            Unk9 = new byte[33];
        }
    }

}
