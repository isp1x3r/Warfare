using ServerCore;
using log4net.Core;
using ProtoBuf;


namespace ServerCore.Message.Auth
{
    [ProtoContract]
    public class AuthenticationAckMessage : IMessage
    {

        [ProtoMember(0)]
        public ushort Errorcode { get; set; }

        [ProtoMember(1)]
        public uint Errorcode2 { get; set; } // lul

        [ProtoMember(2)]
        public uint Unk1 { get; set; }

        [ProtoMember(3)]
        public long Unk2 { get; set; }

        [ProtoMember(4)]
        public short Unk3 { get; set; }

        [ProtoMember(5)]
        public uint Unk4 { get; set; } // GameVersion??

        [ProtoMember(6)]
        public byte Unk5 { get; set; }

        [ProtoMember(7)]
        public uint Unk6 { get; set; }

        [ProtoMember(8)]
        public uint Unk7 { get; set; }

        [ProtoMember(9)]
        public uint Unk8 { get; set; } // Game Status or sth..

        [ProtoMember(10)]
        public byte Unk9 { get; set; }

        [ProtoMember(11)]
        public byte Unk10 { get; set; }

        [ProtoMember(12)]
        public string ServerVersion { get; set; }

        public AuthenticationAckMessage()
        {

        }

    }

    [ProtoContract]
    public class RetrieveCharacterAckMessage
    {
        [ProtoMember(0)]
        public ushort Errorcode { get; set; }

        [ProtoMember(1)]
        public uint CharacterCount { get; set; }

        [ProtoMember(2)]
        public byte[] padding { get; set; }

        [ProtoMember(3)]
        public string username { get; set; }

        public RetrieveCharacterAckMessage()
        {
            padding = new byte[16];
        }
    }

    [ProtoContract]
    public class CharacterInfoAckMessage
    {
        [ProtoMember(0)]
        public ushort ErrorCode { get; set; }

        [ProtoMember(1)]
        public uint Unk1 { get; set; }

        [ProtoMember(2)]
        public string CharacterName { get; set; }

        [ProtoMember(3)]
        public ushort Level { get; set; }

        [ProtoMember(4)]
        public CharacterHero Hero { get; set; }

        [ProtoMember(5)]
        public uint Experience { get; set; }

        [ProtoMember(6)]
        public uint BountyPoints { get; set; }

        [ProtoMember(7)]
        public uint Unk2 { get; set; }

        [ProtoMember(8)]
        public uint Kills { get; set; }

        [ProtoMember(9)]
        public uint Deaths { get; set; }

        [ProtoMember(10)]
        public uint Wins { get; set; }

        [ProtoMember(11)]
        public int Losses { get; set; }

        [ProtoMember(12)]
        public byte[] Padding { get; set; } // Has a length of 16 (suspecting a string)

        [ProtoMember(13)]
        public uint Unk3 { get; set; }

        [ProtoMember(14)]
        public uint Unk4 { get; set; }

        [ProtoMember(15)]
        public string ClanName { get; set; }

        [ProtoMember(16)]
        public string ClanMark { get; set; }

        [ProtoMember(17)]
        public short SkinColor { get; set; }

        [ProtoMember(18)]
        public byte ItemCount { get; set; }

        public CharacterInfoAckMessage()
        {
            Padding = new byte[16];
            ItemCount = 0; // For now
        }
    }

    [ProtoContract]
    public class CharacterDeleteAckMessage
    {
        [ProtoMember(0)]
        public CharacterScreenResult ScreenResult { get; set; }

        [ProtoMember(1)]
        public uint Unk1 { get; set; }
        
        public CharacterDeleteAckMessage()
        {

        }
    }

    [ProtoContract]
    public class ServiceConnectAckMessage
    {
        [ProtoMember(0)]
        public CharacterScreenResult ScreenResult { get; set; }

        [ProtoMember(1)]
        public byte[] Unk1 { get; set; }

        public ServiceConnectAckMessage()
        {
            Unk1 = new byte[125];
        }
    }

    [ProtoContract]
    public class ServerListAckMessage
    {
        [ProtoMember(0)]
        public ushort Unk1 { get; set; }

        [ProtoMember(1)]
        public byte ServerEntries { get; set; }

        [ProtoMember(2)]
        public byte Unk2 { get; set; } 

        [ProtoMember(3)]
        public byte Id { get; set; } // gotta check to make sure x')

        [ProtoMember(4)]
        public ushort Unk3 { get; set; }

        [ProtoMember(5)]
        public ushort Unk4 { get; set; }

        [ProtoMember(6)]
        public short Unk5 { get; set; } // ServerPort Maybe?

        [ProtoMember(7)]
        public uint Unk6 { get; set; } // ServerIP Maybe?

        [ProtoMember(8)]
        public byte[] Unk7 { get; set; } // 241 bytes x')

        [ProtoMember(9)]
        public byte[] Unk8 { get; set; } // Same 241 bytes again!

        [ProtoMember(10)]
        public byte[] Unk9 { get; set; } // Only 33 bytes this time

        public ServerListAckMessage(byte id)
        {
            Id = (byte)(id & 7);
            Unk7 = new byte[241];
            Unk8 = new byte[241];
            Unk9 = new byte[33];
        }
    }

}
