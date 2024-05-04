using PackIT.Application.DTO;
using PackIT.Shared.Abstraction.Queries;

namespace PackIT.Application.Queries;

public record GetPackingList(Guid Id) : IQuery<PackingListDto>;
