using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warfare.Core;
using Warfare.Server.Auth.Messages;

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
            return true;
        }
    }
}
