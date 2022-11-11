using Warfare.Core;
using BlubLib.Serialization;
using Warfare.Network.Serializers;

namespace Warfare.Network.Message.Lobby
{
    [BlubContract]
    public class LoginReqMessage : ILobbyMessage
    {
        [BlubMember(1)]
        public uint ClientVersion { get; set; }

        [BlubMember(2)]
        public uint ServerVersion { get; set; }

        [BlubMember(3, typeof(BinarySerializer), 125)]
        public byte[] Checksum { get; set; }

        [BlubMember(4)]
        public byte Unk1 { get; set; }

        [BlubMember(5)]
        public bool IsPCRoom { get; set; }

        [BlubMember(6)]
        public byte Unk3 { get; set; }
    }

    [BlubContract]
    public class ChatRoomCreateReq : ILobbyMessage
    {
        [BlubMember(2, typeof(StringWithPrefixSerializer))]
        public string RoomName { get; set; }
    }

    [BlubContract]
    public class LobbyChatReq : ILobbyMessage
    {
        [BlubMember(1)]
        public uint Unk { get; set; }
        [BlubMember(2, typeof(StringWithPrefixSerializer))]
        public string Message { get; set; }
    }

    [BlubContract]
    public class RoomCreateReqMessage : ILobbyMessage
    {
        [BlubMember(1)]
        public uint Unk1 { get; set; }

        [BlubMember(2)]
        public byte Unk2 { get; set; }

        [BlubMember(3, typeof(StringWithPrefixSerializer))]
        public string RoomName { get; set; }

        [BlubMember(4)]
        public ushort MapIndex { get; set; }

        [BlubMember(5)]
        public byte PlayerLimit { get; set; }

        [BlubMember(6, typeof(StringWithPrefixSerializer))]
        public string Password { get; set; }

        [BlubMember(7)]
        public byte Unk3 { get; set; }

        [BlubMember(8)]
        public byte Unk4 { get; set; }

        [BlubMember(9)]
        public byte Unk5 { get; set; }
    }

    [BlubContract]
    public class QuickStartReqMessage : ILobbyMessage
    {
        [BlubMember(1)]
        public uint Unk1 { get; set; }

        [BlubMember(2)]
        public ushort Unk2 { get; set; }

        [BlubMember(3)]
        public byte GameMode { get; set; }

        [BlubMember(4)]
        public byte Unk3 { get; set; }

        [BlubMember(5)]
        public uint Unk4 { get; set; }
    }

    [BlubContract]
    public class ClanBoardReqMessage : ILobbyMessage
    {

    }

    [BlubContract]
    public class ClanLeaveReqMessage : ILobbyMessage
    {

    }

    [BlubContract]
    public class ClanLookUpReqMessage : ILobbyMessage
    {
        [BlubMember(0, typeof(StringWithPrefixSerializer))]
        public string ClanName { get; set; }
    }
}
