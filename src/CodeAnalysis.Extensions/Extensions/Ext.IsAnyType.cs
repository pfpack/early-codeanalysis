using Microsoft.CodeAnalysis;
using System;
using System.Linq;

namespace PrimeFuncPack;

partial class CodeAnalysisExtensions
{
    public static bool IsAnyType(this ITypeSymbol typeSymbol, string @namespace, params string[] types)
    {
        if (typeSymbol is null || types?.Length is not > 0)
        {
            return false;
        }

        if (string.Equals(typeSymbol.ContainingNamespace?.ToString(), @namespace, CodeLineComparison) is false)
        {
            return false;
        }

        return types.Any(IsEqualToType);

        bool IsEqualToType(string type)
            =>
            string.Equals(typeSymbol.Name, type, CodeLineComparison);
    }
}