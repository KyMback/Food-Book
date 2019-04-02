using System.Security.Cryptography;
using System.Text;
using FoodBook.Infrastructure.Common;
using JetBrains.Annotations;

namespace FoodBook.Infrastructure.Services.Security
{
    [UsedImplicitly]
    internal class CryptographicService : ICryptographicService
    {
        public CryptographicData GenerateCryptographicData(string sourceValue)
        {
            return GenerateCryptographicData(Encoding.UTF8.GetBytes(sourceValue));
        }
        
        public CryptographicData GenerateCryptographicData(byte[] sourceValue)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SystemSettings.SaltSize]);
            
            var pbkdf2 = new Rfc2898DeriveBytes(sourceValue, salt, SystemSettings.HashIterations);
            byte[] hash = pbkdf2.GetBytes(SystemSettings.HashSize);
            
            return new CryptographicData
            {
                Salt = salt,
                HashKey = hash
            };
        }

        public bool VerifySourceValueWithCryptographicData(CryptographicData data, string sourceValue)
        {
            return VerifySourceValueWithCryptographicData(data,  Encoding.UTF8.GetBytes(sourceValue));
        }

        public bool VerifySourceValueWithCryptographicData(CryptographicData data, byte[] sourceValue)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(sourceValue, data.Salt, SystemSettings.HashIterations);
            byte[] hash = pbkdf2.GetBytes(SystemSettings.HashSize);

            bool result = true;
            for (int i = 0; i < SystemSettings.HashSize; i++)
            {
                result = result && hash[i] == data.HashKey[i];
            }

            return result;
        }
    }
}