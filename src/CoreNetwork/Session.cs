using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using NetCoreServer;
using log4net;


namespace CoreNetwork
{
    public class Session : TcpSession
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Session));
        public Session(Server server) : base(server) { }

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
            // TODO
            TcpSession _r = new TcpSession(this.Server);
            _r.SendAsync(buffer);
        }

        protected override void OnError(SocketError error)
        {
            _logger.Error($"Chat TCP session caught an error with code {error}");
        }

        public override long Send(byte[] buffer)
        {
            return base.Send(buffer);
        }
        public override bool SendAsync(byte[] buffer)
        {
            return base.SendAsync(buffer);
        }
    }
}
