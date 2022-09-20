using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using log4net;
using NetCoreServer;
using NetworkCore;

namespace CoreNetwork
{
    public class Server : TcpServer
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Server));
        public IPAddress _serveraddr { get; set; }
        public short _port { get; set; }
        public ServerType _servertype { get; set; }
        private SessionManager _sessionMgr { get; set; }
        public Server(IPAddress address, int port, ServerType type) : base(address, port) 
        { 
            _serveraddr = address;
            _port = (short)port;
            _servertype = type;
            _sessionMgr = new SessionManager();
        }

        protected override TcpSession CreateSession() 
        {
            var sessiontoadd = new TcpSession(this);
            _sessionMgr.AddSession(sessiontoadd);
            return new TcpSession(this); 
        
        }

        protected override void OnError(SocketError error)
        {
            _logger.Error($"Server caught an error with code {error}");
        }
    }
}