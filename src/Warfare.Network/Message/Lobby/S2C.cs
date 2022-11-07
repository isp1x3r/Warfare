using Warfare.Core;
using BlubLib.Serialization;
using Warfare.Network.Serializers;

namespace Warfare.Network.Message.Lobby
{
    [BlubContract]
    public class LoginAckMessage : ILobbyMessage
    {
        [BlubMember(1)]
        public LoginResult LoginResult { get; set; }

        public LoginAckMessage()
        {

        }
        public LoginAckMessage(LoginResult loginResult)
        {
            LoginResult = loginResult;
        }
    }

    [BlubContract]
    public class MiscAckMessage : ILobbyMessage
    {


    }

    [BlubContract]
    public class RoomCreateAckMessage : ILobbyMessage
    {
        

    }
   
}
