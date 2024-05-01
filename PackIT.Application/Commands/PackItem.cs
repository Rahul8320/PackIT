using PackIT.Shared.Abstraction.Commands;

namespace PackIT.Application.Commands;

public record PackItem(Guid PackingListId, string Name) : ICommand;
