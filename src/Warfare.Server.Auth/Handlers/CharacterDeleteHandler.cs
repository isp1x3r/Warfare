using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warfare.Core;
using Warfare.Server.Auth.Messages;

namespace Warfare.Server.Auth.Handlers
{
    [Handler(1028)]
    internal class CharacterDeleteHandler
    {
        public CharacterDeleteHandler()
        {

        }
        public bool Handle(Session session, CharacterDeleteReqMessage message)
        {

            return true;
        }
    }
}
