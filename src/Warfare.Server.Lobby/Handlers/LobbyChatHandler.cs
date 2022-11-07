using System;
using System.IO;
using log4net;
using Warfare.Core;
using Warfare.Network;
using Warfare.Network.Message.Lobby;

namespace Warfare.Server.Lobby.Handlers
{
    [Handler(272)]
    internal class LobbyChatHandler
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(LobbyChatHandler));

        public LobbyChatHandler()
        {

        }

        public bool Handle(Session session, LobbyChatReq message)
        {
            _logger.Debug("Got chat message : " + message.Message);
            return true;
        }

    }
}
