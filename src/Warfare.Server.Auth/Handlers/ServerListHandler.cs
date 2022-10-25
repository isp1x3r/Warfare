
using log4net;
using Warfare.Core;
using Warfare.Network;
using Warfare.Network.Message.Auth;
using Warfare.Network.Data.Auth;
using System.Net;

namespace Warfare.Server.Auth.Handlers
{
    [Handler(1540)]
    internal class ServerListHandler
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(ServerListHandler));

        public ServerListHandler()
        {

        }

        public bool Handle(Session session, ServerListReqMessage message)
        {
            IPAddress addr;
            IPAddress.TryParse("127.0.0.1", out addr);
            session.SendAsync(new ServerListAckMessage()
            {
                ServerEntries = 1,
                Servers = new ServerInfoDto[]
                {
                    new ServerInfoDto
                    {
                        ServerType = ServerType.OpenServer,
                        ServerPort = 30003,
                        ServerIP = (uint)(addr.Address),
                        PlayerLimit = 10,
                        PlayerCount = 5,
                        ServerName = "Warfare Server"

                    }
    }
            });
            ;
            return true;
        }
    }
}
