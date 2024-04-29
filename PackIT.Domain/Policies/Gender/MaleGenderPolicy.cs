using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Gender;

internal class MaleGenderPolicy : IPackingItemsPolicy
{
    public IEnumerable<PackingItem> GenerateItems(PolicyData data) =>
    [
        new(name: "MacBook", quantity: 1),
        new(name: "iPad", quantity: 1),
        new(name: "iPhone", quantity: 1),
        new(name: "Camera", quantity: 1),
        new("Camera Battery", 2),
        new("Drone", 1),
        new("Drone Battery", 2),
        new("Charagers", 2)
    ];

    public bool IsApplicable(PolicyData data) => data.Gender is Consts.Gender.Male;
}
