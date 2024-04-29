using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Universal;

internal class BasicPolicy : IPackingItemsPolicy
{
    private const uint MaximumQuantityOfClothes = 7;
    
    public IEnumerable<PackingItem> GenerateItems(PolicyData data) => [
        new("Toothbrush", 1),
        new("Toothpaste", 1),
        new("Towel", 2),
        new("Shampoo", 1),
        new("T-Shirt", Math.Min(data.Days, MaximumQuantityOfClothes)),
        new("Pants", Math.Min(data.Days, MaximumQuantityOfClothes)),
        new("Socks", Math.Min(data.Days, MaximumQuantityOfClothes)),
        new("Trousers", data.Days < 7 ? 1u : 2u),
        new("Phone Charager", 1),
        new("Water Bottol",1),
        ];

    public bool IsApplicable(PolicyData _) => true;
    
}
