using PackIT.Domain.Consts;
using PackIT.Domain.Entities;
using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Factories;

public interface IPackingListFactory
{
    PackingList Create(PackingListId packingListId, PackingListName packingListName, Localization localization);
    PackingList CreateWithDefultItems(
        PackingListId packingListId,
        PackingListName packingListName,
        TravelDays travelDays,
        Gender gender,
        Temperature temperature,
        Localization localization);
}
