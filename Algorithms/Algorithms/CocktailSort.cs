using System;

namespace Algorithms
{
    public class CocktailSort<T> : SortBase<T> where T : IComparable
    {
        // O(n) - в лучшем случае
        // O(n^2) - в худшем случае
        public override void Sort()
        {
            var left = 0;
            var right = Items.Count - 1;
            while (left < right)
            {
                for (var i = left; i < right; i++)
                {
                    if (Items[i].CompareTo(Items[i + 1]) == 1)
                    {
                        (Items[i], Items[i + 1]) = (Items[i + 1], Items[i]);
                    }
                }
                
                right--;
                
                for (var i = right; i > left; i--)
                {
                    if (Items[i].CompareTo(Items[i - 1]) == -1)
                    {
                        (Items[i], Items[i - 1]) = (Items[i - 1], Items[i]);
                    }
                }

                left++;
            }
        }
    }
}
