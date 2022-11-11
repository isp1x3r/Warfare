using Warfare.Core;
using BlubLib.Serialization;
using Warfare.Network.Serializers;

namespace Warfare.Network.Message.Lobby
{
    [BlubContract]
    public class LoginAckMessage : ILobbyMessage
    {
        [BlubMember(1)]
        public LoginResult LoginResult { get; set; }

        public LoginAckMessage()
        {

        }
        public LoginAckMessage(LoginResult loginResult)
        {
            LoginResult = loginResult;
        }
    }

    [BlubContract]
    public class RoomCreateErrorMessage : ILobbyMessage
    {
        [BlubMember(0)]
        public RoomCreateResult Result { get; set; }

        public RoomCreateErrorMessage(RoomCreateResult result)
        {
            Result = result;
        }
    }

    [BlubContract]
    public class RoomCreateAckMessage : RoomCreateErrorMessage
    {
        [BlubMember(0)]
        public uint Unk1 { get; set; }

        [BlubMember(1)]
        public uint Unk2 { get; set; }

        [BlubMember(2)]
        public ushort Unk3 { get; set; }

        [BlubMember(3)]
        public uint Unk4 { get; set; }

        [BlubMember(4)]
        public byte GameMode { get; set; }

        public RoomCreateAckMessage() : base(RoomCreateResult.Success)
        {
            Unk1 = 2;
            Unk2 = 7;
            Unk3 = 60;
            Unk4 = 12;
            GameMode = 3;
        }
    }
    [BlubContract]
    public class RoomInfoMessage : ILobbyMessage
    {
        [BlubMember(0)]
        public byte Unk1 { get; set; }

        [BlubMember(1)]
        public byte Unk2 { get; set; }

        [BlubMember(3, typeof(StringWithPrefixSerializer))]
        public string RoomName { get; set; }

        [BlubMember(4)]
        public ushort Unk3 { get; set; }

        [BlubMember(5)]
        public byte Unk4 { get; set; }

        [BlubMember(6)]
        public byte Unk5 { get; set; }

        [BlubMember(7)]
        public byte Unk6 { get; set; }

        [BlubMember(8)]
        public byte GameMode { get; set; }

        [BlubMember(9)]
        public ushort Unk7 { get; set; }

        [BlubMember(10)]
        public byte Unk8 { get; set; }

        [BlubMember(11, typeof(StringWithPrefixSerializer))]
        public string Unk9 { get; set; }

        [BlubMember(12)]
        public byte Unk10 { get; set; }

        [BlubMember(13)]
        public byte Unk11 { get; set; }

        [BlubMember(14)]
        public byte Unk12 { get; set; }

        [BlubMember(15)]
        public byte Unk13 { get; set; }

        [BlubMember(16)]
        public byte Unk14 { get; set; }

        public RoomInfoMessage()
        {
            RoomName = "Test room name";
            GameMode = 3;
            Unk1 = 1;
            Unk2 = 1;
            Unk3 = 1;
            Unk4 = 1;
            Unk5 = 1;
            Unk6 = 1;
            Unk7 = 1;
            Unk8 = 1;
            Unk9 = "Another test";
        }

    }

    [BlubContract]
    public class MiscAckMessage : ILobbyMessage
    {
        
    }
    [BlubContract]
    public class LobbyPlayer : MiscAckMessage
    {
        [BlubMember(0)]
        public uint Unk { get; set; }

        [BlubMember(1, typeof(StringWithPrefixSerializer))]
        public string PlayerName { get; set; }

        [BlubMember(2)]
        public byte Unk2 { get; set; }

        [BlubMember(3)]
        public ushort Level { get; set; }


        public LobbyPlayer()
        {
            
        }
        public LobbyPlayer(string playername, ushort level)
        {
            Unk = 1;
            Unk2 = 1;
            PlayerName = playername;
            Level = level;
        }
    }

    [BlubContract]
    public class ClanJoinSuccess : MiscAckMessage
    {
        [BlubMember(0, typeof(StringWithPrefixSerializer))]
        public string PlayerName { get; set; }

        public ClanJoinSuccess()
        {

        }
        public ClanJoinSuccess(string playername)
        {
            PlayerName = playername;
        }   
    }

    [BlubContract]
    public class ClanJoinDenial : MiscAckMessage
    {
        [BlubMember(0, typeof(StringWithPrefixSerializer))]
        public string PlayerName { get; set; }

        public ClanJoinDenial()
        {

        }
        public ClanJoinDenial(string playername)
        {
            PlayerName = playername;
        }
    }

    [BlubContract]
    public class ClanMemberJoinNotify : MiscAckMessage
    {
        [BlubMember(0, typeof(StringWithPrefixSerializer))]
        public string PlayerName { get; set; }

        public ClanMemberJoinNotify()
        {

        }
        public ClanMemberJoinNotify(string playername)
        {
            PlayerName = playername;
        }
    }

    [BlubContract]
    public class ClanRightChangeNotify : MiscAckMessage
    {
        [BlubMember(0, typeof(StringWithPrefixSerializer))]
        public string PlayerName { get; set; }

        [BlubMember(1)]
        public ClanRightChange Right { get; set; }

        public ClanRightChangeNotify()
        {

        }
        public ClanRightChangeNotify(string playername, ClanRightChange right)
        {
            PlayerName = playername;
            Right = right;
        }
    }

    [BlubContract]
    public class ClanBoardMessage : MiscAckMessage
    {
        [BlubMember(0, typeof(StringWithPrefixSerializer))]
        public string MasterName { get; set; }

        public ClanBoardMessage()
        {

        }
        public ClanBoardMessage(string mastername)
        {
            MasterName = mastername;
        }
    }

    [BlubContract]
    public class ClanMemberLeave : MiscAckMessage
    {
        [BlubMember(0, typeof(StringWithPrefixSerializer))]
        public string PlayerName { get; set; }

        [BlubMember(1)]
        public ClanMemberLeaveReason Reason { get; set; }

        public ClanMemberLeave()
        {

        }
        public ClanMemberLeave(string playername, ClanMemberLeaveReason reason)
        {
            PlayerName = playername;
            Reason = reason;
        }
    }

    [BlubContract]
    public class UnkClanMessage : MiscAckMessage
    {
        [BlubMember(0)]
        public byte Unk { get; set; }

        public UnkClanMessage()
        {
            Unk = 0;
        }    
    }

    [BlubContract]
    public class ClanCreateResultMessage : MiscAckMessage
    {
        [BlubMember(0)]
        public ClanCreateResult Result { get; set; }

        public ClanCreateResultMessage()
        {

        }
        public ClanCreateResultMessage(ClanCreateResult result)
        {
            Result = result;
        }
    }


}
