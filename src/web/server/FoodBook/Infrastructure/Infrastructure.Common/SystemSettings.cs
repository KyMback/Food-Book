namespace FoodBook.Infrastructure.Common
{
    public static class SystemSettings
    {
        public static int HashIterations => 10000;

        public static int SaltSize => 16;

        public static int HashSize => 20;

        public static string NameOfUserAccountIdClaim => "UserAccountId";
        
        public const string DefaultRouteForApiControllers = "api/[controller]";
        
        public const string DefaultContentTypeForApiControllers = "application/json";
    }
}