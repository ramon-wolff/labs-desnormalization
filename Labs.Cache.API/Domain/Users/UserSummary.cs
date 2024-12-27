using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Labs.Cache.API.Domain.Users
{
    [BsonIgnoreExtraElements]
    public class UserSummary
    {
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string TenantName { get; set; }

        public string RoleName { get; set; }
    }
}
