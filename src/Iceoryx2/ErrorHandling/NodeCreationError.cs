namespace Iceoryx2.ErrorHandling
{
    /// <summary>
    /// Represents an error that occurred during node creation.
    /// A node is the entry point to iceoryx2 and manages resources and configuration.
    /// </summary>
    /// <remarks>
    /// Common causes:
    /// <list type="bullet">
    /// <item>Invalid node configuration</item>
    /// <item>Insufficient system resources</item>
    /// <item>Permission issues</item>
    /// </list>
    /// </remarks>
    public class NodeCreationError : Iox2Error
    {
        /// <summary>
        /// Gets the error kind for pattern matching.
        /// </summary>
        public override Iox2ErrorKind Kind => Iox2ErrorKind.NodeCreationFailed;

        /// <summary>
        /// Gets additional details about why node creation failed.
        /// </summary>
        public override string? Details { get; }

        /// <summary>
        /// Gets a human-readable error message.
        /// </summary>
        public override string Message => Details != null
            ? $"Failed to create node. Details: {Details}"
            : "Failed to create node.";

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeCreationError"/> class.
        /// </summary>
        /// <param name="details">Optional details about the error.</param>
        public NodeCreationError(string? details = null)
        {
            Details = details;
        }
    }
}