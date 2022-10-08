

namespace Mercenaries.Core
{
    #region Authentication
    public enum RetrieveCharacterInfoError : ushort
    {
        Success = 0,
        Failed = 65405
    }
    public enum CharacterInfoError : ushort
    {
        Success = 0,
        CharacterInformationDoesNotExist = 65404,
        CharacterDoesNotExist = 65405
    }
    public enum CharacterCreationError : ushort
    {
        Success = 0,
        ERR_CHARINFO = 65403,
        NameAlreadyExists = 65404,
        NotEnoughSlots = 65405
    }
    #endregion

    #region Lobby
    public enum CharacterScreenResult : ushort
    {
        Success = 0,
        BannedFromService = 65401,
        ItemNotAvailableForSale = 65423,
        ExistingNameChangeWilLBeDeleted = 64537,
        InvalidCashItem = 65283,
        ItemAlreadyInUse = 65422
    }
    public enum CharacterHero : byte
    {
        Travis = 0,
        Vanessa = 1,
        Adam = 2,
        Cathy = 3
    }
    public enum ClanDisbandResult : byte
    {
        Success = 0,
        NotaMember = 1,
        MemberExists = 2,
        ClanDoesNotExist = 3,
        CannotDisband = 4,
    }
    public enum ChatRoomInviteResult : byte
    {
        NoUsers = 1,
        ChatRoomClosed = 2,
        AlreadyInChatRoom = 3
    }
    public enum ClanRightChange : byte
    {
        Master = 1,
        AssistantMaster = 2,
        Elite = 3,
        Normal = 4
}
    public enum ClanCreateResult : byte
    {
        Success = 0,
        Error = 1,
        AlreadyInClan = 2, // or requested to join one
        ClanNameInUse = 3,
        InvalidClanName = 4,
        ClanNameLimit = 5,
        ClanNameSuspended = 6,
        ClanWake = 7, // some stupid shit they have where you can't create a clan for 30 days after disbanding one
        RankRequired = 8,
        InsufficientFunds = 9,
        NotFound = 10,
        UserNotFound = 11,
    }
    public enum RoomEnterResult : byte
    {
        Success = 0,
        Unk1 = 242, // "err: -14"
        Unk2 = 243, // "err: -13"
        Unk3 = 244, // "err: -12"
        FullCapacity = 245,
        IncorrectPassword = 246,
        Kicked = 250,
        NoPermission = 251,
        RoomNotExisting = 253,
    }
    public enum RoomEnterResult2 : byte // Through Invitation/Follow User
    {   
            Success = 0,
            NotFound = 1,
            ClanAndPlayerDontMatch = 2,
            PasswordRequired = 3,
            FullCapacity = 4,
            OnlyPreviousEntry = 5,
            RequirementsNotMet = 6,
            NotInLobby = 7,
            SameUserLobby = 8,
            NotSameChannel = 9,
            NotInChannel = 19,
            FullCapacity2 = 23,
            Kicked = 24
    }
    #endregion

    #region Core

    public enum ServerType : byte
    {
        AuthServer = 1,
        LobbyServer = 2,
        GameServer = 3,
        RelayServer = 4
    }
    #endregion

    public static class Constants
    {
        public const short Lobbyackheader = 255;
        public const int MagicHeader = 0x40302010;
    }
}
