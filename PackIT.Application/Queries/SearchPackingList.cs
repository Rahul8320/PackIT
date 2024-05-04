using PackIT.Shared.Abstraction.Queries;

namespace PackIT.Application.Queries;

public record SearchPackingList(string SearchPharse) : IQuery;
