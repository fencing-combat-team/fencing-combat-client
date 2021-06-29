using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public static class LinqExtension
    {
        public static float Range(this IEnumerable<float> source)
        {
            var enumerable = source as float[] ?? source.ToArray();
            if (!enumerable.Any())
            {
                throw new InvalidOperationException("Cannot compute median for a null or empty set.");
            }

            return enumerable.Max() - enumerable.Min();
        }
    }
}