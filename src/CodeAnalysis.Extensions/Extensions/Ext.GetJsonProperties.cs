using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;

namespace PrimeFuncPack;

partial class CodeAnalysisExtensions
{
    public static IReadOnlyCollection<IPropertySymbol> GetJsonProperties(this ITypeSymbol typeSymbol)
    {
        if (typeSymbol is null)
        {
            return [];
        }

        return [.. typeSymbol.GetMembers().OfType<IPropertySymbol>().Where(IsPublic).Where(IsNotIgnored)];

        static bool IsPublic(IPropertySymbol propertySymbol)
            =>
            propertySymbol.DeclaredAccessibility is Accessibility.Public;

        static bool IsNotIgnored(IPropertySymbol propertySymbol)
            =>
            propertySymbol.GetAttributes().Any(IsJsonIgnoreAttribute) is false;

        static bool IsJsonIgnoreAttribute(AttributeData attributeData)
        {
            if (InnerIsType(attributeData?.AttributeClass, InnerNamespaces.SystemTextJsonSerialization, "JsonIgnoreAttribute") is false)
            {
                return false;
            }

            return attributeData.InnerGetNamedArgumentValue("Condition") is null or 1;
        }
    }
}