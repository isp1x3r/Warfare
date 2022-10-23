using log4net;
using Warfare.Core;
using Warfare.Server.Auth.Messages;

namespace Warfare.Server.Auth.Handlers
{
    [Handler(260)]
    internal class CharacterListHandler
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(CharacterListHandler));

        public CharacterListHandler()
        {

        }
        public bool Handle(Session session, CharacterListReqMessage message)
        {
            session.SendAsync(new CharacterListAckMessage()
            {
                CharacterCount = 3,
                CharacterNames = "[GM]-Monster",
                Flag = 10,
            });
            return true;
        }
    }
}
