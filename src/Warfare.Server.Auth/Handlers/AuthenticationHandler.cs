using System;
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
            uint Accountnum = message.AccountNumber;
            _logger.Debug("Got log in with username : " + message.Username);
            session.SendAsync(new AuthenticationAckMessage()
            {
                CharacterSlots = 2002279,
                IsPCRoom = 1,
                AccountNumber = Accountnum,
                Country = "US",
                TimeStamp = "12345678"

            });
            ;
            return true;
        }
    }
}
