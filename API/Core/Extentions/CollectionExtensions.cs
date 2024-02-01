using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeClassified.Core.Extentions
{
    public static class CollectionExtensions
    {
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)
        {
            return self?.Select((item, index) => (item, index)) ?? new List<(T, int)>();
        }

        public static void ModifyEach<T>(this IList<T> source, Func<T, T> projection)
        {
            for (var i = 0; i < source.Count; i++)
            {
                source[i] = projection(source[i]);
            }
        }
    }
}
