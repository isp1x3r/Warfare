using Warfare.Core;
using Warfare.Server.Auth.Messages;

namespace Warfare.Server.Auth.Handlers
{
    [Handler(260)]
    internal class CharacterListHandler
    {
        public CharacterListHandler()
        {

        }
        public bool Handle(Session session, CharacterListReqMessage message)
        {
            session.SendAsync(new CharacterListAckMessage()
            {
                CharacterCount = 3,
                Nickname = "[GM]-Monster"
            });
            return true;
        }
    }
}
