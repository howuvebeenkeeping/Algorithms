using System;

namespace Algorithms
{
    public class CocktailSort<T> : SortBase<T> where T : IComparable
    {
        // O(n) - в лучшем случае
        // O(n^2) - в худшем случае
        protected override void DoSort()
        {
            var swapCountPrev = SwapCount;
            var left = 0;
            var right = Items.Count - 1;
            while (left < right)
            {
                for (var i = left; i < right; i++)
                {
                    if (Items[i].CompareTo(Items[i + 1]) == 1)
                    {
                        CompareCount++;
                        Swap(i, i + 1);
                    }
                }
                
                right--;

                if (swapCountPrev == SwapCount) return;
                
                for (var i = right; i > left; i--)
                {
                    if (Items[i].CompareTo(Items[i - 1]) == -1)
                    {
                        CompareCount++;
                        Swap(i, i - 1);
                    }
                }

                left++;
            }
        }
    }
}
