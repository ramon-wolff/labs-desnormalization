using Labs.Cache.API.Application.Users.Dtos;
using MediatR;

namespace Labs.Cache.API.Application.Users.Queries.Get.Db
{
    public class GetDesnormalizedUserDbQuery : IRequest<UsersSummaryDto>
    {
        public Guid Id { get; set; }
    }
}
