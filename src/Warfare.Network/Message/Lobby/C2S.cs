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
        public byte Unk2 { get; set; }

        [BlubMember(6)]
        public byte Unk3 { get; set; }
    }
}
