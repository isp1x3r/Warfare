using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Warfare.Core;
using Warfare.Network;
using Warfare.Network.Message.Lobby;

namespace Warfare.Server.Lobby.Handlers
{
    [Handler(2)]
    internal class LoginHandler
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(LoginHandler));

        public LoginHandler()
        {

        }
        public bool Handle(Session session, LoginReqMessage message)
        {
            session.SendAsync(new LoginAckMessage(LoginResult.Success));
            return true;
        }
    }
}
