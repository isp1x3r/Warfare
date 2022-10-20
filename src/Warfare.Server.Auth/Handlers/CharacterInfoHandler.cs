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

        public static bool Handle(Session session, CharacterInfoReqMessage message)
        {
            session.SendAsync(new CharacterInfoAckMessage()
            {
                Nickname = "[GM]-Monster",
                Level = 69,
                Hero = CharacterHero.Vanessa,
                Experience = 40000,
                BountyPoints = 90000,
                Kills = 50000,
                Deaths = 46000,
                Wins = 6000,
                Losses = 97,
                ClanName = "GameMasters",
                ClanMark = 0,
                SkinColor = 6,
                ItemCount = 0

            });
            session.SendAsync(new PlayerCashMessage(690490));
            return true;
        }
    }
}
