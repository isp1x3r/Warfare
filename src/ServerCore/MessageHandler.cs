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
        private MessageFactory _messagefactory { get; set; }

        public MessageHandler(MessageFactory messagefactory)
        {
            _messagefactory = messagefactory;
        }
        public void HandleMessage(Session session, byte[] packet)
        {
            // Get the message opcode depending on the server (Auth, Lobby, Match etc..)
            ushort opCode = Extensions.ReadOpCodeFromPacket(packet, session._server._servertype);
            // Find a message type with the corresponding opCode
            bool result;
            (Type cmessage, result) = _messagefactory.GetClientMessage(opCode);
            if (!result)
                return;
            // Find a handler for the corresponding opCode  
            Type handler = _messagefactory.GetHandler(opCode);
            if (handler == null)
                return;
            // Deserialize message
            Type msg = (Type)DeSerializeMessage(packet, cmessage);
            // Call the handler
            ExecuteHandler(handler, session, msg);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="handler">Handler for client message</param>
        /// <param name="session">Client session</param>
        /// <param name="message">Client message</param>
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
                        result = methodInfo.Invoke(classInstance, (object?[]?)parameters.Skip(1)); // Here we skip the handler parameter
                        if(!(bool)result)
                            _logger.Error($"Failed to execute handler for : {handler.Name}");
                    }
                }
            }
        }
        /// <summary>
        /// Deserializes a given byte array to a given type
        /// </summary>
        /// <param name="message">Message to be deserialized</param>
        /// <param name="tmessage">Type to be deserialized into</param>
        /// <returns>The deserialized message as an object</returns>
        public object DeSerializeMessage(byte[] message, Type tmessage)
        {
            // Prepare message to be deserialized 
            byte[] buffer = new byte[message.Length - 4];
            message.CopyTo(buffer, 4);
            // Get buffer as stream
            using (MemoryStream stream = new MemoryStream(buffer))
            {
                try
                {
                    // Deserialize the message        
                    return Serializer.Deserialize(tmessage, stream); ;
                }
                catch (Exception ex)
                {
                    _logger.Error($"Error occured deserializing message : {tmessage.Name}\n {ex.Message}");

                }          
            }
            return new object();


        }
        /// <summary>
        /// Serializes a given type to a byte array
        /// </summary>
        /// <param name="message">Message to be serialized</param>
        /// <returns>The serialized message</returns>
        public byte[]? SerializeMessage(Type message)
        {
            ushort opCode;
            bool result;
            // Find opcode for server message
            (opCode, result)= _messagefactory.GetServerOpCode(message);
            // No point in continuing if no opcodes were found.
            if (!result)
                return null;
            using (var memoryStream = new MemoryStream())
            {

                // Serialize type to a byte array
                try
                {
                    Serializer.Serialize(memoryStream, message);
                }catch(Exception ex)
                {
                    _logger.Error($"Error occured serializing message with opCode : {opCode}\n {ex.Message}");

                }
                var byteArray = memoryStream.ToArray();

                // Allocate new buffer for message
                ushort newsize = Convert.ToUInt16(byteArray.Length + 4);
                byte[] buffer = new byte[newsize];

                BinaryWriter _w = new BinaryWriter(new MemoryStream(buffer));

                // Write the new message length
                _w.Write(newsize);

                // Write the opcode of the message
                _w.Write(opCode);

                // Wrap it up
                _w.Dispose();

                return buffer;

            }

        }
    }
}
