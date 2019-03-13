namespace FoodBook.Infrastructure.Services.Security
{
    public class CryptographicData
    {
        public byte[] HashKey { get; set; }

        public byte[] Salt { get; set; }
    }
}