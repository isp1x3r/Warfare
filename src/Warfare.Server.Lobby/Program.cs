﻿using Warfare.Core;
using log4net;
using log4net.Config;

namespace Warfare.Server.Lobby
{
    class Program
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            BasicConfigurator.Configure();
            _logger.Info("Initializing Server...");
            ServerInstance server = new ServerInstance("127.0.0.1", 30003, new LobbyMessageHandler());
            server.Start();
            _logger.Info("Successfully started the server");
            for (; ; )
            { }
            _logger.Debug("Server stopping...");
        }
    }
}
