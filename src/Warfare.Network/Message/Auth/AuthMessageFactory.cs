using Warfare.Core;

namespace Warfare.Network.Message.Auth
{
    public interface IAuthMessage
    {

    }
    public class AuthMessageFactory : MessageFactory<AuthOpCode, IAuthMessage>
    {
        public AuthMessageFactory()
        {
            // C2S
            RegisterClientMessage<AuthenticationReqMessage>(AuthOpCode.AuthenticationReq);
            RegisterClientMessage<CharacterListReqMessage>(AuthOpCode.CharacterListReq);
            RegisterClientMessage<CharacterInfoReqMessage>(AuthOpCode.CharacterInfoReq);
            RegisterClientMessage<CharacterCreateReqMessage>(AuthOpCode.CharacterCreateReq);
            RegisterClientMessage<CharacterDeleteReqMessage>(AuthOpCode.CharacterDeleteReq);
            RegisterClientMessage<ConnectReqMessage>(AuthOpCode.ConnectReq);
            RegisterClientMessage<ServerListReqMessage>(AuthOpCode.ServerListReq);
            RegisterClientMessage<ChannelListReqMessage>(AuthOpCode.ChannelListReq);
            RegisterClientMessage<ChecksumMessage>(AuthOpCode.Checksum);

            // S2C
            RegisterServerMessage<AuthenticationAckMessage>(AuthOpCode.AuthenticationAck);
            RegisterServerMessage<CharacterListAckMessage>(AuthOpCode.CharacterListAck);
            RegisterServerMessage<CharacterInfoAckMessage>(AuthOpCode.CharacterInfoAck);
            RegisterServerMessage<CharacterCreateAckMessage>(AuthOpCode.CharacterCreateAck);
            RegisterServerMessage<CharacterDeleteAckMessage>(AuthOpCode.CharacterDeleteAck);
            RegisterServerMessage<ConnectAckMessage>(AuthOpCode.ConnectAck);
            RegisterServerMessage<ServerListAckMessage>(AuthOpCode.ServerListAck);
            RegisterServerMessage<ChannelListAckMessage>(AuthOpCode.ChannelListAck);
            RegisterServerMessage<PlayerCashMessage>(AuthOpCode.PlayerCash);
            RegisterServerMessage<UserBanMessage>(AuthOpCode.UserBan);
            RegisterServerMessage<ErrorDetectedMessage>(AuthOpCode.ErrorDetected);
            RegisterServerMessage<LoadBannerMessage>(AuthOpCode.LoadBanner);
            RegisterServerMessage<NoticeMessage>(AuthOpCode.Notice);
        }
        
    }
}
