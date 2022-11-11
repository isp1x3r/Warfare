

namespace Warfare.Network
{
    #region Authentication
    public enum ReLoginResult : ushort
    {
        Success = 0,
        Failed = 1
    }
    public enum CharacterListError : ushort
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
    public enum ServerType : byte
    {
        Beginners = 0,
        Veteran = 1,
        Clan = 2,
        CafeServer = 3,
        OpenServer = 4
    }
    #endregion

    #region Lobby
    public enum LoginResult : byte
    {
        Success = 0,
        Dismissal = 240,
        KDNotMatch = 241,
        LocationNotAllowed = 242,
        ClanOnly = 247,
        RankTooHigh = 248,
        SystemError = 249,
        UnableToRetrieveCharacter = 250,
        WaitingForResponse = 251,
        AlreadyLogged = 252,
        InvalidClientVersion = 253,
        ChannelMaxCapacity = 254,
        WrongCredentials = 255 // Back when they used the ID and Password interface
    }
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
    public enum ClanMemberLeaveReason : byte
    {
        ByDecision = 0,
        Dismissed = 1
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
    public enum RoomGameMode : byte
    {
        PVE = 3,
        UBA = 6,
    }
    public enum RoomWeaponMode : byte
    {
        Normal = 0,
        Rifle = 1,
        SMG = 2,
        Sniper = 3,
        Pistol = 4,
        Melee = 5,
        Taken = 6, // Huh?
        Shotgun = 7,
        ALL = 8
    }
    #endregion

    public static class Constants
    {
        public const short Lobbyackheader = 255;
        public const int MagicHeader = 0x40302010;
    }
}
