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
    [Handler(76)]
    internal class ClanLeaveHandler
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(ClanLeaveHandler));

        public ClanLeaveHandler()
        {

        }
        public bool Handle(Session session, ClanLeaveReqMessage message)
        {
            session.SendAsync(new ClanBoardMessage("GameMasters"));
            return true;
        }
    }
}
