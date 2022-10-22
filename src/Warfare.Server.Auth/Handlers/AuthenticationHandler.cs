using System;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
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
            _logger.Debug("Player account number : " + message.AccountNumber);
            session.SendAsync(new AuthenticationAckMessage()
            {
                CharacterSlots = 3,
                IsPCRoom = 1,
                AccountNumber = 9849898,
                Country = "USA",
                IsBanned = true,
                TimeStamp = "12345678",
            });
            _logger.Debug("Got log in with username : " + message.Username);
            return true;
        }
    }
}
