namespace PrimeFuncPack;

partial class SourceBuilder
{
    public SourceBuilder EndLambda()
    {
        currentIndentDepth--;
        return this;
    }
}