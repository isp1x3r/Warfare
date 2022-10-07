using System.Threading.Tasks;
using log4net;
using Mercenary.Core;
using Mercenary.Network.Message.Auth;

namespace Mercenary.Server.Auth.Handlers
{
    [Handler(0)]
    internal class AuthenticationHandler
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(AuthenticationHandler));

        public AuthenticationHandler()
        {
             
        }
        public async Task<bool> Handle(Session session, AuthenticationReqMessage message)
        {

            return true;
        }
    }
}
