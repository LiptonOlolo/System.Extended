using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace System
{
    /// <summary>
    /// Расширения для строки.
    /// </summary>
    public static class StringExtenstion
    {
        /// <summary>
        /// String check for: empty, spaces, null.
        /// <para/>
        /// Проверка строки на: пустоту, пробелы, null.
        /// </summary>
        /// 
        /// <param name="str">
        /// String.
        /// <para/>
        /// Строка.
        /// </param>
        public static bool IsEmpty(this string str) => string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);

        /// <summary>
        /// Check the string with a regular expression.
        /// <para/>
        /// Проверка строки регулярным выражением.
        /// </summary>
        /// 
        /// <param name="str">
        /// String.
        /// <para/>
        /// Строка.
        /// </param>
        /// 
        /// <param name="pattern">
        /// Regex pattern.
        /// <para/>
        /// Паттерн регулярного выражения.
        /// </param>
        /// 
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/>
        public static bool IsMatch(this string str, string pattern)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            if (pattern == null)
                throw new ArgumentNullException(nameof(pattern));

            return Regex.IsMatch(str, pattern);
        }

        /// <summary>
        /// Convert string to bytes.
        /// <para/>
        /// Получить массив байт из строки.
        /// </summary>
        /// 
        /// <param name="str">
        /// String.
        /// <para/>
        /// Строка.
        /// </param>
        /// 
        /// <param name="encoding">
        /// Encoding, default value: UTF8.
        /// <para/>
        /// Кодировка, стандартное значение: UTF8.
        /// </param>
        /// 
        /// <exception cref="ArgumentNullException"/>
        public static byte[] GetBytes(this string str, Encoding encoding = null)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));

            encoding = encoding ?? Encoding.UTF8;

            return encoding.GetBytes(str);
        }

        /// <summary>
        /// Getting hash from string.
        /// <para/>
        /// Получение хэша из строки.
        /// </summary>
        /// 
        /// <param name="str">
        /// String.
        /// <para/>
        /// Строка.
        /// </param>
        /// 
        /// <param name="hash">
        /// Hash algorithm.
        /// <para/>
        /// Хэш алгоритм.
        /// </param>
        /// 
        /// <param name="encoding">
        /// Encoding, default value: UTF8.
        /// <para/>
        /// Кодировка, стандартное значение: UTF8.
        /// </param>
        /// 
        /// <exception cref="ArgumentNullException"/>
        public static byte[] GetHash(this string str, HashAlgorithm hash, Encoding encoding = null) => str.GetBytes(encoding).GetHash(hash);

        /// <summary>
        /// Getting hash from string in string format.
        /// <para/>
        /// Получение хэша из строки в виде строки.
        /// </summary>
        /// 
        /// <param name="str">
        /// String.
        /// <para/>
        /// Строка.
        /// </param>
        /// 
        /// <param name="hash">
        /// Hash algorithm.
        /// <para/>
        /// Хэш алгоритм.
        /// </param>
        /// 
        /// <param name="encoding">
        /// Encoding, default value: UTF8.
        /// <para/>
        /// Кодировка, стандартное значение: UTF8.
        /// </param>
        /// 
        /// <exception cref="ArgumentNullException"/>
        public static string GetStringHash(this string str, HashAlgorithm hash, Encoding encoding = null, string format = "X2")
        {
            StringBuilder sb = new StringBuilder();
            str.GetHash(hash, encoding).ForEach(x => sb.Append(x.ToString(format)));

            return sb.ToString();
        }
    }
}
