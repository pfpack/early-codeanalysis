using System.Linq;

namespace PrimeFuncPack;

partial class SourceBuilder
{
    public SourceBuilder AddUsing(params string[] usings)
    {
        foreach (var @using in usings ?? [])
        {
            InnerAddUsing(@using);
        }

        return this;
    }

    private void InnerAddUsing(string @using)
    {
        if (string.IsNullOrWhiteSpace(@using))
        {
            return;
        }

        if (string.Equals(@using, @namespace, CodeLineComparison))
        {
            return;
        }

        if (@namespace.StartsWith($"{@using}.", CodeLineComparison))
        {
            return;
        }

        if (usings.Exists(IsUsingMatch))
        {
            return;
        }

        usings.Add(@using);

        bool IsUsingMatch(string match)
            =>
            string.Equals(@using, match, CodeLineComparison);
    }
}
