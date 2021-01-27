using System;
using System.Collections.Generic;
using System.Linq;

namespace Balderdash.Extensions
{
    /// <summary>
    /// Provides static methods for manipulating collections.
    /// </summary>
    internal static class EnumerableExtensions
    {
        private static readonly Random rng = new Random();

        /// <summary>
        /// Shuffles an enumerable into a random order.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">The enumerable to shuffle.</param>
        /// <returns>A sequence that contains the elements of the input sequence in a random order.</returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
            => source.Select(x => (x, rng.Next()))
            .OrderBy(t => t.Item2)
            .Select(t => t.x);
    }
}
