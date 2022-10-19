using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using log4net;

namespace Mercenaries.Core
{
    public class MessageFactory
    {
        private readonly ConcurrentDictionary<ushort, Type> _handlers = new ConcurrentDictionary<ushort, Type>();
        private readonly ConcurrentDictionary<ushort, Type> _clientmessages = new ConcurrentDictionary<ushort, Type>();
        private readonly ConcurrentDictionary<Type, ushort> _servermessages = new ConcurrentDictionary<Type, ushort>();
        private Assembly _assembly { get; set; }
        private static readonly ILog _logger = LogManager.GetLogger(typeof(MessageFactory));

        public MessageFactory()
        {
            _assembly = Assembly.GetCallingAssembly();
            LoadMessageHandlers();
            LoadClientMessages();
            LoadServerMessages();
        }

        void LoadMessageHandlers()
        {
            // Probably not the best code out there but hey.. It works!
            foreach (Type atype in _assembly.GetTypes())
            {
                // Get associated attributes to said type :
                foreach (Attribute attr in atype.GetCustomAttributes())
                {
                    if (attr.GetType() == typeof(HandlerAttribute))
                    {
                        var result = atype.GetCustomAttribute<HandlerAttribute>();
                        if (!_handlers.TryAdd(result._opCode, atype))
                        {
                            _logger.Error($"Couldn't add handler for type : {atype.Name}");
                        }
                    }
                }
            }
            _logger.Debug($"Added {_handlers.Count} message handlers");
        }
        void LoadClientMessages()
        {
            foreach (Type atype in _assembly.GetTypes())
            {
                foreach (Attribute attr in atype.GetCustomAttributes())
                {
                    if (attr.GetType() == typeof(ClientMessageAttribute))
                    {
                        var result = atype.GetCustomAttribute<ClientMessageAttribute>();
                        if (!_clientmessages.TryAdd(result._opCode, atype))
                        {
                            _logger.Error($"Couldn't add client message for type : {atype.Name}");
                        }
                    }
                }
            }
            _logger.Debug($"Added {_clientmessages.Count} client messages");
        }
        void LoadServerMessages()
        {

            foreach (Type atype in _assembly.GetTypes())
            {
                foreach (Attribute attr in atype.GetCustomAttributes())
                {
                    if (attr.GetType() == typeof(ServerMessageAttribute))
                    {
                        var result = atype.GetCustomAttribute<ServerMessageAttribute>();
                        if (!_servermessages.TryAdd(atype, result._opCode))
                        {
                            _logger.Error($"Couldn't add server message for type : {atype.Name}");
                        }
                    }
                }
            }
            _logger.Debug($"Added {_servermessages.Count} server messages");
        }
        public Type GetHandler(ushort opCode)
        {
            Type handler;
            if (!_handlers.TryGetValue(opCode, out handler))
            {
                _logger.Error($"Couldn't find any handlers for message with opCode : {opCode}");
                return null;
            }
            return handler;
        }
        public Type GetClientMessage(ushort opCode)
        {
            Type message;
            if (!_clientmessages.TryGetValue(opCode, out message))
            {
                _logger.Error($"Couldn't find any client messages for opCode : {opCode}");
                return null;
            }
            return message;
        }
        public ushort GetServerOpCode(Type message)
        {
            ushort opCode;
            if (!_servermessages.TryGetValue(message, out opCode))
            {
                _logger.Error($"Couldn't find any server opcodes for type : {message.Name}");
                return 0;
            }
            return opCode;
        }

    }

}
