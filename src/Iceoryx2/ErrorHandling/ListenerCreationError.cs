namespace Iceoryx2.ErrorHandling
{
    /// <summary>
    /// Represents an error that occurred during listener creation.
    /// Listeners wait for event notifications from notifiers.
    /// </summary>
    /// <remarks>
    /// Common causes:
    /// <list type="bullet">
    /// <item>Maximum number of listeners reached</item>
    /// <item>Event service does not exist</item>
    /// <item>Insufficient resources</item>
    /// </list>
    /// </remarks>
    public class ListenerCreationError : Iox2Error
    {
        /// <summary>
        /// Gets the error kind for pattern matching.
        /// </summary>
        public override Iox2ErrorKind Kind => Iox2ErrorKind.ListenerCreationFailed;

        /// <summary>
        /// Gets additional details about why listener creation failed.
        /// </summary>
        public override string? Details { get; }

        /// <summary>
        /// Gets a human-readable error message.
        /// </summary>
        public override string Message => Details != null
            ? $"Failed to create listener. Details: {Details}"
            : "Failed to create listener.";

        /// <summary>
        /// Initializes a new instance of the <see cref="ListenerCreationError"/> class.
        /// </summary>
        /// <param name="details">Optional details about the error.</param>
        public ListenerCreationError(string? details = null)
        {
            Details = details;
        }
    }
}