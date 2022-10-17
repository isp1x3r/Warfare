using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using log4net;
using ProtoBuf;



namespace Mercenaries.Core
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
            Type cmessage = _messagefactory.GetClientMessage(opCode);
            if (cmessage == null)
                return;
            // Find a handler for the corresponding opCode
            Type handler = _messagefactory.GetHandler(opCode);
            if (handler == null)
                return;
            // Deserialize message
            Type msg = DeSerializeMessage(packet, cmessage);
            // We shall not continue if there is no message
            if (msg == null)
                return;
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
        public Type? DeSerializeMessage(byte[] packet, Type tmessage)
        {
            /* This has to do with the fact that NetCoreServer returns a large buffer of 8192 bytes 
               which is why we try to replace it with one that has the correct length while also getting the payload message only for it to be deserialized */
            var payload = Extensions.GetMessageBuffer(packet);
            if (payload == null)
                return null;
            // Get buffer as stream
            using (var stream = new MemoryStream(payload))
            {
                try
                {
                    // Deserialize the message        
                    Serializer.Deserialize(tmessage, stream);
                }
                catch (Exception ex)
                {
                    _logger.Error($"Error occured deserializing message : {tmessage.Name}\n {ex.Message}");

                }
            }
            return null;


        }
        /// <summary>
        /// Serializes a given type to a byte array
        /// </summary>
        /// <param name="message">Message to be serialized</param>
        /// <returns>The serialized message</returns>
        public byte[]? SerializeMessage(Type message)
        {
            ushort opCode;
            // Find opcode for server message
            opCode = _messagefactory.GetServerOpCode(message);
            // No point in continuing if no opcodes were found.
            if (opCode == 0)
                return null;
            using (var memoryStream = new MemoryStream())
            {

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
