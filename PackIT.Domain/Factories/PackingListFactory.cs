using PackIT.Domain.Consts;
using PackIT.Domain.Entities;
using PackIT.Domain.Policies;
using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Factories;

public class PackingListFactory(IEnumerable<IPackingItemsPolicy> policies) : IPackingListFactory
{
    public PackingList Create(PackingListId packingListId, PackingListName packingListName, Localization localization)
    {
        return new(packingListId, packingListName, localization);
    }

    public PackingList CreateWithDefultItems(
        PackingListId packingListId,
        PackingListName packingListName,
        TravelDays travelDays,
        Gender gender,
        Temperature temperature,
        Localization localization)
    {
        var data = new PolicyData(travelDays, gender, temperature, localization);
        var applicablePolicies = policies.Where(p => p.IsApplicable(data));

        var items = applicablePolicies.SelectMany(p => p.GenerateItems(data));
        var packingList = Create(packingListId, packingListName, localization);

        packingList.AddPackingItems(items);

        return packingList;
    }
}