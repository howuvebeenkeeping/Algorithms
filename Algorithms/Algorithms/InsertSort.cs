using System;

namespace Algorithms
{
    public class InsertSort<T> : SortBase<T> where T : IComparable
    {
        protected override void DoSort()
        {
            for (var i = 1; i < Items.Count; i++)
            {
                var temp = Items[i];
                var j = i;
                while (j > 0 && temp.CompareTo(Items[j - 1]) == -1)
                {
                    Items[j] = Items[j - 1];
                    j--;
                    
                    SwapCount++;
                    CompareCount++;
                }
                Items[j] = temp;
            }
        }
    }
}