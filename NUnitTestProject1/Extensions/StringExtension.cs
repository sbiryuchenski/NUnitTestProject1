using System;

namespace NUnitTestProject1.Extensions
{
    /// <summary>
    /// Работа со строками
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Сгенерировать имейл
        /// </summary>
        /// <returns></returns>
        public static string GenerateRandomEmail()
        {
            return $"{GenerateRandomString(7)}@{GenerateRandomString(4)}.{GenerateRandomString(2)}";
        }

        /// <summary>
        /// Сгенерировать случайную строку
        /// </summary>
        /// <returns></returns>
        public static string GenerateRandomString(int length) // TODO: Сделать выбор типа строки
        {
            char[] letters = "qwertyuiopasdfghjklzxcvbnm".ToCharArray();
            string randomString = string.Empty;
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                randomString += letters[rnd.Next(0, letters.Length - 1)];
            }
            return randomString;
        }
    }
}
