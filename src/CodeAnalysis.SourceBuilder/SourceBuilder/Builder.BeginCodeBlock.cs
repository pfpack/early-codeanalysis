namespace PrimeFuncPack;

partial class SourceBuilder
{
    public SourceBuilder BeginCodeBlock()
    {
        _ = InnerAppendLineWithTabulation("{");
        tabulationSize++;

        return this;
    }
}