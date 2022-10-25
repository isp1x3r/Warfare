using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlubLib.Serialization;
using System.Threading.Tasks;

namespace Warfare.Network.Data.Auth
{
    [BlubContract]
    public class ChannelDto
    {
        [BlubMember(1)]
        public ushort PlayerCount { get; set; }

        [BlubMember(2)]
        public uint PlayerLimit { get; set; }

        [BlubMember(3)]
        public ushort Pad { get; set; }

        [BlubMember(4)]
        public byte Unk1 { get; set; }

        [BlubMember(5)]
        public byte Unk2 { get; set; }

        public ChannelDto()
        {

        }
    }
}
