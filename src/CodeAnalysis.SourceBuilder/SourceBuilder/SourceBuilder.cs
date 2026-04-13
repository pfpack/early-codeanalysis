using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeFuncPack;

public sealed partial class SourceBuilder
{
    private const StringComparison CodeLineComparison = StringComparison.InvariantCulture;

    private const int SingleIndentSize = 4;

    private readonly string @namespace;

    private readonly List<string> usings = [];

    private readonly List<string> aliases = [];

    private readonly StringBuilder codeBuilder = new();

    private int currentIndentDepth;

    private int CurrentIndentSize => currentIndentDepth * SingleIndentSize;

    // TODO: Consider using global namespace instead of defaulting to the library namespace.
    public SourceBuilder(string? @namespace = default)
        =>
        this.@namespace = string.IsNullOrWhiteSpace(@namespace) ? $"{nameof(PrimeFuncPack)}" : @namespace!;

    private void InnerAppendLineIndented(string codeLine)
    {
        if (codeBuilder.Length > 0)
        {
            _ = codeBuilder.AppendLine();
        }

        if (currentIndentDepth > 0)
        {
            _ = codeBuilder.Append(InnerCurrentIndent());
        }

        _ = codeBuilder.Append(codeLine);
    }

    private string InnerCurrentIndent() => new(InnerChars.Space, CurrentIndentSize);

    private static class InnerChars
    {
        // Use the escape sequence to avoid confusion with other whitespace characters.
        internal const char Space = '\u0020';

        internal const char Semicolon = ';';
    }
}
