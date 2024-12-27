using Labs.Cache.API.Application.Users.Dtos;
using MediatR;

namespace Labs.Cache.API.Application.Users.Queries.List.Db
{
    public class GetAllUsersSummaryDbQuery : IRequest<List<UsersSummaryDto>>
    {
    }
}
