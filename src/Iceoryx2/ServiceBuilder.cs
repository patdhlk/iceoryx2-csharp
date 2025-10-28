using System;

namespace Iceoryx2;

/// <summary>
/// Builder for creating or opening a service.
/// </summary>
public sealed class ServiceBuilder
{
    private readonly Node _node;

    internal ServiceBuilder(Node node)
    {
        _node = node ?? throw new ArgumentNullException(nameof(node));
    }

    /// <summary>
    /// Creates a publish-subscribe service builder.
    /// </summary>
    public PublishSubscribeServiceBuilder<T> PublishSubscribe<T>() where T : unmanaged
    {
        return new PublishSubscribeServiceBuilder<T>(_node);
    }

    /// <summary>
    /// Creates an event service builder.
    /// </summary>
    public EventServiceBuilder Event()
    {
        return new EventServiceBuilder(_node);
    }

    /// <summary>
    /// Creates a request-response service builder.
    /// </summary>
    public RequestResponse.RequestResponseServiceBuilder<TRequest, TResponse> RequestResponse<TRequest, TResponse>()
        where TRequest : unmanaged
        where TResponse : unmanaged
    {
        return new RequestResponse.RequestResponseServiceBuilder<TRequest, TResponse>(_node);
    }

    /// <summary>
    /// Gets a Rust-compatible type name for cross-language interoperability.
    /// Maps .NET types to their Rust equivalents for iceoryx2 type matching.
    /// </summary>
    internal static string GetRustCompatibleTypeName<T>() where T : unmanaged
    {
        var type = typeof(T);

        // Map .NET primitive types to Rust type names (unchanged)
        if (type == typeof(byte)) return "u8";
        if (type == typeof(sbyte)) return "i8";
        if (type == typeof(short)) return "i16";
        if (type == typeof(ushort)) return "u16";
        if (type == typeof(int)) return "i32";
        if (type == typeof(uint)) return "u32";
        if (type == typeof(long)) return "i64";
        if (type == typeof(ulong)) return "u64";
        if (type == typeof(float)) return "f32";
        if (type == typeof(double)) return "f64";
        if (type == typeof(bool)) return "bool";
        if (type == typeof(char)) return "char";

        // For custom structs, check for a custom Iox2TypeAttribute and then
        // return the C-style length-prefixed name (e.g. "16TransmissionData").
        var typeAttr = type.GetCustomAttributes(typeof(Iox2TypeAttribute), false);
        string baseName;
        if (typeAttr.Length > 0 && typeAttr[0] is Iox2TypeAttribute iox2Attr)
        {
            baseName = iox2Attr.TypeName;
        }
        else
        {
            baseName = type.Name;
        }

        // If the user already provided a length-prefixed name (starts with digits),
        // assume it's already in the correct format and return as-is. Otherwise
        // prefix with the UTF-8 byte length of the base name.
        if (!string.IsNullOrEmpty(baseName) && char.IsDigit(baseName[0]))
        {
            return baseName;
        }

        // Use UTF-8 byte count for the base name length (matches C strlen behavior for ASCII/UTF-8)
        var byteCount = System.Text.Encoding.UTF8.GetByteCount(baseName);
        return $"{byteCount}{baseName}";
    }
}