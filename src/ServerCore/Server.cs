using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
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
        internal MessageFactory _messagefactory { get; set; }

        public Server(IPAddress address, short port, ServerType type) : base(address, port) 
        { 
            _serveraddr = address;
            _port = port;
            _servertype = type;
            _sessionMgr = new SessionManager();
            _messagefactory = new MessageFactory(this);
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