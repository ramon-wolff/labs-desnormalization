using Labs.Cache.API.Application.Users.Dtos;
using MediatR;

namespace Labs.Cache.API.Application.Users.Queries.Get.MongoDb
{
    public class GetUserSummaryQueryMongoDb : IRequest<UsersSummaryDto>
    {
        public Guid Id { get; set; }
    }
}
