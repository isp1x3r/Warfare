using System;
using System.IO;
using System.Linq;
using System.Reflection;
using BlubLib.Serialization;
using log4net;
using Warfare.Core;
using Warfare.Network.Message.Auth;
namespace Warfare.Server.Auth
{
    internal class AuthMessageHandler : MessageHandler
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(AuthMessageHandler));
        public MessageFactory _messagefactory { get; set; }

        public AuthMessageHandler()
        {
            _messagefactory = new AuthMessageFactory();
        }

        public override void HandleMessage(Session session, byte[] packet)
        {
            ushort opCode;
            using (var _br = new BinaryReader(new MemoryStream(packet)))
            {
                _br.BaseStream.Position = 2;
                opCode = _br.ReadUInt16();
            }
            // Does the opcode exist?
            if (!_messagefactory.ContainsClientOpCode(opCode))
                return;
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
            // We shall not continue if no message was deserialized
            if (msg == null)
                return;
            // Call the handler
            ExecuteHandler(handler, session, msg);

        }

        public override void ExecuteHandler(Type handler, Session session, object message)
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
        public override object DeSerializeMessage(byte[] packet, Type cmessage)
        {
            // Get the raw message
            byte[] buffer = packet.Skip(4).ToArray();

            // Get buffer as stream
            using (var _r = new BinaryReader(new MemoryStream(buffer)))
            {
                try
                {
                    // Deserialize the message
                    return Serializer.Deserialize(_r, cmessage);
                }
                catch (Exception ex)
                {
                    _logger.Error("Error occured deserializing message : " + ex.Message);

                }
            }
            return null;
        }
        public override byte[] SerializeMessage(object message)
        {
            ushort opCode;
            // Does it exist?
            if (!_messagefactory.ContainsServerType(message.GetType()))
                return null;
            // Find opcode for server message
            opCode = _messagefactory.GetServerOpCode(message.GetType());
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

