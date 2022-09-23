﻿using ServerCore;
using ProtoBuf;

namespace ServerCore.Message.Auth
{
   [ProtoContract]
   public class CharacterCreateReqMessage
    {
        [ProtoMember(0)]
        public string Nickname { get; set; }

        [ProtoMember(1)]
        public byte Unk1 { get; set; } // Slot??

        [ProtoMember(2)]
        public CharacterHero Hero { get; set; }

        [ProtoMember(3)]
        public byte SkinColor { get; set; }
    }
}
