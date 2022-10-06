using System;
using System.Collections.Concurrent;
using log4net;
using NetCoreServer;

namespace Mercenary.Core
{
    internal class SessionManager
    {
        private readonly ConcurrentDictionary<Guid, TcpSession> _sessions = new ConcurrentDictionary<Guid, TcpSession>();
        private static readonly ILog _logger = LogManager.GetLogger(typeof(SessionManager));

        public void AddSession(TcpSession session)
        {
            if(!_sessions.TryAdd(session.Id, session))
            {
                _logger.Error($"Couldn't add session with guid : {session.Id}");
            }
        }
        public void RemoveSession(TcpSession session)
        {
            if (!_sessions.TryRemove(session.Id, out _))
            {
                _logger.Error($"Couldn't remove session with guid : {session.Id}");
            }
        }
    }
}
