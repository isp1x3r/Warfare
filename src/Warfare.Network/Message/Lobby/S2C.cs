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
    public class RoomCreateAckMessage : ILobbyMessage
    {
        

    }

    [BlubContract]
    public class MiscAckMessage : ILobbyMessage
    {
        
    }
    [BlubContract]
    public class LobbyPlayer : MiscAckMessage
    {
        [BlubMember(0)]
        public uint Unk { get; set; }

        [BlubMember(1, typeof(StringWithPrefixSerializer))]
        public string PlayerName { get; set; }

        [BlubMember(2)]
        public byte Unk2 { get; set; }

        [BlubMember(3)]
        public ushort Level { get; set; }


        public LobbyPlayer()
        {
            
        }
        public LobbyPlayer(string playername, ushort level)
        {
            Unk = 1;
            Unk2 = 1;
            PlayerName = playername;
            Level = level;
        }
    }
   
}
