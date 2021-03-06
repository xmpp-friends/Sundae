namespace Sundae
{
    /// <summary>
    /// Message stanza types.
    /// https://tools.ietf.org/html/rfc6121#section-5.2.2
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// A value not listed in the RFC was found.
        /// Please refer to the XML element for the actual value.
        /// </summary>
        Unknown,

        /// <summary>
        /// The message is sent in the context of a one-to-one chat session.
        /// </summary>
        Chat,

        /// <summary>
        /// The message is generated by an entity that experiences an error when processing a message received from
        /// another entity.
        /// </summary>
        Error,

        /// <summary>
        /// The message is sent in the context of a multi-user chat environment.
        /// </summary>
        Groupchat,

        /// <summary>
        /// The message provides an alert, a notification, or other transient information to which no reply is expected.
        /// </summary>
        Headline,

        /// <summary>
        /// The message is a standalone message that is sent outside the context of a one-to-one conversation or
        /// groupchat, and to which it is expected that the recipient will reply.
        /// </summary>
        Normal,
    }
}