namespace Labs.Cache.API.Infra
{
    public class RedisConsts
    {
        public const string RedisUri = "localhost:6379";

        public const int ExpiryTime = 30; // Minutes

        public const string UsersSummary = "usersSummary";
    }
}
