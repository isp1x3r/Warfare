﻿using log4net;
using Warfare.Core;
using Warfare.Server.Auth.Messages;

namespace Warfare.Server.Auth.Handlers
{
    [Handler(39684)]
    internal class ChecksumHandler
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(AuthenticationHandler));

        public ChecksumHandler()
        {

        }

        public static bool Handle(Session session, ChecksumMessage message)
        {
            _logger.Info("Got player checksum : " + message.Checksum);
            return true;
        }
    }
}
