using log4net;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using NetCoreServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCore
{
    internal class MessageHandler
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(MessageHandler));
        public MessageHandler()
        {
        }
        public void HandleMessage(Session session, byte[] message)
        {
           

        }
        private short GetPacketID(byte[] message)
        {
            // Get Packet ID based on server type : 
            short id;
            switch (_session._server._servertype)
            {
                case ServerType.AuthServer:
                    Extensions.ReadAuthServerOpCode(message, out id);
                    break;
                case ServerType.LobbyServer:
                    Extensions.ReadGameServerOpCode(message, out id);
                    break;
                case ServerType.MultiplayServer:
                    // TO DO
                    break;
            }
            return id;
        }
    }
}
