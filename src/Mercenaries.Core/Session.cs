using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using NetCoreServer;
using log4net;


namespace Mercenaries.Core
{
    public class Session : TcpSession
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Session));
        internal Server _server { get; set; }

        public Session(Server server) : base(server) 
        {
            _server = server;
        }

        protected override void OnConnected()
        {
            
        }

        protected override void OnDisconnected()
        {
            _logger.Info($"Session with Id {Id} disconnected!");
            _server._sessionMgr.RemoveSession(this);
            this.Dispose();
        }

        protected override void OnReceived(byte[] buffer, long offset, long size)
        {
            _server._messagehandler.HandleMessage(this, buffer);
        }

        protected override void OnError(SocketError error)
        {
            _logger.Error($"Session with id {this.Id} caught an error with code {error}");
        }
        public long Send(Type message)
        {
            return base.Send(_server._messagehandler.SerializeMessage(message));

        }
        public bool SendAsync(Type message)
        {
            return base.SendAsync(_server._messagehandler.SerializeMessage(message));
        }
    }
}
