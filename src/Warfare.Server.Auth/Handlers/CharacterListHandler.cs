using log4net;
using Warfare.Core;
using Warfare.Network.Message.Auth;

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
                Nickname1 = "[GM]-Monster",
                Nickname2 = "[GM]-MonsterA",
                Nickname3 = "[GM]-MonsterB",
                Nickname4 = "[GM]-MonsterC",
                Flag = 10,
            });
            return true;
        }
    }
}
