using System.Collections.Generic;
using System.Text;

namespace System.Linq
{
    /// <summary>
    /// Расширения для IEnumerable
    /// </summary>
    public static class LinqExtenstion
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string Join<T>(this IEnumerable<T> source, string separator)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            
            separator = separator ?? string.Empty;

            StringBuilder sb = new StringBuilder();

            var en = source.GetEnumerator();

            if (!en.MoveNext())
                return string.Empty;

            if (en.Current != null)
                sb.Append(en.Current);

            while (en.MoveNext())
            {
                sb.Append(separator);
                if (en.Current != null)
                    sb.Append(en.Current);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Разделяет данную последовательность на куски заданного размера. Если длина последовательности не равномерно делится на размер куска, последний фрагмент будет содержать все остальные элементы.
        /// </summary>
        /// <typeparam name="T">Тип.</typeparam>
        /// <param name="source">Последовательность.</param>
        /// <param name="chunkSize">Размер куска.</param>
        /// <returns></returns>
        public static IEnumerable<T[]> Chunk<T>(this IEnumerable<T> source, int chunkSize)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
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
        /// Берет указанное количество элементов, затем пропускает указанное количество элементов.
        /// </summary>
        /// <typeparam name="T">Тип.</typeparam>
        /// <param name="source">Последовательность.</param>
        /// <param name="take">Количество элементов, которые будут взяты до пропуска.</param>
        /// <param name="skip">Количество элементов, которые будут пропущены.</param>
        /// <returns></returns>
        public static IEnumerable<T> TakeSkip<T>(this IEnumerable<T> source, int take, int skip)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
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

        /// <summary>
        /// Возвращает новую последовательность, которая содержит все входные элементы в случайном порядке.
        /// </summary>
        /// <typeparam name="T">Тип.</typeparam>
        /// <param name="source">Последовательность.</param>
        /// <returns></returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source) => source.OrderBy(x => Guid.NewGuid());

        /// <summary>
        /// Определяет, содержит ли последовательность какие-либо элементы, либо последовательность равна null.
        /// </summary>
        /// <typeparam name="T">Тип.</typeparam>
        /// <param name="source">Последовательность.</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source) => source == null || !source.Any();

        /// <summary>
        /// Определяет, содержит ли последовательность какие-либо элементы.
        /// </summary>
        /// <typeparam name="T">Тип.</typeparam>
        /// <param name="source">Последовательность</param>
        /// <returns></returns>
        public static bool IsEmpty<T>(this IEnumerable<T> source) => !source.Any();

        /// <summary>
        /// Выполняет указанное действие с каждым элементом списка и возвращает этот же список.
        /// </summary>
        /// <typeparam name="T">Тип элементов source.</typeparam>
        /// <param name="source">Последовательность значений.</param>
        /// <param name="action">Делегат, выполняемый для каждого элемента списка.</param>
        public static IEnumerable<T> Pipe<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            foreach (var item in source)
            {
                action(item);
                yield return item;
            }
        }

        /// <summary>
        /// Добавляет объект в последовательность.
        /// </summary>
        /// <typeparam name="T">Тип.</typeparam>
        /// <param name="source">Коллекция, в которую будет добавлен объект.</param>
        /// <param name="item">Объект.</param>
        /// <returns></returns>
        public static IEnumerable<T> Append<T>(this IEnumerable<T> source, T item)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            return source.Concat(item.Create());
        }

        /// <summary>
        /// Создает последовательность из 1 объекта.
        /// </summary>
        /// <typeparam name="T">Тип.</typeparam>
        /// <param name="item">Объект.</param>
        /// <returns></returns>
        public static IEnumerable<T> Create<T>(this T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            yield return item;
        }

        /// <summary>
        /// Создает последовательность нужного типа с параметрами конструктора.
        /// </summary>
        /// <typeparam name="T">Тип.</typeparam>
        /// <param name="count">Количество объектов, которые будут созданы в последовательности.</param>
        /// <param name="ctorArgs">Аргументы конструктора объекта.</param>
        /// <returns></returns>
        public static IEnumerable<T> CreateMany<T>(int count, params object[] ctorArgs)
        {
            if (count < 0)
                throw new ArgumentException(nameof(count));

            for (int i = 0; i < count; i++)
                yield return (T)Activator.CreateInstance(typeof(T), ctorArgs);
        }

        /// <summary>
        /// Создает последовательность нужного типа.
        /// </summary>
        /// <typeparam name="T">Тип.</typeparam>
        /// <param name="count">Количество объектов, которые будут созданы в последовательности.</param>
        /// <returns></returns>
        public static IEnumerable<T> CreateMany<T>(int count)
        {
            if (count < 0)
                throw new ArgumentException(nameof(count));

            for (int i = 0; i < count; i++)
                yield return Activator.CreateInstance<T>();
        }

        /// <summary>
        /// Выполняет указанное действие с каждым элементом списка.
        /// </summary>
        /// <typeparam name="T">Тип элементов source.</typeparam>
        /// <param name="source">Последовательность значений.</param>
        /// <param name="action">Делегат, выполняемый для каждого элемента списка.</param>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            foreach (var item in source)
                action(item);
        }

        /// <summary>
        /// Выполняет указанное действие с каждым элементом списка.
        /// </summary>
        /// <typeparam name="T">Тип элементов source.</typeparam>
        /// <param name="source">Последовательность значений.</param>
        /// <param name="action">Делегат, выполняемый для каждого элемента списка.</param>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            int i = 0;
            foreach (var item in source)
                action(item, i++);
        }

        /// <summary>
        /// Проецирует каждый элемент всех последовательностей в 1 последовательность.
        /// </summary>
        /// <typeparam name="TSource">Тип элементов source.</typeparam>
        /// <typeparam name="TResult">Тип элементов последовательности, возвращаемой selector.</typeparam>
        /// <param name="source">Последовательность значений, которые следует проецировать.</param>
        /// <param name="selector">Функция преобразования, применяемая к каждому элементу.</param>
        /// <returns></returns>
        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<IEnumerable<TSource>> source, Func<TSource, TResult> selector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            foreach (var sub in source)
                foreach (var item in sub)
                    yield return selector(item);
        }

        /// <summary>
        /// Проецирует каждый элемент всех последовательностей в 1 последовательность.
        /// </summary>
        /// <typeparam name="TSource">Тип элементов source.</typeparam>
        /// <param name="source">Последовательность значений, которые следует проецировать.</param>
        /// <returns></returns>
        public static IEnumerable<TSource> SelectMany<TSource>(this IEnumerable<IEnumerable<TSource>> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            foreach (var sub in source)
                foreach (var item in sub)
                    yield return item;
        }

        /// <summary>
        /// Проецирует каждый элемент последовательности в 1 последовательность.
        /// </summary>
        /// <typeparam name="TSource">Тип элементов source.</typeparam>
        /// <param name="source">Последовательность значений, которые следует проецировать.</param>
        /// <returns></returns>
        public static IEnumerable<T> SelectMany<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            foreach (var item in source)
                yield return item;
        }
    }
}
