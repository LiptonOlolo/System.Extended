using System.Security.Cryptography;

namespace System
{
    /// <summary>
    /// Расширения для массива байт.
    /// </summary>
    public static class ByteExtenstion
    {
        /// <summary>
        /// Получение хэша из массива байт.
        /// </summary>
        /// <param name="array">Массив байт, хэш которого необходимо получить.</param>
        /// <param name="hash">Хэш алгоритм.</param>
        /// <returns></returns>
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
