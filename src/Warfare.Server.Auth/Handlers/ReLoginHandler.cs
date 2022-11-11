using System;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using log4net;
using Warfare.Core;
using Warfare.Network;
using Warfare.Network.Message.Auth;

namespace Warfare.Server.Auth.Handlers
{
    [Handler(2564)]
    internal class ReLoginHandler
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(ReLoginHandler));

        public ReLoginHandler()
        {

        }
        public bool Handle(Session session, ReLoginReqMessage message)
        {
            session.SendAsync(new ReLoginAckMessage(ReLoginResult.Success));
            return true;
        }
    }
}
