using System;
using System.Collections.Generic;
using log4net;
using Warfare.Core;
using Warfare.Network.Message.Lobby;

namespace Warfare.Server.Lobby.Handlers
{
    [Handler(53)]
    internal class PlayerReadyHandler
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(PlayerReadyHandler));

        public PlayerReadyHandler()
        {

        }

        public bool Handle(Session session, PlayerReadyReqMessage message)
        {
            session.SendAsync(new PlayerReadyAckMessage());
            return true;
        }
    }
}
