using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using NetCoreServer;
using log4net;
using System.IO;

namespace Warfare.Core
{
    public class Session : TcpSession
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Session));
        internal ServerInstance _server { get; set; }

        public Session(ServerInstance server) : base(server) 
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
            byte[] payload = new byte[size];
            using(var br = new BinaryReader(new MemoryStream(buffer)))
            {
                payload = br.ReadBytes((int)size);
            }
            _server._messagehandler.HandleMessage(this, payload);
        }

        protected override void OnError(SocketError error)
        {
            _logger.Error($"Session with id {this.Id} caught an error with code {error}");
        }
        public long Send(object message)
        {
            return base.Send(_server._messagehandler.SerializeMessage(message));

        }
        public bool SendAsync(object message)
        {
            return base.SendAsync(_server._messagehandler.SerializeMessage(message));
        }
    }
}
