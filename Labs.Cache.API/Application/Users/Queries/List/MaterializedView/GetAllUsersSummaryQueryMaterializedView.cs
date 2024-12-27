using Labs.Cache.API.Application.Users.Dtos;
using MediatR;

namespace Labs.Cache.API.Application.Users.Queries.List.MaterializedView
{
    public class GetAllUsersSummaryQueryMaterializedView : IRequest<List<UsersSummaryDto>>
    {
    }
}
