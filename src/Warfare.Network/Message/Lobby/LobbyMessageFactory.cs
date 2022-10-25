using Warfare.Core;

namespace Warfare.Network.Message.Lobby
{
    public interface ILobbyMessage
    {

    }
    public class LobbyMessageFactory : MessageFactory<LobbyOpCode, ILobbyMessage>
    {
       public LobbyMessageFactory()
       {
            // C2S
            RegisterClientMessage<LoginReqMessage>(LobbyOpCode.LoginReq);

       }
    }
}
