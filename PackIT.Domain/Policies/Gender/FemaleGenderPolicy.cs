using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Gender;

internal class FemaleGenderPolicy : IPackingItemsPolicy
{
    public IEnumerable<PackingItem> GenerateItems(PolicyData data) => 
    [
        new("Lipistick", data.Days < 7 ? 3u : 7u),
        new("Face Powder", data.Days < 7 ? 1u : 2u),
        new("Eyeliner", data.Days < 7 ? 1u : 2u)
    ];

    public bool IsApplicable(PolicyData data) => data.Gender is Consts.Gender.Female;
    
}
