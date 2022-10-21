using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warfare.Core;
using Warfare.Server.Auth.Messages;

namespace Warfare.Server.Auth.Handlers
{
    [Handler(1284)]
    internal class ServiceConnectHandler
    {
        public ServiceConnectHandler()
        {

        }
        public bool Handle(Session session, ServiceConnectReqMessage message)
        {
            return true;
        }
    }
}
