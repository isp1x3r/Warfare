using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warfare.Core;
using Warfare.Network.Message.Auth;
using Warfare.Network.Data.Auth;

namespace Warfare.Server.Auth.Handlers
{
    [Handler(1284)]
    internal class ServiceConnectHandler
    {
        public ServiceConnectHandler()
        {

        }
        public bool Handle(Session session, ConnectReqMessage message)
        {
            session.SendAsync(new ConnectAckMessage());
            return true;
        }
    }
}
