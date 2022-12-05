using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Warfare.Core;
using Warfare.Network;
using Warfare.Network.Message.Lobby;

namespace Warfare.Server.Lobby.Handlers
{
    [Handler(64)]
    internal class ClanLookUpHandler
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(ClanScreenHandler));

        public ClanLookUpHandler()
        {

        }
        public bool Handle(Session session, ClanLookUpReqMessage message)
        {
            _logger.Debug("Got clan look up request for clan name : " + message.ClanName);
            return true;
        }
    }
}
