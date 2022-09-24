using System;
using System.Net;
using System.Net.Sockets;
using log4net;
using NetCoreServer;

namespace ServerCore
{
    public class Server : TcpServer
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Server));
        private SessionManager _sessionMgr { get; set; }
        public IPAddress _serveraddr { get; set; }
        public short _port { get; set; }
        public ServerType _servertype { get; set; }
        public MessageFactory _messagefactory { get; set; }
        internal MessageHandler _messagehandler { get; set; }

        public Server(IPAddress address, short port, ServerType type, MessageFactory messagefactory) : base(address, port) 
        { 
            _serveraddr = address;
            _port = port;
            _servertype = type;
            _messagefactory = messagefactory;
            _sessionMgr = new SessionManager();
            _messagehandler = new MessageHandler();
        }

        protected override TcpSession CreateSession() 
        {
            TcpSession sessiontoadd = new TcpSession(this);
            _sessionMgr.AddSession(sessiontoadd);
            return sessiontoadd; 
        
        }

        protected override void OnError(SocketError error)
        {
            _logger.Error($"Server caught an error with code {error}");
        }
    }
}