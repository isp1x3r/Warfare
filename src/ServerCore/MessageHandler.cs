using log4net;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using NetCoreServer;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            // Get the message opcode
            ushort opCode = Extensions.ReadOpCodeFromPacket(message, session._server._servertype);

            // Find a handler with corresponding opCode  
            Type handler = session._server._messagefactory.GetHandler(opCode);
            if (handler == null)
                return;
            // Prepare message to be deserialized 
            byte[] buffer = new byte[message.Length - 4];
            message.CopyTo(buffer, 4);



        }
        public void ExecuteHandler(Type handler, Session session, Type message)
        {
            if (handler != null)
            {
                MethodInfo? methodInfo = handler.GetMethod("Handle");

                if (methodInfo != null)
                {
                    object? result = null;
                    ParameterInfo[] parameters = MethodBase.GetCurrentMethod().GetParameters();
                    object? classInstance = Activator.CreateInstance(handler, null);
                    var parlength = parameters.Length - 1;
                    if (parlength == 2)
                    {
                        result = methodInfo.Invoke(classInstance, (object?[]?)parameters.Skip(1));
                        if(!(bool)result)
                            _logger.Error($"Failed to execute handler for : {handler.Name}");
                    }
                }
            }
        }
        private Type DeSerializeMessage(byte[] message)
        {

        }
        private byte[] SerializeMessage(Type message)
        {
            // Find opCode for message
            
            using (var memoryStream = new MemoryStream())
            {
                Serializer.Serialize(memoryStream, message);
                var byteArray = memoryStream.ToArray();
            }

        }
    }
}
