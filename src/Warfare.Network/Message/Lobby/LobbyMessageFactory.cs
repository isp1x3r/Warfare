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
            RegisterClientMessage<QuickStartReqMessage>(LobbyOpCode.ClanScreenReq);
            RegisterClientMessage<ClanLookUpReqMessage>(LobbyOpCode.ClanLookUpReq);

            /*RegisterClientMessage<RoomCreateReqMessage>(LobbyOpCode.ShopInventoryReq);
             RegisterClientMessage<QuickStartReqMessage>(LobbyOpCode.QuickStartReq);
             RegisterClientMessage<QuickStartReqMessage>(LobbyOpCode.PlayerLookUpReq);
             RegisterClientMessage<QuickStartReqMessage>(LobbyOpCode.PlayerInfoReq);
             RegisterClientMessage<QuickStartReqMessage>(LobbyOpCode.ItemPurchaseReq);
             RegisterClientMessage<QuickStartReqMessage>(LobbyOpCode.PartnerScreenReq);
             RegisterClientMessage<QuickStartReqMessage>(LobbyOpCode.WeaponPurchaseReq);
             RegisterClientMessage<QuickStartReqMessage>(LobbyOpCode.GachaponScreenReq);*/

            // S2C
            RegisterServerMessage<LoginAckMessage>(LobbyOpCode.LoginAck);
            RegisterServerMessage<LobbyPlayer>(LobbyOpCode.LobbyPlayer);
            RegisterServerMessage<RoomInfoMessage>(LobbyOpCode.RoomInfo);
            RegisterServerMessage<ClanJoinDenial>(LobbyOpCode.ClanJoinDenial);
            RegisterServerMessage<ClanMemberJoinNotify>(LobbyOpCode.ClanMemberJoin);
            RegisterServerMessage<ClanRightChangeNotify>(LobbyOpCode.ClanRightChange);
            RegisterServerMessage<ClanBoardMessage>(LobbyOpCode.ClanBoard);
            RegisterServerMessage<ClanMemberLeave>(LobbyOpCode.ClanMemberLeave);
            RegisterServerMessage<UnkClanMessage>(LobbyOpCode.Unk3);
            RegisterServerMessage<ClanCreateResultMessage>(LobbyOpCode.ClanCreate);
            RegisterServerMessage<RoomCreateAckMessage>(LobbyOpCode.RoomCreateReq);


        }
    }
}
