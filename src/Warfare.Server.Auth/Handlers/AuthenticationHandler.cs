using System;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using log4net;
using Warfare.Core;
using Warfare.Network.Message.Auth;

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
            _logger.Debug("Got log in with username : " + message.Username);
            session.SendAsync(new AuthenticationAckMessage()
            {
                CharacterSlots = 3,
                IsPCRoom = 0,
                AccountNumber = message.AccountNumber,
                Country = "US",
                IsBanned = false,
                TimeStamp = "12345678",
            });
            return true;
        }
    }
}
