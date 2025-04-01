namespace PrimeFuncPack;

partial class SourceBuilder
{
    public SourceBuilder BeginCollectionExpression()
    {
        _ = InnerAppendLineWithTabulation("[");
        tabulationSize++;

        return this;
    }
}