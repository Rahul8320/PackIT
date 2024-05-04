using PackIT.Application.DTO;
using PackIT.Shared.Abstraction.Queries;

namespace PackIT.Application.Queries;

public record SearchPackingList(string SearchPharse) : IQuery<IEnumerable<PackingListDto>>;
