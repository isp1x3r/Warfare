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
            RegisterClientMessage<ChatRoomCreateReq>(LobbyOpCode.ChatRoomCreateReq);
            RegisterClientMessage<LoginReqMessage>(LobbyOpCode.LoginReq);
            RegisterClientMessage<LobbyChatReq>(LobbyOpCode.LobbyChatReq);
            RegisterClientMessage<RoomCreateReqMessage>(LobbyOpCode.RoomCreateReq);
           /*RegisterClientMessage<RoomCreateReqMessage>(LobbyOpCode.ShopInventoryReq);
            RegisterClientMessage<QuickStartReqMessage>(LobbyOpCode.QuickStartReq);
            RegisterClientMessage<QuickStartReqMessage>(LobbyOpCode.PlayerLookUpReq);
            RegisterClientMessage<QuickStartReqMessage>(LobbyOpCode.PlayerInfoReq);
            RegisterClientMessage<QuickStartReqMessage>(LobbyOpCode.ItemPurchaseReq);
            RegisterClientMessage<QuickStartReqMessage>(LobbyOpCode.ClanScreenReq);
            RegisterClientMessage<QuickStartReqMessage>(LobbyOpCode.PartnerScreenReq);
            RegisterClientMessage<QuickStartReqMessage>(LobbyOpCode.WeaponPurchaseReq);
            RegisterClientMessage<QuickStartReqMessage>(LobbyOpCode.GachaponScreenReq);*/

            // S2C
            RegisterServerMessage<LoginAckMessage>(LobbyOpCode.LoginAck);
            RegisterServerMessage<LobbyPlayer>(LobbyOpCode.LobbyPlayer);


        }
    }
}
