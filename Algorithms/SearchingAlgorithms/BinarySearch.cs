using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.SearchingAlgorithms
{
    public class BinarySearch<T> where T : IComparable
    {
        public static int Find(IList<T> list, T item)
        {
            var low = 0;
            var high = list.Count - 1;

            while (low <= high)
            {
                var mid = (low + high) / 2;
                var guess = list[mid];
                switch (guess.CompareTo(item))
                {
                    case 0: // guess = item
                        return mid;
                    case 1: // guess > item
                        high = mid - 1;
                        break;
                    case -1: // guess < item
                        low = mid + 1;
                        break;
                }
            }

            return -1;
        }
    }
}