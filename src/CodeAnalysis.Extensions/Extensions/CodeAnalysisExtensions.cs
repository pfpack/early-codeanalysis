using System;

namespace PrimeFuncPack;

public static partial class CodeAnalysisExtensions
{
    private const StringComparison CodeLineComparison = StringComparison.InvariantCulture;

    private static string InnerToCamelCase(this string source)
    {
        if (string.IsNullOrEmpty(source))
        {
            return "";
        }

#if NET
        return string.Concat([Char.ToLowerInvariant(source[0])], source.AsSpan(1));
#else
        return string.Concat(Char.ToLowerInvariant(source[0]).ToString(), source.Substring(1));
#endif
    }

    private static class InnerNamespaces
    {
        internal const string System = "System";

        internal const string SystemTextJsonSerialization = "System.Text.Json.Serialization";
    }
}