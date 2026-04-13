using System.Linq;

namespace PrimeFuncPack;

partial class SourceBuilder
{
    public SourceBuilder AddAlias(string alias)
    {
        if (string.IsNullOrWhiteSpace(alias))
        {
            return this;
        }

        if (aliases.Exists(IsAliasMatch))
        {
            return this;
        }

        aliases.Add(alias);
        return this;

        bool IsAliasMatch(string match)
            =>
            string.Equals(alias, match, CodeLineComparison);
    }
}
