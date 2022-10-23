
using log4net;
using Warfare.Core;
using Warfare.Server.Auth.Messages;
using Warfare.Server.Auth.Data;
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
                        Id = 75,
                        ServerPort = 30003,
                        ServerIP = (uint)(addr.Address),
                        
                    }
                }
            });
            ;
            return true;
        }
    }
}
