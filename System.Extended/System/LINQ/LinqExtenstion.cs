using System.Collections.Generic;

namespace System.Linq
{
    /// <summary>
    /// Extensions for IEnumerable.
    /// <para/>
    /// Расширения для IEnumerable.
    /// </summary>
    public static class LinqExtenstion
    {
        /// <summary>
        /// Joining collection in 1 string.
        /// <para/>
        /// Объединяет всю коллекцию в 1 строку с разделителем.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// Collection type.
        /// <para/>
        /// Тип коллекции.
        /// </typeparam>
        /// 
        /// <param name="source">
        /// Collection.
        /// <para/>
        /// Коллекция.
        /// </param>
        /// 
        /// <param name="separator">
        /// Separator.
        /// <para/>
        /// Разделитель.
        /// </param>
        /// 
        /// <exception cref="ArgumentNullException"/>
        public static string Join<T>(this IEnumerable<T> source, string separator)
        {
            source = source ?? throw new ArgumentNullException(nameof(source));

            separator = separator ?? string.Empty;

            return string.Join(separator, source);
        }

        /// <summary>
        /// Split collection on chunks.
        /// <para/>
        /// Разделяет коллекцию на куски.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// Collection type.
        /// <para/>
        /// Тип коллекции.
        /// </typeparam>
        /// 
        /// <param name="source">
        /// Collection.
        /// <para/>
        /// Коллекция.
        /// </param>
        /// 
        /// <param name="chunkSize">
        /// Chunk size.
        /// <para/>
        /// Размер куска.
        /// </param>
        /// 
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/>
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunkSize)
        {
            source = source ?? throw new ArgumentNullException(nameof(source));
            if (chunkSize <= 0)
                throw new ArgumentException(nameof(chunkSize));

            T[] chunk = null;
            int index = 0;

            foreach (var item in source)
            {
                chunk = chunk ?? new T[chunkSize];
                chunk[index++] = item;

                if (index == chunkSize)
                {
                    yield return chunk;
                    index = 0;
                    chunk = null;
                }
            }

            if (chunk != null)
            {
                var lastChunk = new T[index];
                Array.Copy(chunk, lastChunk, index);

                yield return lastChunk;
            }
        }

        /// <summary>
        /// Shuffle all items.
        /// <para/>
        /// Возвращает коллекцию, которая содержит все элементы в случайном порядке.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// Collection type.
        /// <para/>
        /// Тип коллекции.
        /// </typeparam>
        /// 
        /// <param name="source">
        /// Collection.
        /// <para/>
        /// Коллекция.
        /// </param>
        /// <exception cref="ArgumentNullException"/>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            source = source ?? throw new ArgumentNullException(nameof(source));

            return source.OrderBy(x => Guid.NewGuid());
        }

        /// <summary>
        /// Check collection to empty or null.
        /// <para/>
        /// Определяет, содержит ли коллекция какие-либо элементы, либо коллекция равна null.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// Collection type.
        /// <para/>
        /// Тип коллекции.
        /// </typeparam>
        /// 
        /// <param name="source">
        /// Collection.
        /// <para/>
        /// Коллекция.
        /// </param>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source) => source == null || !source.Any();

        /// <summary>
        /// Check collection to empty.
        /// <para/>
        /// Определяет, содержит ли коллекция какие-либо элементы.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// Collection type.
        /// <para/>
        /// Тип коллекции.
        /// </typeparam>
        /// 
        /// <param name="source">
        /// Collection.
        /// <para/>
        /// Коллекция.
        /// </param>
        /// <exception cref="ArgumentNullException"/>
        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            source = source ?? throw new ArgumentNullException(nameof(source));

            return !source.Any();
        }

        /// <summary>
        /// Performs the specified action on each item in the collection and returns the same list.
        /// <para/>
        /// Выполняет указанное действие с каждым элементом коллекции и возвращает этот же список.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// Collection type.
        /// <para/>
        /// Тип коллекции.
        /// </typeparam>
        /// 
        /// <param name="source">
        /// Collection.
        /// <para/>
        /// Коллекция.
        /// </param>
        /// 
        /// <param name="action">
        /// A delegate that runs for each item in the collection.
        /// <para/>
        /// Делегат, выполняемый для каждого элемента коллекции.
        /// </param>
        /// <exception cref="ArgumentNullException"/>
        public static IEnumerable<T> Pipe<T>(this IEnumerable<T> source, Action<T> action)
        {
            source = source ?? throw new ArgumentNullException(nameof(source));
            action = action ?? throw new ArgumentNullException(nameof(action));

            foreach (var item in source)
            {
                action(item);
                yield return item;
            }
        }

        /// <summary>
        /// Adding item to collection.
        /// <para/>
        /// Добавляет объект в коллекцию.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// Collection type.
        /// <para/>
        /// Тип коллекции.
        /// </typeparam>
        /// 
        /// <param name="source">
        /// Collection.
        /// <para/>
        /// Коллекция.
        /// </param>
        /// 
        /// <param name="item">
        /// Item.
        /// <para/>
        /// Объект.
        /// </param>
        /// 
        /// <exception cref="ArgumentNullException"/>
        public static IEnumerable<T> Append<T>(this IEnumerable<T> source, T item)
        {
            source = source ?? throw new ArgumentNullException(nameof(source));
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            return source.Concat(item.Create());
        }

        /// <summary>
        /// Create collection from 1 item.
        /// <para/>
        /// Создает последовательность из 1 объекта.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// Collection type.
        /// <para/>
        /// Тип коллекции.
        /// </typeparam>
        /// 
        /// <param name="item">
        /// Item.
        /// <para/>
        /// Объект.
        /// </param>
        /// 
        /// <exception cref="ArgumentNullException"/>
        public static IEnumerable<T> Create<T>(this T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            yield return item;
        }

        /// <summary>
        /// Performs the specified action on each item in the collection.
        /// <para/>
        /// Выполняет указанное действие с каждым элементом коллекции.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// Collection type.
        /// <para/>
        /// Тип коллекции.
        /// </typeparam>
        /// 
        /// <param name="source">
        /// Collection.
        /// <para/>
        /// Коллекция.
        /// </param>
        /// 
        /// <param name="action">
        /// A delegate that runs for each item in the collection.
        /// <para/>
        /// Делегат, выполняемый для каждого элемента коллекции.
        /// </param>
        /// 
        /// <exception cref="ArgumentNullException"/>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            source = source ?? throw new ArgumentNullException(nameof(source));
            action = action ?? throw new ArgumentNullException(nameof(action));

            foreach (var item in source)
                action(item);
        }

        /// <summary>
        /// Performs the specified action on each item in the collection.
        /// <para/>
        /// Выполняет указанное действие с каждым элементом коллекции.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// Collection type.
        /// <para/>
        /// Тип коллекции.
        /// </typeparam>
        /// 
        /// <param name="source">
        /// Collection.
        /// <para/>
        /// Коллекция.
        /// </param>
        /// 
        /// <param name="action">
        /// A delegate that runs for each item in the collection.
        /// <para/>
        /// Делегат, выполняемый для каждого элемента коллекции.
        /// </param>
        /// 
        /// <exception cref="ArgumentNullException"/>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            source = source ?? throw new ArgumentNullException(nameof(source));
            action = action ?? throw new ArgumentNullException(nameof(action));

            int i = 0;
            foreach (var item in source)
                action(item, i++);
        }

        /// <summary>
        /// Takes the specified number of elements, then skips the specified number of elements.
        /// <para/>
        /// Берет указанное количество элементов, затем пропускает указанное количество элементов.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// Collection type.
        /// <para/>
        /// Тип коллекции.
        /// </typeparam>
        /// 
        /// <param name="source">
        /// Collection.
        /// <para/>
        /// Коллекция.
        /// </param>
        /// 
        /// <param name="take">
        /// The number of items to be taken before skipping.
        /// <para/>
        /// Количество элементов, которые будут взяты до пропуска.
        /// </param>
        /// 
        /// <param name="skip">
        /// Number of items to be skipped.
        /// <para/>
        /// Количество элементов, которые будут пропущены.
        /// </param>
        /// 
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/>
        public static IEnumerable<T> TakeSkip<T>(this IEnumerable<T> source, int take, int skip)
        {
            source = source ?? throw new ArgumentNullException(nameof(source));

            if (take <= 0)
                throw new ArgumentException(nameof(take));
            if (skip < 0)
                throw new ArgumentException(nameof(skip));

            var en = source.GetEnumerator();

            while (true)
            {
                for (int i = 0; i < take; i++)
                {
                    if (!en.MoveNext())
                        yield break;

                    yield return en.Current;
                }

                for (int i = 0; i < skip; i++)
                {
                    if (!en.MoveNext())
                        yield break;
                }
            }
        }
    }
}
