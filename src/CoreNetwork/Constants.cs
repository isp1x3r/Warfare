﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkCore
{
    #region Authentication
    public enum CharacterHero : byte
    {
        Travis = 0x00,
        Vanessa = 0x01,
        Adam = 0x02,
        Cathy = 0x03

    }
    public enum CharacterInfoError : ushort
    {
        CharacterInformationDoesNotExist = 65404,
        CharacterDoesNotExist = 65405
    }
    #endregion

    #region Lobby
    public enum ClanDisbandResult
    {
        Success = 0,
        NotaMember = 1,
        MemberExists = 2,
        ClanDoesNotExist = 3,
        CannotDisband = 4,
    }
    public enum ChatRoomInviteResult
    {
        NoUsers = 1,
        ChatRoomClosed = 2,
        AlreadyInChatRoom = 3
    }
    public enum ClanRightChange
    {
        Master = 1,
        AssistantMaster = 2,
        Elite = 3,
        Normal = 4
    }
    public enum ClanCreateResult
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
    public enum RoomEnterResult
    {
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
        AuthServer = 0x01,
        LobbyServer = 0x02,
        MultiplayServer = 0x03
    }
    #endregion
}
