namespace PrimeFuncPack;

partial class SourceBuilder
{
    public SourceBuilder EndCollectionExpression(string? finalSymbol = default)
    {
        currentIndentDepth--;
        InnerAppendLineIndented("]");

        if (string.IsNullOrWhiteSpace(finalSymbol) is false)
        {
            _ = codeBuilder.Append(finalSymbol);
        }

        return this;
    }
}
