using System;
using System.Collections.Concurrent;
using System.Reflection;
using log4net;

namespace ServerCore
{
    internal class MessageFactory
    {
        private readonly ConcurrentDictionary<ushort, Type> _handlers = new ConcurrentDictionary<ushort, Type>();
        private static readonly ILog _logger = LogManager.GetLogger(typeof(MessageFactory));
        private Server _serverinstance { get; set; }
        public MessageFactory(Server serverinstance)
        {
            _serverinstance = serverinstance;
        }
        internal void InitializeHandlers()
        {
            // Probably not the best code out there but hey.. It works!
            Assembly assembly = Assembly.GetCallingAssembly();

            foreach (Type atype in assembly.GetTypes())
            {
                // Get associated attributes to said type :
                foreach (Attribute attr in atype.GetCustomAttributes())
                {
                    if (attr.GetType() == typeof(ServerMessageAttribute))
                    {
                        var attrtoadd = (ServerMessageAttribute)attr;
                        if (!_handlers.TryAdd(attrtoadd._opCode, atype.GetType()))
                        {
                            _logger.Error($"Couldn't add handler for already existing type {atype.Name}");
                        }
                    }
                }
            }
            _logger.Debug($"Added {_handlers.Count} messages to the message factory");
        }

        public Type GetHandler(ushort opCode)
        {
            Type? handler;
            if (!_handlers.TryGetValue(opCode, out handler))
                _logger.Error($"Couldn't find any handlers for opCode : {opCode}");
            return handler;
        }
    }
}