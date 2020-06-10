using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSpitz.Util {
    public static class Extensions {
        public static void Add<TKey, TValue>(this ICollection<KeyValuePair<TKey, TValue>> collection, TKey key, TValue value) =>
            collection.Add(new KeyValuePair<TKey, TValue>(key, value));

        public static bool AddRemove<T>(this HashSet<T> hs, bool add, T element) =>
            add ?
                hs.Add(element) :
                hs.Remove(element);
    }
}
