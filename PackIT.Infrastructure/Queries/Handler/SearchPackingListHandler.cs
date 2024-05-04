using PackIT.Application.DTO;
using PackIT.Application.Queries;
using PackIT.Shared.Abstraction.Queries;

namespace PackIT.Infrastructure.Queries.Handler;

public class SearchPackingListHandler : IQueryHandler<SearchPackingList, IEnumerable<PackingListDto>>
{
    public async Task<IEnumerable<PackingListDto>> HandleAsync(SearchPackingList query)
    {
        throw new NotImplementedException();
    }
}
