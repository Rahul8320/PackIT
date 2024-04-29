using PackIT.Domain.Consts;
using PackIT.Domain.Entities;
using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Factories;

public class PackingListFactory : IPackingListFactory
{
    public PackingList Create(PackingListId packingListId, PackingListName packingListName, Localization localization)
    {
        throw new NotImplementedException();
    }

    public PackingList CreateWithDefultItems(
        PackingListId packingListId,
        PackingListName packingListName,
        TravelDays travelDays,
        Gender gender,
        Temperature temperature,
        Localization localization)
    {
        throw new NotImplementedException();
    }
}