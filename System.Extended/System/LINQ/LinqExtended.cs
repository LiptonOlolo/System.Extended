using System.Collections.Generic;

namespace System.Linq
{
    /// <summary>
    /// Расширения для IEnumerable
    /// </summary>
    public static class LinqExtended
    {
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
    }
}
