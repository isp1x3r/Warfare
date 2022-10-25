using Warfare.Core;
using BlubLib.Serialization;
using Warfare.Network.Serializers;

namespace Warfare.Network.Message.Lobby
{
    [BlubContract]
    public class LoginAckMessage : ILobbyMessage
    {
        [BlubMember(1)]
        public ushort Unk { get; set; }

        [BlubMember(2)]
        public LoginResult LoginResult { get; set; }

        public LoginAckMessage(LoginResult loginResult)
        {
            LoginResult = loginResult;
        }
    }
}
