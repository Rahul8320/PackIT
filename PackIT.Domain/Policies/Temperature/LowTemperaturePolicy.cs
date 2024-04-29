using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Temperature;

internal class LowTemperaturePolicy : IPackingItemsPolicy
{
    public IEnumerable<PackingItem> GenerateItems(PolicyData data) => [
        new("Winter Hat", 1),
        new("Hoodie", data.Days < 5? 1u : 2u),
        new("Warm Jacket", 1),
        new("Gloves", 1),
    ];

    public bool IsApplicable(PolicyData data) => data.Temperature < 10D;
}
