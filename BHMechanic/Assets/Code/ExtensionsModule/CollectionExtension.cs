using System;
using System.Collections.Generic;

namespace BHMechanic.Code.ExtensionsModule
{
    public static class CollectionExtension
    {
        private static readonly Random _random = new Random();

        public static T RandomElement<T>(this IList<T> __list)
        {
            return __list[_random.Next(__list.Count)];
        }
    }
}