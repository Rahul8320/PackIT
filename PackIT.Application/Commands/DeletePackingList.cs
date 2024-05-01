using PackIT.Shared.Abstraction.Commands;

namespace PackIT.Application.Commands;

public record DeletePackingList(Guid Id) : ICommand;
