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
        public bool Handle(Session session, AuthenticationReqMessage message)
        {
            uint Accountnum = message.AccountNumber;
            session.SendAsync(new AuthenticationAckMessage(5000, 69000));
            _logger.Debug("Got log in with username : " + message.Username);
            return true;
        }
    }
}
