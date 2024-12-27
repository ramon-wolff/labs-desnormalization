using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Labs.Cache.Data.Sync.Domain.Users
{
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
