using Labs.Cache.API.Application.Users.Dtos;
using MediatR;

namespace Labs.Cache.API.Application.Users.Queries.Get.MaterializedView
{
    public class GetUserSummaryQueryMaterializedView : IRequest<UsersSummaryDto>
    {
        public Guid Id { get; set; }
    }
}
