using System;
using System.IO;
using System.Linq;
using System.Reflection;
using log4net;
using BlubLib.IO;
using BlubLib.Serialization;


namespace Warfare.Core
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
            ushort opCode = Extensions.ReadOpCodeFromPacket(packet);
            // Find a message type with the corresponding opCode
            Type Cmessage = _messagefactory.GetClientMessage(opCode);
            if (Cmessage == null)
                return;
            // Find a handler for the corresponding opCode
            Type handler = _messagefactory.GetHandler(opCode);
            if (handler == null)
                return;
            // Deserialize message
            object msg = DeSerializeMessage(packet, Cmessage);
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
        public void ExecuteHandler(Type handler, Session session, object message)
        {
            if (handler == null || message == null)
                return;
            MethodInfo methodInfo = handler.GetMethod("Handle");
            if (methodInfo != null)
            {
                object result = null;
                object[] parameters = { session, message };
                object classInstance = Activator.CreateInstance(handler, null);
                result = methodInfo.Invoke(classInstance, parameters);
                if (result == null)
                    _logger.Error($"Failed to execute handler for : {handler.Name}");
            }
        }
        /// <summary>
        /// Deserializes a given byte array to a given type
        /// </summary>
        /// <param name="message">Message to be deserialized</param>
        /// <param name="tmessage">Type to be deserialized into</param>
        /// <returns>The deserialized message as an object</returns>
        public object DeSerializeMessage(byte[] packet, Type Cmessage)
        {
            // Get the raw message
            byte[] buffer = packet.Skip(4).ToArray();
          
            // Get buffer as stream
            using (var _r = new BinaryReader(new MemoryStream(buffer)))
            {
                try
                {
                    // Deserialize the message
                    return Serializer.Deserialize(_r, Cmessage);
                }
                catch (Exception ex)
                {
                    _logger.Error("Error occured deserializing message : " + ex.Message);

                }
            }
            return null;


        }
        /// <summary>
        /// Serializes a given type to a byte array
        /// </summary>
        /// <param name="message">Message to be serialized</param>
        /// <returns>The serialized message</returns>
        public byte[]? SerializeMessage(object message)
        {
            ushort opCode;
            // Find opcode for server message
            opCode = _messagefactory.GetServerOpCode(message.GetType());
            // No point in continuing if no opcodes were found.
            if (opCode == 0)
                return null;
            using (var ms = new MemoryStream())
            {
                try
                {
                    Serializer.Serialize(ms, message);
                    // Allocate new buffer for message
                    ushort newsize = Convert.ToUInt16(ms.ToArray().Length + 4);
                    byte[] msg = new byte[newsize];
                    BinaryWriter _w = new BinaryWriter(new MemoryStream(msg));

                    // Write the new message length
                    _w.Write(newsize);

                    // Write the opcode of the message
                    _w.Write(opCode);

                    // Write the message itself
                    _w.Write(ms.ToArray());

                    // Wrap it up
                    _w.Dispose();

                    return msg;
                }
                catch (Exception ex)
                {
                    _logger.Error($"Error occured serializing message : {message.GetType().FullName}\n {ex.Message}");

                }
                return null;
            }
               

        }

    }
}

