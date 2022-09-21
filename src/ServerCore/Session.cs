using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using NetCoreServer;
using log4net;


namespace ServerCore
{
    public class Session : TcpSession
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Session));
        internal Server _server { get; set; }
        internal MessageHandler _messagehandler { get; set; }

        public Session(Server server) : base(server) 
        {
            _server = server;
            _messagehandler = new MessageHandler(this);
        }

        protected override void OnConnected()
        {
            _logger.Info($"Session created {Id} connected!");
        }

        protected override void OnDisconnected()
        {
            _logger.Info($"Session with Id {Id} disconnected!");
        }

        protected override void OnReceived(byte[] buffer, long offset, long size)
        {
            _messagehandler.HandleMessage(buffer);
        }

        protected override void OnError(SocketError error)
        {
            _logger.Error($"Session with id {this.Id} caught an error with code {error}");
        }
        public override long Send(IMessage message)
        {
            return base.Send(buffer);
        }
        public override bool SendAsync(byte[] buffer)
        {
            return base.SendAsync(buffer);
        }
    }
}
