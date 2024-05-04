namespace PackIT.Application.DTO;

public class PackingListDto(Guid id, string name, LocalizationDto localization, List<PackingItemDto> packingItems)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;
    public LocalizationDto Localization { get; set; } = localization;
    public List<PackingItemDto> Items { get; set; } = packingItems;
}
