using System.Collections.Generic;
using System.Text;

namespace PrimeFuncPack;

public sealed partial class SourceBuilder
{
    private const int TabulationLength = 4;

    private readonly List<string> usings = [];

    private readonly string @namespace;

    private readonly List<string> aliases = [];

    private readonly StringBuilder codeBuilder = new();

    private int tabulationSize = 0;

    public SourceBuilder(string? @namespace)
        =>
        this.@namespace = string.IsNullOrWhiteSpace(@namespace) ? "PrimeFuncPack" : @namespace!;

    private SourceBuilder InnerAppendLineWithTabulation(string codeLine)
    {
        if (tabulationSize is not > 0)
        {
            return this;
        }

        var tabulation = new string(' ', TabulationLength * tabulationSize);
        _ = codeBuilder.AppendLine().Append(tabulation).Append(codeLine);

        return this;
    }
}