﻿using System;
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
    [Handler(74)]
    internal class ClanScreenHandler
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(ClanScreenHandler));

        public ClanScreenHandler()
        {

        }
        public bool Handle(Session session, ClanBoardReqMessage message)
        {
            session.SendAsync(new ClanBoardMessage("GameMasters"));
            return true;
        }
    }
}
