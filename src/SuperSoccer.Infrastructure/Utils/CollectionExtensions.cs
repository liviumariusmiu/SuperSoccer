namespace SuperSoccer.Infrastructure.Utils
{
    /// <summary>
    /// Class that provide collection extensions.
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Random number generator
        /// </summary>
        private static readonly Random _random = new();

        /// <summary>
        /// Extension method to take a specific number of random items from a Collection.
        /// </summary>
        /// <typeparam name="T">Collection's items type</typeparam>
        /// <param name="source">Collection from where to retrieve the items</param>
        /// <param name="count">Number of items to pick</param>
        /// <returns>Returns a collection of the selected random items.</returns>
        public static IEnumerable<T> TakeRandom<T>(this IEnumerable<T> source, int count)
        {
            return source.OrderBy(_ => _random.Next()).Take(count);
        }
    }
}
