using System;

namespace Algorithms
{
    public class BubbleSort<T> : SortBase<T> where T : IComparable
    {
        // O(n)
        protected override void DoSort()
        {
            var swapCountPrev = SwapCount;
            var count = Items.Count;
            // j можно принять за кол-во отсортированных элементов
            for (var j = 0; j < count; j++) 
            {
                for (var i = 0; i < count - j - 1; i++)
                {
                    if (Items[i].CompareTo(Items[i + 1]) == 1)
                    {
                        CompareCount++;
                        Swap(i, i + 1);
                    }
                }
                if (swapCountPrev == SwapCount) return;
            }
        }
    }
}