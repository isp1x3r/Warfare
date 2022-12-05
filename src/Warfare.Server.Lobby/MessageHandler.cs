using System;
using System.IO;
using System.Linq;
using System.Reflection;
using BlubLib.Serialization;
using log4net;
using Warfare.Core;
using Warfare.Network;
using Warfare.Network.Message.Lobby;
namespace Warfare.Server.Lobby
{
    public class LobbyMessageHandler : MessageHandler
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(LobbyMessageHandler));
        public MessageFactory Messagefactory { get; set; }

        public LobbyMessageHandler()
        {
            Messagefactory = new LobbyMessageFactory();
        }

        public override void HandleMessage(Session session, byte[] packet)
        {
            ushort opCode;
            bool isMisc = false;
            using (var _br = new BinaryReader(new MemoryStream(packet)))
            {
                _br.BaseStream.Position = 8;
                opCode = _br.ReadUInt16();
                // If it's a misc message
                if (opCode == 0x60)
                {
                    _br.ReadUInt16(); // Skip 2 bytes
                    opCode = _br.ReadByte();
                    isMisc = true;
                }                 
            }
            // Does the opcode exist?
            if (!Messagefactory.ContainsClientOpCode(opCode))
                return;
            // Find a message type for the corresponding opCode
            Type Cmessage = Messagefactory.GetClientMessage(opCode);
            if (Cmessage == null)
                return;
            // Find a handler for the corresponding opCode
            Type handler = Messagefactory.GetHandler(opCode);
            if (handler == null)
                return;
            // We should only pass the raw message
            if(isMisc)
            {
                packet = packet.Skip(13).ToArray();
            }else
            {
                packet = packet.Skip(10).ToArray();
            }
            object msg = DeSerializeMessage(packet, Cmessage);

            // Call the handler
            ExecuteHandler(handler, session, msg);

        }

        public override void ExecuteHandler(Type handler, Session session, object message)
        {
            if (handler == null)
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

            // Get buffer as stream
            using (var _r = new BinaryReader(new MemoryStream(packet)))
            {
                try
                {
                    // Deserialize the message
                    return Serializer.Deserialize(_r, cmessage);
                }
                catch (EndOfStreamException ex)
                {
                    return null;
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
            bool isMisc = false;
            // If it's a misc message
            if (message.GetType().IsSubclassOf(typeof(MiscAckMessage)))
            {
                isMisc = true;
            }
            ushort opCode;
            // Does it exist?
            if (!Messagefactory.ContainsServerType(message.GetType()))
                return null;
            // Find opcode for server message
            opCode = Messagefactory.GetServerOpCode(message.GetType());
            ushort newsize;
            using (var ms = new MemoryStream())
            {
                try
                {
                    Serializer.Serialize(ms, message);
                    // Allocate new buffer for message
                    if(isMisc)
                    {
                        newsize = Convert.ToUInt16(ms.ToArray().Length + 13);
                    }
                    else
                    {
                        newsize = Convert.ToUInt16(ms.ToArray().Length + 10);
                    }
                    byte[] msg = new byte[newsize];
                    BinaryWriter _w = new BinaryWriter(new MemoryStream(msg));

                    // Write the new message length
                    _w.Write(newsize);

                    // Write the header
                    _w.Write(Constants.Lobbyackheader);

                    // Write the magic header
                    _w.Write(Constants.MagicHeader);

                    // Write the opcode of the message
                    if (isMisc) // In case it's a misc message
                    {
                        _w.Write((ushort)0x60);
                        _w.Write((ushort)0x00);
                        _w.Write((byte)opCode);
                    }else
                    {
                        _w.Write(opCode);
                    }
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

