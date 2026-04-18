using Microsoft.CodeAnalysis;
using System;
using System.Linq;

namespace PrimeFuncPack;

partial class CodeAnalysisExtensions
{
    public static string GetJsonPropertyName(this IPropertySymbol propertySymbol)
    {
        _ = propertySymbol ?? throw new ArgumentNullException(nameof(propertySymbol));

        var jsonPropertyNameAttribute = propertySymbol.GetAttributes().FirstOrDefault(IsJsonPropertyNameAttribute);
        if (jsonPropertyNameAttribute is not null)
        {
            var name = jsonPropertyNameAttribute.InnerGetConstructorArgumentValue(0)?.ToString();
            if (string.IsNullOrEmpty(name) is false)
            {
                return name!;
            }
        }

        return propertySymbol.Name.InnerToCamelCase();

        static bool IsJsonPropertyNameAttribute(AttributeData attributeData)
            =>
            InnerIsType(attributeData.AttributeClass, "System.Text.Json.Serialization", "JsonPropertyNameAttribute");
    }
}
