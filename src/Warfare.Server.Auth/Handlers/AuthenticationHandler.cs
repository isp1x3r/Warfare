﻿using System;
using log4net;
using Warfare.Core;
using Warfare.Server.Auth.Messages;

namespace Warfare.Server.Auth.Handlers
{
    [Handler(4)]
    internal class AuthenticationHandler
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(AuthenticationHandler));

        public AuthenticationHandler()
        {
             
        }
        public static bool Handle(Session session, AuthenticationReqMessage message)
        {
            _logger.Debug("Account number : " + message.AccountNumber);
            _logger.Debug("Username : " + message.Username);
            session.Send(new AuthenticationAckMessage(250, 3500));
            return true;
        }
    }
}
