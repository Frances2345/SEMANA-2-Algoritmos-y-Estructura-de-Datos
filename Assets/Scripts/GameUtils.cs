using System;
using UnityEngine;

//namespace Fortnite.Core
//namespace Fortnite.VFX
//namespace Fortnite.Database
//namespace Fortnite.Weapons

namespace PeruanoPower.Utils
{
    public class GameUtils
    {
        public static void Process<T>(T element, Action<T> action) => action?.Invoke(element);

        public static bool Validate<T>(T element, Func<T, bool> condition) => condition != null && condition(element);

        public static bool TryFind<T>(T[] elements, Func<T, bool> condition, out T result)
        {
            foreach (var item in elements)
            {
                if (condition(item))
                {
                    result = item;
                    return true;
                }
            }
            result = default;
            return false;
        }


        public static TResult Transform<T,TResult>(T element, Func<T, TResult> func)
        {
            return func(element);
        }
    }
}
