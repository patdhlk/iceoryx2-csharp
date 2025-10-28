namespace Iceoryx2.ErrorHandling
{
    /// <summary>
    /// Error kinds for backward compatibility and pattern matching.
    /// </summary>
    public enum Iox2ErrorKind
    {
        /// <summary>Node creation failed.</summary>
        NodeCreationFailed,
        /// <summary>Service creation failed.</summary>
        ServiceCreationFailed,
        /// <summary>Publisher creation failed.</summary>
        PublisherCreationFailed,
        /// <summary>Subscriber creation failed.</summary>
        SubscriberCreationFailed,
        /// <summary>Sample loan failed.</summary>
        SampleLoanFailed,
        /// <summary>Send operation failed.</summary>
        SendFailed,
        /// <summary>Receive operation failed.</summary>
        ReceiveFailed,
        /// <summary>Notifier creation failed.</summary>
        NotifierCreationFailed,
        /// <summary>Listener creation failed.</summary>
        ListenerCreationFailed,
        /// <summary>Notify operation failed.</summary>
        NotifyFailed,
        /// <summary>Wait operation failed.</summary>
        WaitFailed,
        /// <summary>Event service creation failed.</summary>
        EventServiceCreationFailed,
        /// <summary>Request-response service creation failed.</summary>
        RequestResponseServiceCreationFailed,
        /// <summary>Client creation failed.</summary>
        ClientCreationFailed,
        /// <summary>Server creation failed.</summary>
        ServerCreationFailed,
        /// <summary>Request loan failed.</summary>
        RequestLoanFailed,
        /// <summary>Request send failed.</summary>
        RequestSendFailed,
        /// <summary>Response loan failed.</summary>
        ResponseLoanFailed,
        /// <summary>Response send failed.</summary>
        ResponseSendFailed,
        /// <summary>Response receive failed.</summary>
        ResponseReceiveFailed,
        /// <summary>Invalid handle.</summary>
        InvalidHandle,
        /// <summary>WaitSet creation failed.</summary>
        WaitSetCreationFailed,
        /// <summary>WaitSet attachment failed.</summary>
        WaitSetAttachmentFailed,
        /// <summary>WaitSet run operation failed.</summary>
        WaitSetRunFailed,
        /// <summary>Connection update failed.</summary>
        ConnectionUpdateFailed,
        /// <summary>Unknown error.</summary>
        Unknown
    }
}