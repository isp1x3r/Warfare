using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warfare.Core;
using Warfare.Server.Auth.Messages;

namespace Warfare.Server.Auth.Handlers
{
    [Handler(772)]
    internal class CharacterCreateHandler
    {
        public CharacterCreateHandler()
        {

        }
        public static bool Handle(Session session, CharacterCreateReqMessage message)
        {

            return true;
        }
    }
}
