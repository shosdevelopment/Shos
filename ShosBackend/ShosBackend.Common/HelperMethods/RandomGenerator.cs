using ShosBackend.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShosBackend.Common.HelperMethods
{
    public interface IRandomGenerator
    {
        string GenerateNumber(int length, GenerateOption generateOption = GenerateOption.Default);
    }
    public class RandomGenerator : IRandomGenerator
    {
        private const string NUMERIC_CHARS = "1234567890";
        private const string NUMERIC_NoZero_CHARS = "123456789";
        private const string ALPHA_NUMERIC_CHARS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        public string GenerateNumber(int length, GenerateOption generateOption = GenerateOption.Default)
        {
            switch (generateOption)
            {
                case GenerateOption.Default:
                    return Random(length, NUMERIC_CHARS);
                case GenerateOption.NoLeadingZero:
                    var firstChar = Random(1, NUMERIC_NoZero_CHARS);
                    return firstChar + Random(length - 1, NUMERIC_CHARS);
                default:
                    throw new ArgumentOutOfRangeException(nameof(generateOption), generateOption, null);
            }
        }

        private static string Random(int length, string chars)
        {
            var data = new byte[4 * length];

            using (var crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }

            var result = new StringBuilder(length);
            for (var i = 0; i < length; i++)
            {
                result.Append(chars[Convert.ToInt32(BitConverter.ToUInt32(data, 4 * i) % (chars.Length))]);
            }
            return result.ToString();
        }
    }
}
