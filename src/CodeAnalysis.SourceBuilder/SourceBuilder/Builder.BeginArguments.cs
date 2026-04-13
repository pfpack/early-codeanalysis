namespace PrimeFuncPack;

partial class SourceBuilder
{
    public SourceBuilder BeginArguments()
    {
        currentIndentDepth++;
        return this;
    }
}