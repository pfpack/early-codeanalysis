namespace PrimeFuncPack;

partial class SourceBuilder
{
    public SourceBuilder BeginCollectionExpression()
    {
        InnerAppendLineIndented("[");
        currentIndentDepth++;

        return this;
    }
}