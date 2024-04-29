using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Temperature;

internal class HighTemperaturePolicy : IPackingItemsPolicy
{
    public IEnumerable<PackingItem> GenerateItems(PolicyData data) => 
    [
        new("Hat", 1),
        new("Sunglasses", 1),
        new("Creame with UV filter", 1),
    ];

    public bool IsApplicable(PolicyData data) => data.Temperature > 25D;
    
}
