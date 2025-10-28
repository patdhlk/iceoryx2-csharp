namespace Iceoryx2.ErrorHandling
{
    /// <summary>
    /// Represents an error that occurred during server creation.
    /// Servers receive requests and send responses in request-response services.
    /// </summary>
    /// <remarks>
    /// Common causes:
    /// <list type="bullet">
    /// <item>Maximum number of servers for the service reached</item>
    /// <item>Insufficient shared memory</item>
    /// <item>Service does not exist or has incompatible type</item>
    /// </list>
    /// </remarks>
    public class ServerCreationError : Iox2Error
    {
        /// <summary>
        /// Gets the error kind for pattern matching.
        /// </summary>
        public override Iox2ErrorKind Kind => Iox2ErrorKind.ServerCreationFailed;

        /// <summary>
        /// Gets additional details about why server creation failed.
        /// </summary>
        public override string? Details { get; }

        /// <summary>
        /// Gets a human-readable error message.
        /// </summary>
        public override string Message => Details != null
            ? $"Failed to create server. Details: {Details}"
            : "Failed to create server.";

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerCreationError"/> class.
        /// </summary>
        /// <param name="details">Optional details about the error.</param>
        public ServerCreationError(string? details = null)
        {
            Details = details;
        }
    }
}