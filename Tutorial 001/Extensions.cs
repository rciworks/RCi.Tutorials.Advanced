using System.Collections.Generic;

namespace RCi.Tutorials.Advanced
{
    public static class Extensions
    {
        public static IEnumerable<T> Concat<T>(this T item, IEnumerable<T> collection)
        {
            yield return item;
            foreach (var t in collection)
            {
                yield return t;
            }
        }
    }
}
