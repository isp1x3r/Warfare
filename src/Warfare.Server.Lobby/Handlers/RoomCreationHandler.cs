﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Warfare.Core;
using Warfare.Network.Message.Lobby;

namespace Warfare.Server.Lobby.Handlers
{
    [Handler(37)]
    internal class RoomCreationHandler
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(RoomCreationHandler));

        public RoomCreationHandler()
        {

        }

        public bool Handle(Session session, RoomCreateReqMessage message)
        {
            session.SendAsync(new RoomInfoMessage());
            return true;
        }
    }
}
