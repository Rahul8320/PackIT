using PackIT.Application.DTO;
using PackIT.Application.Queries;
using PackIT.Shared.Abstraction.Queries;

namespace PackIT.Infrastructure.Queries.Handler;

public class GetPackingListHandler : IQueryHandler<GetPackingList, PackingListDto>
{
    public async Task<PackingListDto> HandleAsync(GetPackingList query)
    {
        throw new NotImplementedException();
    }
}
