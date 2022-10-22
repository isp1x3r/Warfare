﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Warfare.Core;
using Warfare.Server.Auth.Messages;

namespace Warfare.Server.Auth.Handlers
{
    [Handler(772)]
    internal class CharacterCreateHandler
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(CharacterCreateHandler));

        public CharacterCreateHandler()
        {

        }
        public bool Handle(Session session, CharacterCreateReqMessage message)
        {
            _logger.Debug("Character creation with nickname : " + message.Nickname);
            _logger.Debug("Character hero : " + message.Hero);
            _logger.Debug("Skin color : " + message.SkinColor);
            return true;
        }
    }
}
