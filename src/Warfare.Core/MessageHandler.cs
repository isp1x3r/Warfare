using System;

namespace Warfare.Core
{
    public abstract class MessageHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="handler">Handler for client message</param>
        /// <param name="session">Client session</param>
        /// <param name="message">Client message</param>
        public abstract void HandleMessage(Session session, byte[] packet);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="handler">Handler method</param>
        /// <param name="session">Client session</param>
        /// <param name="message">Message</param>
        public abstract void ExecuteHandler(Type handler, Session session, object message);
        /// <summary>
        /// Deserializes a given byte array to a given type
        /// </summary>
        /// <param name="message">Message to be deserialized</param>
        /// <param name="tmessage">Type to be deserialized into</param>
        /// <returns>The deserialized message as an object</returns>
        public abstract object DeSerializeMessage(byte[] packet, Type cmessage);

        /// <summary>
        /// Serializes a given type to a byte array
        /// </summary>
        /// <param name="logger">Logger instance</param>
        /// <param name="message">Message to be serialized</param>
        /// <returns>The serialized message</returns>
        public abstract byte[] SerializeMessage(object message);


    }
}
