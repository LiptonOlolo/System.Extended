using System.Security.Cryptography;

namespace System
{
    /// <summary>
    /// Extensions for byte array.
    /// <para/>
    /// Расширения для массива байт.
    /// </summary>
    public static class ByteExtenstion
    {
        /// <summary>
        /// Getting base64 string from byte array.
        /// <para/>
        /// Получение строки base64 из массива байт.
        /// </summary>
        /// 
        /// <param name="array">
        /// Array.
        /// <para/>
        /// Массив.
        /// </param>
        /// 
        /// <exception cref="ArgumentNullException"/>
        public static string GetBase64(this byte[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            return Convert.ToBase64String(array);
        }

        /// <summary>
        /// Getting byte array from string in base64 format.
        /// <para/>
        /// Получение массива байт из строки в формате base64.
        /// </summary>
        /// 
        /// <param name="base64string">
        /// String in base64 format.
        /// <para/>
        /// Строка в формате base64.
        /// </param>
        /// 
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="FormatException"/>
        public static byte[] GetBase64(this string base64string)
        {
            if (base64string == null)
                throw new ArgumentNullException(nameof(base64string));

            return Convert.FromBase64String(base64string);
        }

        /// <summary>
        /// Getting hash from byte array.
        /// <para/>
        /// Получение хэша из массива байт.
        /// </summary>
        /// <param name="array">
        /// Byte array.
        /// <para/>
        /// Массив байт.
        /// </param>
        /// 
        /// <param name="hash">
        /// Hash algorithm.
        /// <para/>
        /// Хэш алгоритм.
        /// </param>
        /// 
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ObjectDisposedException"/>
        public static byte[] GetHash(this byte[] array, HashAlgorithm hash)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (hash == null)
                throw new ArgumentNullException(nameof(hash));

            return hash.ComputeHash(array);
        }
    }
}
