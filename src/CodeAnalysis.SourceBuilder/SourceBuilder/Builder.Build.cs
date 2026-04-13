using System.Linq;
using System.Text;

namespace PrimeFuncPack;

partial class SourceBuilder
{
    public string Build()
    {
        var builder = new StringBuilder("// Auto-generated code by PrimeFuncPack").AppendLine().Append("#nullable enable");

        if (usings.Count > 0)
        {
            builder = builder.AppendLine();
        }

        foreach (var @using in usings.OrderBy(NormalizeNamespaceOrder))
        {
            builder = builder.AppendLine().Append("using").Append(InnerChars.Space).Append(@using).Append(InnerChars.Semicolon);
        }

        builder = builder.AppendLine().AppendLine().Append("namespace").Append(InnerChars.Space).Append(@namespace).Append(InnerChars.Semicolon);

        if (aliases.Count > 0)
        {
            builder = builder.AppendLine();
        }

        foreach (var alias in aliases)
        {
            builder = builder.AppendLine().Append("using").Append(InnerChars.Space).Append(alias).Append(InnerChars.Semicolon);
        }

        if (codeBuilder.Length is not > 0)
        {
            return builder.ToString();
        }

        return builder.AppendLine().AppendLine().Append(codeBuilder).ToString();

        static string NormalizeNamespaceOrder(string @namespace)
            =>
            @namespace.StartsWith("System", CodeLineComparison) ? $"_{@namespace}" : @namespace;
    }
}