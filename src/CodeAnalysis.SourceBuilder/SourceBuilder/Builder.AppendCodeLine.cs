namespace PrimeFuncPack;

partial class SourceBuilder
{
    public SourceBuilder AppendCodeLines(params string[] codeLines)
    {
        foreach (var line in codeLines ?? [])
        {
            InnerAppendLineIndented(line);
        }

        return this;
    }
}
