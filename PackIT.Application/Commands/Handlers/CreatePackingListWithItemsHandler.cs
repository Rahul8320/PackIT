using PackIT.Application.Exceptions;
using PackIT.Application.Services;
using PackIT.Domain.Factories;
using PackIT.Domain.Repositories;
using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstraction.Commands;

namespace PackIT.Application.Commands.Handlers;

public class CreatePackingListWithItemsHandler(
    IPackingListReadService readService,
    IPackingListRepository listRepository,
    IPackingListFactory listFactory,
    IWeatherService weatherService) : ICommandHandler<CreatePackingListWithItems>
{
    public async Task HandleAsync(CreatePackingListWithItems command)
    {
        var existingItem = await readService.ExistsByNameAsync(command.Name);

        if(existingItem)
        {
            throw new PackingListAlreadyExistsException(command.Name);
        }

        var localization = new Localization(command.Localization.City, command.Localization.Country);
        var weather = await weatherService.GetWeatherAsync(localization);

        if(weather is null)
        {
            throw new MissingLocalizationWeatherException(localization);
        }

        var packingList = listFactory.CreateWithDefultItems(command.Id,
                                                            command.Name,
                                                            command.Days,
                                                            command.Gender,
                                                            weather.Temperature,
                                                            localization);
        await listRepository.AddAsync(packingList);
    }
}
