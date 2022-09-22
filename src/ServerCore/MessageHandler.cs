using log4net;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using NetCoreServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCore
{
    internal class MessageHandler
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(MessageHandler));
        public MessageHandler()
        {
        }
        public void HandleMessage(Session session, byte[] message)
        {
            short opCode = Extensions.ReadOpCodeFromPacket(message, session._server._servertype);

            // Find a handler with corresponding opCode  
            Type handler = session._server._messagefactory.GetHandler(opCode);

            // Prepare message to be serialized 

            



        }
       
    }
}
