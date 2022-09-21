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
        private Server _server { get; set; }
        public Session(Server server) : base(server) 
        {
            _server = server;
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
            // Get Packet ID based on server type : 
            short packetid;
            switch(_server._servertype)
            {
                case ServerType.AuthServer:
                    packetid = Extensions.ReadAuthServerOpCode(buffer);
                    break;
                case ServerType.LobbyServer:
                    packetid = Extensions.ReadGameServerOpCode(buffer);
                    break;
                case ServerType.MultiplayServer:
                    // TO DO
                    break;
            }
            TcpSession _r = new TcpSession(this.Server);
            _r.SendAsync(buffer);
        }

        protected override void OnError(SocketError error)
        {
            _logger.Error($"Chat TCP session caught an error with code {error}");
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
