using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace News.Common
{
    public static class StringExtentions
    {
        public static string ToHashedString(this string input, string secret)
        {
            var Hashed = KeyDerivation.Pbkdf2(
                    password: input,
                    salt: Encoding.UTF8.GetBytes(secret),
                    prf: KeyDerivationPrf.HMACSHA512,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8
                    );
            return Convert.ToBase64String(Hashed);
        }

        public static bool IsCompare(this string input, string hashed, string secret)
        {
            return input.ToHashedString(secret).Equals(hashed);
        }

        public static string RandomNumber(int length)
        {
            var builder = new StringBuilder();
            var rand = new Random();
            for (int index = 0; index < length; index++)
            {
                builder.Append(rand.Next(1, 10));
            }

            return builder.ToString();
        }

        public static string ToCurrencyFormat(this decimal input)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            return input.ToString("#,###", cul.NumberFormat);
        }
        public static string ToCurrencyFormat(this int input)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            return input.ToString("#,###", cul.NumberFormat);
        }

        public static string GenerateCode(this string prefix, int length)
        {
            var random = new Random();
            var result = new StringBuilder(prefix.ToUpper());
            for (int i = 0; i < length; i++)
            {
                result.Append(random.Next(1, 9));
            }

            return result.ToString();
        }

        public static string ToRemoveUnicode(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            string[] VietnameseSigns = new string[]{ "aAeEoOuUiIdDyY", "áàạảãâấầậẩẫăắằặẳẵ", "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
                "éèẹẻẽêếềệểễ", "ÉÈẸẺẼÊẾỀỆỂỄ", "óòọỏõôốồộổỗơớờợởỡ","ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ","úùụủũưứừựửữ","ÚÙỤỦŨƯỨỪỰỬỮ",
                "íìịỉĩ", "ÍÌỊỈĨ", "đ", "Đ","ýỳỵỷỹ","ÝỲỴỶỸ"
            };

            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    input = input.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }
            return input.ToLower();
        }
    }
}
