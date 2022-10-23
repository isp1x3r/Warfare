using Warfare.Core;
using Warfare.Server.Auth.Messages;

namespace Warfare.Server.Auth.Handlers
{
    [Handler(516)]
    internal class CharacterInfoHandler
    {
        public CharacterInfoHandler()
        {

        }

        public bool Handle(Session session, CharacterInfoReqMessage message)
        {
            session.SendAsync(new CharacterInfoAckMessage()
            {
                CharacterID = 1,
                Nickname = "[GM]-Monster",
                Level = 68,
                Hero = CharacterHero.Travis,
                Experience = 100000000,
                BountyPoints = 90000,
                Kills = 50000,
                Deaths = 46000,
                Wins = 6000,
                Losses = 97,
                ClanName = "GameMasters",
                ClanMark = 30,
                SkinColor = 6,
                ItemCount = 0

            });
            session.SendAsync(new PlayerCashMessage(690490));
            return true;
        }
    }
}
