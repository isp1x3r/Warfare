using System;
using System.Net;
using System.Net.Sockets;
using log4net;
using NetCoreServer;

namespace Mercenaries.Core
{
    public class ServerInstance : TcpServer
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(ServerInstance));
        public string _serveraddr { get; set; }
        public short _port { get; set; }
        public ServerType _servertype { get; set; }
        internal SessionManager _sessionMgr { get; set; }
        internal MessageHandler _messagehandler { get; set; }

        public ServerInstance(string address, short port, ServerType type, MessageFactory messagefactory) : base(address, port) 
        { 
            _serveraddr = address;
            _port = port;
            _servertype = type;
            _sessionMgr = new SessionManager();
            _messagehandler = new MessageHandler(messagefactory);
        }

        protected override TcpSession CreateSession() 
        {
            Session sessiontoadd = new Session(this);
            _sessionMgr.AddSession(sessiontoadd);
            return sessiontoadd; 
        
        }

        protected override void OnError(SocketError error)
        {
            _logger.Error($"Server caught an error with code {error}");
        }
    }
}
