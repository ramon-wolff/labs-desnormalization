using Labs.Cache.API.Application.Users.Dtos;
using MediatR;

namespace Labs.Cache.API.Application.Users.Queries.List.MongoDb
{
    public class GetAllUsersSummaryQueryMongoDb : IRequest<List<UsersSummaryDto>>
    {
    }
}
