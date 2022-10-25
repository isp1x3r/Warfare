using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warfare.Core;
using Warfare.Network.Data.Auth;
using Warfare.Network.Message.Auth;

namespace Warfare.Server.Auth.Handlers
{
    [Handler(1796)]
    internal class ChannelListHandler
    {
        public ChannelListHandler()
        {

        }
        public bool Handle(Session session, ChannelListReqMessage message)
        {
            session.SendAsync(new ChannelListAckMessage()
            {
                Channels = new ChannelDto[]
                {
                    new ChannelDto
                    {
                        Unk1 = 1,
                        Unk2 = 3,
                        PlayerCount = 70,
                        PlayerLimit = 450
                    }
                }
            });
            return true;
        }
    }
}
