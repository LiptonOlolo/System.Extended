using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace System
{
    /// <summary>
    /// Расширения для строки.
    /// </summary>
    public static class StringExtended
    {
        /// <summary>
        /// <c>true</c> - строка пустая, либо состоит из пробелов.
        /// </summary>
        /// <param name="str">Строка, которую нужно проверить.</param>
        /// <returns></returns>
        public static bool IsEmpty(this string str) => string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);

        /// <summary>
        /// Проверка строки регулярным выражением.
        /// </summary>
        /// <param name="str">Строка, которую нужно проверить.</param>
        /// <param name="pattern">Паттерн, по которому будет произведена проверка.</param>
        /// <returns></returns>
        public static bool IsMatch(this string str, string pattern) => Regex.IsMatch(str, pattern);

        /// <summary>
        /// Получение хэша по заданному алгоритму.
        /// </summary>
        /// <param name="value">Строка, для которой нужно получить хэш значение.</param>
        /// <param name="hash">Хэш алгоритм.</param>
        /// <param name="encoding">Кодировка, дефолтное значение: UTF8.</param>
        /// <returns></returns>
        public static byte[] GetHash(this string value, HashAlgorithm hash, Encoding encoding = null)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (encoding == null)
                encoding = Encoding.UTF8;

            return encoding.GetBytes(value).GetHash(hash);
        }

        /// <summary>
        /// Получение хэша по заданному алгоритму в виде строки.
        /// </summary>
        /// <param name="value">Строка, для которой нужно получить хэш значение.</param>
        /// <param name="hash">Хэш алгоритм.</param>
        /// <param name="encoding">Кодировка, дефолтное значение: UTF8.</param>
        /// <returns></returns>
        public static string GetStringHash(this string value, HashAlgorithm hash, Encoding encoding = null)
        {
            StringBuilder sb = new StringBuilder();
            byte[] res = value.GetHash(hash, encoding);

            foreach (var item in res)
                sb.Append(item.ToString("X2"));

            return sb.ToString();
        }
    }
}
