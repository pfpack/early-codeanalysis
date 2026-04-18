using System.Collections.Generic;

namespace PrimeFuncPack;

public sealed class DisplayedTypeData
{
    public DisplayedTypeData(IReadOnlyCollection<string> allNamespaces, string displayedTypeName)
    {
        AllNamespaces = allNamespaces ?? [];
        DisplayedTypeName = displayedTypeName ?? "";
    }

    public IReadOnlyCollection<string> AllNamespaces { get; }

    public string DisplayedTypeName { get; }
}
