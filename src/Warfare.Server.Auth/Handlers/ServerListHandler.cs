using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warfare.Core;
using Warfare.Server.Auth.Messages;

namespace Warfare.Server.Auth.Handlers
{
    [Handler(1540)]
    internal class ServerListHandler
    {
        public ServerListHandler()
        {

        }
        public static bool Handle(Session session, ServerListReqMessage message)
        {
            return true;
        }
    }
}
