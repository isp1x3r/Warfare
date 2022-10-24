using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using BlubLib;
using log4net;

namespace Warfare.Core
{
    public interface IMessage
    {

    }
    public class MessageFactory
    {
        private readonly Dictionary<ushort, Type> _handlers = new Dictionary<ushort, Type>();
        private readonly Dictionary<ushort, Type> _clienttypelookup = new Dictionary<ushort, Type>();
        private readonly Dictionary<ushort, Type> _servertypelookup = new Dictionary<ushort, Type>();
        private readonly Dictionary<Type, ushort> _clientopCodelookup = new Dictionary<Type, ushort>();
        private readonly Dictionary<Type, ushort> _serveropCodelookup = new Dictionary<Type, ushort>();
        private static readonly ILog _logger = LogManager.GetLogger(typeof(MessageFactory));

        public MessageFactory()
        {
            LoadMessageHandlers();
        }
        protected void RegisterServerMessage<T>(ushort opCode)
           where T : new()
        {
            var type = typeof(T);
            _serveropCodelookup.Add(type, opCode);
            _servertypelookup.Add(opCode, type);
        }
        protected void RegisterClientMessage<T>(ushort opCode)
           where T : new()
        {
            var type = typeof(T);
            _clientopCodelookup.Add(type, opCode);
            _clienttypelookup.Add(opCode, type);
        }
        void LoadMessageHandlers()
        {
            // Probably not the best code out there but hey.. It works!
            foreach (Type atype in Assembly.GetEntryAssembly().GetTypes())
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
            if (!_clienttypelookup.TryGetValue(opCode, out message))
            {
                _logger.Error($"Couldn't find any client messages for opCode : {opCode}");
                return null;
            }
            return message;
        }
        public Type GetServerMessage(ushort opCode)
        {
            Type message;
            if (!_servertypelookup.TryGetValue(opCode, out message))
            {
                _logger.Error($"Couldn't find any server messages for opCode : {opCode}");
                return null;
            }
            return message;
        }
        public ushort GetClientOpCode(Type message)
        {
            ushort opCode;
            if (!_clientopCodelookup.TryGetValue(message, out opCode))
            {
                _logger.Error($"Couldn't find any client opcodes for type : {message.Name}");
                return 0;
            }
            return opCode;
        }
        public ushort GetServerOpCode(Type message)
        {
            ushort opCode;
            if (!_serveropCodelookup.TryGetValue(message, out opCode))
            {
                _logger.Error($"Couldn't find any server opcodes for type : {message.Name}");
                return 0;
            }
            return opCode;
        }
        public bool ContainsServerType(Type type)
        {
            return _serveropCodelookup.ContainsKey(type);
        }

        public bool ContainsServerOpCode(ushort opCode)
        {
            return _servertypelookup.ContainsKey(opCode);
        }
        public bool ContainsClientType(Type type)
        {
            return _clientopCodelookup.ContainsKey(type);
        }

        public bool ContainsClientOpCode(ushort opCode)
        {
            return _clienttypelookup.ContainsKey(opCode);
        }
    }
    public class MessageFactory<TOpCode, TMessage> : MessageFactory
    {
        protected void RegisterServerMessage<T>(TOpCode opCode)
            where T : TMessage, new()
        {
            RegisterServerMessage<T>(DynamicCast<ushort>.From(opCode));
        }
        protected void RegisterClientMessage<T>(TOpCode opCode)
           where T : TMessage, new()
        {
            RegisterClientMessage<T>(DynamicCast<ushort>.From(opCode));
        }
    }
}
