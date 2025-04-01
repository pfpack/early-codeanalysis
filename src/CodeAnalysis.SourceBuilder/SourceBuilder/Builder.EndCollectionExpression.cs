namespace PrimeFuncPack;

partial class SourceBuilder
{
    public SourceBuilder EndCollectionExpression(string? finalSymbol = default)
    {
        tabulationSize--;
        _ = InnerAppendLineWithTabulation("]");

        if (string.IsNullOrWhiteSpace(finalSymbol) is false)
        {
            _ = codeBuilder.Append(finalSymbol);
        }

        return this;
    }
}