using System.Collections.Generic;
using UnityEngine;

namespace BlackAndWhite.Tool
{

    public static class IListExtension
    {
        /// <summary>
        /// 洗牌
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="T"></typeparam>
        public static void Shuffle<T>(this IList<T> list)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                var index = Random.Range(0, list.Count);
                (list[index], list[i]) = (list[i], list[index]);
            }
        }
    }
}