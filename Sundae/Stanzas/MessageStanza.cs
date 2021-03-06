namespace Sundae
{
    using System.Xml;
    using static Jid;
    using static StanzaError;

    /// <summary>
    /// Message stanza given by the XMPP server.
    /// https://tools.ietf.org/html/rfc6121#section-5.2
    /// </summary>
    public class MessageStanza
    {
        internal MessageStanza() { }

        /// <summary>
        /// JID of the intended recipient.
        /// https://tools.ietf.org/html/rfc6120#section-8.1.1
        /// https://tools.ietf.org/html/rfc6121#section-5.2.1
        /// </summary>
        public Jid To { get; private set; }

        /// <summary>
        /// JID of the sender.
        /// https://tools.ietf.org/html/rfc6120#section-8.1.2
        /// </summary>
        public Jid From { get; private set; }

        /// <summary>
        /// Used by the originating entity to track any response or error stanza that it might receive in relation to
        /// the generated stanza from another entity.
        /// https://tools.ietf.org/html/rfc6120#section-8.1.3
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Type attribute of this stanza.
        /// Refer to the enumeration documentation for description and possible values.
        /// </summary>
        public MessageType Type { get; private set; }

        /// <summary>
        /// Human-readable textual contents of the message.
        /// https://tools.ietf.org/html/rfc6121#section-5.2.3
        /// </summary>
        public string Body { get; private set; }

        /// <summary>
        /// Human-readable topic of the message.
        /// https://tools.ietf.org/html/rfc6121#section-5.2.4
        /// </summary>
        public string Subject { get; private set; }

        /// <summary>
        /// Used to identify conversations or messaging sessions.
        /// https://tools.ietf.org/html/rfc6121#section-5.2.5
        /// </summary>
        public string Thread { get; private set; }

        /// <summary>
        /// Stanza-related error, if any.
        /// </summary>
        public StanzaError Error { get; private set; }

        /// <summary>
        /// XML element of this stanza.
        /// </summary>
        public XmlElement Element { get; private set; }

        internal static MessageStanza GetMessage(XmlElement element)
        {
            if (element.Name != "message")
                return null;

            return new MessageStanza
            {
                From = GetJidOrThrow(element, "from"),
                To = GetJid(element, "to"),
                Type = element.GetAttribute("type").ToEnum<MessageType>(),
                Subject = element.SingleChildOrDefault("subject")?.InnerText.Trim(),
                Body = element.SingleChildOrDefault("body")?.InnerText.Trim(),
                Thread = element.SingleChildOrDefault("thread")?.InnerText.Trim(),
                Error = GetStanzaError(element),
                Element = element,
            };
        }
    }
}