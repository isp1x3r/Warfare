using System;
using System.Threading.Tasks;
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
        public async Task<bool> Handle(Session session, AuthenticationReqMessage message)
        {
            Console.WriteLine(message.AccountNumber);
            Console.WriteLine(message.Username);
            return true;
        }
    }
}
