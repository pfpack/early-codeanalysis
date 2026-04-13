namespace PrimeFuncPack;

partial class SourceBuilder
{
    public SourceBuilder BeginCodeBlock()
    {
        InnerAppendLineIndented("{");
        currentIndentDepth++;

        return this;
    }
}
