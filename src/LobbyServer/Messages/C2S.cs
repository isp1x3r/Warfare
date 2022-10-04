using ServerCore;
using ProtoBuf;

namespace LobbyServer.Messages
{
    [ClientMessage(2)]
    [ProtoContract]
    internal class LoginReqMessage
    {
        [ProtoMember(1)]
        internal uint ClientVersion { get; set; }

        [ProtoMember(2)]
        internal uint ServerVersion { get; set; }

        [ProtoMember(3, IsPacked = true)]
        internal byte[] Unk1 = new byte[125];

        [ProtoMember(4)]
        internal byte Unk2 { get; set; } // GameVersion??

        [ProtoMember(5)]
        internal byte Unk3 { get; set; }

        [ProtoMember(6)]
        internal byte Unk4 { get; set; }

        [ProtoMember(7)]
        internal byte Unk5 { get; set; }
    }
