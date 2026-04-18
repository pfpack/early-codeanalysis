namespace PrimeFuncPack;

partial class SourceBuilder
{
    public SourceBuilder BeginLambda()
    {
        currentIndentDepth++;
        InnerAppendLineIndented("=>");
        return this;
    }
}
