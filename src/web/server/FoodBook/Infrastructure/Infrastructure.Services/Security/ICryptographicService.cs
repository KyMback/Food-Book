namespace FoodBook.Infrastructure.Services.Security
{
    public interface ICryptographicService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceValue"></param>
        /// <returns></returns>
        CryptographicData GenerateCryptographicData(byte[] sourceValue);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceValue"></param>
        /// <returns></returns>
        CryptographicData GenerateCryptographicData(string sourceValue);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="sourceValue"></param>
        /// <returns></returns>
        bool VerifySourceValueWithCryptographicData(CryptographicData data, byte[] sourceValue);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="sourceValue"></param>
        /// <returns></returns>
        bool VerifySourceValueWithCryptographicData(CryptographicData data, string sourceValue);
    }
}