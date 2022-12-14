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
        RoomCreateReq = 37,
        ShopInventoryReq = 39,
        QuickStartReq = 41,
        PlayerLookUpReq = 54,
        PlayerInfoReq = 57,
        ItemPurchaseReq = 68,
        ClanScreenReq = 74,
        PartnerScreenReq = 162,
        WeaponPurchaseReq = 210,
        GachaponScreenReq = 228,

            // S2C

        LoginAck = 2,

    }
}
