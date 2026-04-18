using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeFuncPack;

partial class CodeAnalysisExtensions
{
    public static DisplayedTypeData GetDisplayedData(this ITypeSymbol typeSymbol, bool withNullableSuffix = false)
        =>
        InnerGetDisplayedData(
            typeSymbol: typeSymbol ?? throw new ArgumentNullException(nameof(typeSymbol)),
            withNullableSuffix: withNullableSuffix);

    private static DisplayedTypeData InnerGetDisplayedData(ITypeSymbol typeSymbol, bool withNullableSuffix)
    {
        var symbol = typeSymbol;
        var nullableSuffix = "";

        if (typeSymbol.InnerGetNullableBaseType() is ITypeSymbol baseTypeSymbol)
        {
            symbol = baseTypeSymbol;
            if (withNullableSuffix)
            {
                nullableSuffix = "?";
            }
        }

        if (symbol is IArrayTypeSymbol arrayTypeSymbol)
        {
            var elementTypeData = InnerGetChildrenDisplayedData(arrayTypeSymbol.ElementType);

            // TODO: Replace declaration of arrays of arrays to multidimensional arrays,
            // like `[size1]`, `[size1, size2]` and so on, instead of `[][]` and so on.
            IEnumerable<string> elementTypeNameParts =
                [elementTypeData.DisplayedTypeName, .. Enumerable.Repeat("[]", arrayTypeSymbol.Rank), nullableSuffix];

            return new(
                allNamespaces: elementTypeData.AllNamespaces,
                displayedTypeName: string.Concat(elementTypeNameParts));
        }

        if (symbol is not INamedTypeSymbol namedTypeSymbol || namedTypeSymbol.TypeArguments.Length is not > 0)
        {
            var typeNamespace = symbol.ContainingNamespace?.ToString();
            IReadOnlyCollection<string> typeNamespaces = string.IsNullOrEmpty(typeNamespace) ? [] : [typeNamespace!];

            return new(
                allNamespaces: typeNamespaces,
                displayedTypeName: symbol.Name + nullableSuffix);
        }

        var argumentTypes = namedTypeSymbol.TypeArguments.Select(InnerGetChildrenDisplayedData);

        var namespaces = argumentTypes.SelectMany(GetNamespaces);
        if (symbol.ContainingNamespace?.ToString() is { } containingNamespace)
        {
            namespaces = namespaces.Append(containingNamespace);
        }

        return new(
            allNamespaces: [.. namespaces],
            displayedTypeName: $"{symbol.Name}<{string.Join(", ", argumentTypes.Select(GetName))}>{nullableSuffix}");

        static DisplayedTypeData InnerGetChildrenDisplayedData(ITypeSymbol typeSymbol)
            =>
            InnerGetDisplayedData(typeSymbol, true);

        static IEnumerable<string> GetNamespaces(DisplayedTypeData typeData)
            =>
            typeData.AllNamespaces;

        static string GetName(DisplayedTypeData typeData)
            =>
            typeData.DisplayedTypeName;
    }

    private static ITypeSymbol? InnerGetNullableBaseType(this ITypeSymbol typeSymbol)
    {
        if (typeSymbol is not INamedTypeSymbol namedTypeSymbol)
        {
            return null;
        }

        if (namedTypeSymbol.IsValueType is false)
        {
            return namedTypeSymbol.NullableAnnotation is NullableAnnotation.Annotated ? typeSymbol : null;
        }

        if (namedTypeSymbol.TypeArguments.Length is 1 && namedTypeSymbol.InnerIsType(InnerNamespaces.System, "Nullable"))
        {
            return namedTypeSymbol.TypeArguments[0];
        }

        return null;
    }
}
