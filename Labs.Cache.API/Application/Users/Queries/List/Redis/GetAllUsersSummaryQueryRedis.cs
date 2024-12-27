using Labs.Cache.API.Application.Users.Dtos;
using MediatR;

namespace Labs.Cache.API.Application.Users.Queries.List.Redis
{
    public class GetAllUsersSummaryQueryRedis : IRequest<List<UsersSummaryDto>>
    {
    }
}
