using System;
using System.Collections.Concurrent;
using System.Reflection;
using System.Reflection.Emit;
using log4net;

namespace ServerCore
{
    public class MessageFactory
    {
        private readonly ConcurrentDictionary<ushort, Type> _handlers = new ConcurrentDictionary<ushort, Type>();
        private readonly ConcurrentDictionary<ushort, Type> _clientmessages = new ConcurrentDictionary<ushort, Type>();
        private readonly ConcurrentDictionary<Type, ushort> _servermessages = new ConcurrentDictionary<Type, ushort>();
        private static readonly ILog _logger = LogManager.GetLogger(typeof(MessageFactory));
        private Server _serverinstance { get; set; }
   
        public MessageFactory(Server serverinstance)
        {
            _serverinstance = serverinstance;
        }
        
        internal void InitializeHandlers()
        {
            LoadMessageHandlers();
            LoadClientMessages();
        }
        void LoadMessageHandlers()
        {
            // Probably not the best code out there but hey.. It works!
            Assembly assembly = Assembly.GetCallingAssembly();

            foreach (Type atype in assembly.GetTypes())
            {
                // Get associated attributes to said type :
                foreach (Attribute attr in atype.GetCustomAttributes())
                {
                    if (attr.GetType() == typeof(HandlerAttribute))
                    {
                        var attrtoadd = (HandlerAttribute)attr;
                        if (!_handlers.TryAdd(attrtoadd._opCode, atype.GetType()))
                        {
                            _logger.Error($"Couldn't add handler for already existing type {atype.Name}");
                        }
                    }
                }
            }
            _logger.Debug($"Added {_handlers.Count} message handlers to the message factory");
        }
        void LoadClientMessages()
        {
            Assembly assembly = Assembly.GetCallingAssembly();

            foreach (Type atype in assembly.GetTypes())
            {
                foreach (Attribute attr in atype.GetCustomAttributes())
                {
                    if (attr.GetType() == typeof(ClientMessageAttribute))
                    {
                        var attrtoadd = (ClientMessageAttribute)attr;
                        if (!_clientmessages.TryAdd(attrtoadd._opCode, atype.GetType()))
                        {
                            _logger.Error($"Couldn't add client message for already existing type {atype.Name}");
                        }
                    }
                }
            }
        }
        void LoadServerMessages()
        {
            Assembly assembly = Assembly.GetCallingAssembly();

            foreach (Type atype in assembly.GetTypes())
            {
                foreach (Attribute attr in atype.GetCustomAttributes())
                {
                    if (attr.GetType() == typeof(ServerMessageAttribute))
                    {
                        var attrtoadd = (ServerMessageAttribute)attr;
                        if (!_clientmessages.TryAdd(attrtoadd._opCode, atype.GetType()))
                        {
                            _logger.Error($"Couldn't add server message for already existing type {atype.Name}");
                        }
                    }
                }
            }
        }
        public Type? GetHandler(ushort opCode)
        {
            Type handler;
            if (!_handlers.TryGetValue(opCode, out handler))
                _logger.Error($"Couldn't find any handlers for message with opCode : {opCode}");
            return handler;
        }
        public ushort? GetServerOpCode(Type message)
        {
            ushort opCode;
            if (!_servermessages.TryGetValue(message, out opCode))
                _logger.Error($"Couldn't find any opcodes for type : {message.Name}");
            return opCode;
        }
        
    }
    
}
