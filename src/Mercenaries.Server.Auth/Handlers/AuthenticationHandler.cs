using System;
using log4net;
using Mercenaries.Core;
using Mercenaries.Server.Auth.Messages;

namespace Mercenaries.Server.Auth.Handlers
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
            return true;
        }
    }
}
