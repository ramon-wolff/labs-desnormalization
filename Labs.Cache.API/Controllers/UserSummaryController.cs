using Labs.Cache.API.Application.Users.Dtos;
using Labs.Cache.API.Application.Users.Queries.Get.MaterializedView;
using Labs.Cache.API.Application.Users.Queries.Get.MongoDb;
using Labs.Cache.API.Application.Users.Queries.List.Db;
using Labs.Cache.API.Application.Users.Queries.List.MaterializedView;
using Labs.Cache.API.Application.Users.Queries.List.MongoDb;
using Labs.Cache.API.Application.Users.Queries.List.Redis;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Labs.Cache.API.Controllers
{
    [ApiController]
    [Route("api/usersSummary")]
    public class UserSummaryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserSummaryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("redis")]
        public async Task<List<UsersSummaryDto>> GetAllUserSummaryCache()
        {
            return await _mediator.Send(new GetAllUsersSummaryQueryRedis());
        }

        [HttpGet("db")]
        public async Task<List<UsersSummaryDto>> GetAllUserSummaryDb()
        {
            return await _mediator.Send(new GetAllUsersSummaryDbQuery());
        }

        [HttpGet("mongo")]
        public async Task<List<UsersSummaryDto>> GetAllUserSummaryMongoDb()
        {
            return await _mediator.Send(new GetAllUsersSummaryQueryMongoDb());
        }

        [HttpGet("mongo/user")]
        public async Task<UsersSummaryDto> GetMongoDbUser(Guid userId)
        {
            return await _mediator.Send(new GetUserSummaryQueryMongoDb() { Id = userId });
        }

        [HttpGet("materializedview")]
        public async Task<List<UsersSummaryDto>> GetAllUserSummaryMaterializedView()
        {
            return await _mediator.Send(new GetAllUsersSummaryQueryMaterializedView());
        }

        [HttpGet("materializedview/user")]
        public async Task<UsersSummaryDto> GetMaterializedViewUser(Guid userId)
        {
            return await _mediator.Send(new GetUserSummaryQueryMaterializedView() { Id = userId });
        }

        [HttpGet("desnormalizedtable")]
        public async Task<List<UsersSummaryDto>> GetAllUserSummaryDesnormalizedTable()
        {
            return await _mediator.Send(new GetAllDesnormalizedUsersDbQuery());
        }

        [HttpGet("desnormalizedtable/user")]
        public async Task<UsersSummaryDto> GetUserSummaryDesnormalizedTable(Guid userId)
        {
            return await _mediator.Send(new GetUserSummaryQueryMaterializedView() { Id = userId });
        }
    }
}
