using System;
using System.Collections.Concurrent;
using System.Reflection;
using log4net;

namespace ServerCore
{
    public class MessageFactory
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

        public Type GetHandler(short opCode)
        {
            Type handler;
            if (!_handlers.TryGetValue((ushort)opCode, out handler))
                _logger.Error($"Couldn't find any handlers for opCode : {opCode}");
            return handler;
        }
        public void ExecuteHandler(Session session, Type message)
        {

        }
    }
}