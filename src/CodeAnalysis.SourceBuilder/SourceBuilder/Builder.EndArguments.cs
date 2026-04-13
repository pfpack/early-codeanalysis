namespace PrimeFuncPack;

partial class SourceBuilder
{
    public SourceBuilder EndArguments()
    {
        currentIndentDepth--;
        return this;
    }
}