using Warfare.Network.Serializers;
using BlubLib.Serialization;


namespace Warfare.Network.Data.Auth
{
    [BlubContract]
    public class ServerInfoDto
    {
        [BlubMember(1)]
        public byte Unk1 { get; set; } // Sorting ID?

        [BlubMember(2)]
        public ServerType ServerType { get; set; }

        [BlubMember(3)]
        public ushort PlayerLimit { get; set; }

        [BlubMember(4)]
        public ushort PlayerCount { get; set; }

        [BlubMember(5)]
        public ushort ServerPort { get; set; }

        [BlubMember(6)]
        public uint ServerIP { get; set; }

        [BlubMember(7, typeof(BinarySerializer), 241)]
        public byte[] AllowedAreas { get; set; }

        [BlubMember(8, typeof(BinarySerializer), 241)]
        public byte[] BlockedAreas { get; set; }

        [BlubMember(9, typeof(StringSerializer), 33)]
        public string ServerName { get; set; }

        public ServerInfoDto()
        {
            AllowedAreas = Array.Empty<byte>();
            BlockedAreas = Array.Empty<byte>();
        }
    }
}
