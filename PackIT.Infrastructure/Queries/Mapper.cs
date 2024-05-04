using PackIT.Application.DTO;
using PackIT.Infrastructure.Data.Models;

namespace PackIT.Infrastructure.Queries;

internal static class Mapper
{
    public static PackingListDto ToDto(this PackingListReadModel readModel)
    {
        return new PackingListDto(readModel.Id, readModel.Name, readModel.Localization.ToDto(), readModel.Items.Select(item => item.ToDto()).ToList());
    }

    public static LocalizationDto ToDto(this LocalizationReadModel readModel)
    {
        return new LocalizationDto(readModel.Country, readModel.City);
    }

    public static PackingItemDto ToDto(this PackingItemReadModel readModel) 
    {
        return new PackingItemDto(readModel.Name, readModel.Quantity, readModel.IsPacked);
    }
}
