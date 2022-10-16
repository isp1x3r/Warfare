using System;
using Mercenaries.Core;
using log4net;
using System.Net;
using log4net.Config;
using System.IO;

namespace Mercenaries.Server.Auth
{
    class Program
    {
       private static readonly ILog _logger = LogManager.GetLogger(typeof(Program));

       static void Main(string[] args)
       {
            BasicConfigurator.Configure();
            _logger.Info("Initializing Server...");
            ServerInstance server = new ServerInstance("127.0.0.1", 14000, ServerType.AuthServer, new MessageFactory());
            server.Start();
            _logger.Info("Successfully started the server");
            for (; ; )
            { }
            _logger.Debug("Server stopping...");
        }
    }
}
