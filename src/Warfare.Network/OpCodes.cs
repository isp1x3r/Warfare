namespace Warfare.Network
{
    public enum AuthOpCode : ushort
    {
            // C2S
            
        AuthenticationReq = 4,
        CharacterListReq = 260,
        CharacterInfoReq = 516,
        CharacterCreateReq = 772,
        CharacterDeleteReq = 1028,
        ConnectReq = 1284,
        ServerListReq = 1540,
        ChannelListReq = 1796,
        ReLoginReq = 2564,
        Checksum = 39684,

            // S2C

        AuthenticationAck = 4,
        CharacterListAck = 260,
        CharacterInfoAck = 516,
        CharacterCreateAck = 772,
        CharacterDeleteAck = 1028,
        ConnectAck = 1284,
        ServerListAck = 1540,
        ChannelListAck = 1796,
        ReLoginAck = 2564,
        PlayerCash = 2820,
        UserBan = 3588,
        ErrorDetected = 4612,
        LoadBanner = 39172,
        Notice = 65284,
    }
    public enum LobbyOpCode : ushort
    {
            // C2S
        ChatRoomCreateReq = 1,
        LoginReq = 2,
        LobbyChatReq = 16,
        CreateRoomReq = 37,
        ShopInventoryReq = 39,
        QuickStartReq = 41,
        PlayerReadyReq = 53,
        PlayerLookUpReq = 54,
        PlayerInfoReq = 57,
        GameStartReq = 58,
        ClanLookUpReq = 64,
        ItemPurchaseReq = 68,
        ClanScreenReq = 74,
        ClanLeaveReq = 76,
        PartnerScreenReq = 162,
        WeaponPurchaseReq = 210,
        GachaponScreenReq = 228,

            // S2C

        LoginAck = 2,
        LobbyPlayer = 3,
        CreateRoomAck = 37,
        GameRoomInfo = 48,
        SetupRoomInfo = 49,
        PlayerReadyAck = 53,
        GameStartAck = 58,
        ClanJoinSuccess = 70,
        ClanJoinDenial = 71,
        ClanMemberJoin = 72,
        ClanRightChange = 73,
        ClanBoard = 74,
        Unk1 = 75,
        Unk2 = 76,
        ClanMemberLeave = 77,
        Unk3 = 78,
        ClanCreate = 79
    }
}
