using log4net;
using Warfare.Core;
using Warfare.Network.Message.Auth;

namespace Warfare.Server.Auth.Handlers
{
    [Handler(39684)]
    internal class ChecksumHandler
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(ChecksumHandler));

        public ChecksumHandler()
        {

        }

        public bool Handle(Session session, ChecksumMessage message)
        {
            _logger.Info("Got player checksum");
            return true;
        }
    }
}
