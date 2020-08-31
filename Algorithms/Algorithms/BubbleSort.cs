using System;

namespace Algorithms
{
    public class BubbleSort<T> : SortBase<T> where T : IComparable
    {
        // O(n)
        public override void Sort()
        {
            var count = Items.Count;
            // j можно принять за кол-во отсортированных элементов
            for (var j = 0; j < count; j++) 
            {
                for (var i = 0; i < count - j - 1; i++)
                {
                    if (Items[i].CompareTo(Items[i + 1]) == 1)
                    {
                        (Items[i], Items[i + 1]) = (Items[i + 1], Items[i]);
                    }
                }
            }
        }
    }
}