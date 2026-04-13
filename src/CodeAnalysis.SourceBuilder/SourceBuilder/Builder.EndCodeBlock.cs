namespace PrimeFuncPack;

partial class SourceBuilder
{
    public SourceBuilder EndCodeBlock(string? finalSymbol = default)
    {
        currentIndentDepth--;
        InnerAppendLineIndented("}");

        if (string.IsNullOrWhiteSpace(finalSymbol) is false)
        {
            _ = codeBuilder.Append(finalSymbol);
        }

        return this;
    }
}