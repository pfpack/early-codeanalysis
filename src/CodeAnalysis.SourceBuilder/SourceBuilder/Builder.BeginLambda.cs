namespace PrimeFuncPack;

partial class SourceBuilder
{
    public SourceBuilder BeginLambda()
    {
        tabulationSize++;
        return InnerAppendLineWithTabulation("=>");
    }
}