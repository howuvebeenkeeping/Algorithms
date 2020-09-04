using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Algorithms.SortingAlgorithms
{
    public class CocktailSort<T> : SortBase<T> where T : IComparable
    {
        public CocktailSort(IList<T> items) : base(items) { }
        
        // O(n)   - the best
        // O(n^2) - the average
        // O(n^2) - the worst
        protected override void DoSort()
        {
            var swapCountPrev = 0;
            var left = 0;
            var right = Items.Count - 1;
            while (left < right)
            {
                swapCountPrev = SwapCount;
                for (var i = left; i < right; i++)
                {
                    var a = Items[i];
                    var b = Items[i + 1];
                    if (Compare(a, b) == 1)
                    {
                        CompareCount++;
                        Swap(i, i + 1);
                    }
                }
                right--;

                if (swapCountPrev == SwapCount) return;

                for (var i = right; i > left; i--)
                {
                    var a = Items[i];
                    var b = Items[i - 1];
                    if (Compare(a, b) == -1)
                    {
                        CompareCount++;
                        Swap(i, i - 1);
                    }
                }
                left++;
            }
        }

        protected override async void DoSortVisualization()
        {
            var left = 0;
            var right = Items.Count - 1;
            while (left < right)
            {
                var swapCountPrev = SwapCount;
                for (var i = left; i < right; i++)
                {
                    var a = Items[i];
                    var b = Items[i + 1];
                    if (Compare(a, b) == 1)
                    {
                        await Task.Delay(400);
                        CompareCount++;
                        Swap(i, i + 1);
                    }

                    await Task.Delay(400);
                    MakeColorsDefault(a, b);
                }

                right--;

                if (swapCountPrev == SwapCount) return;

                for (var i = right; i > left; i--)
                {
                    var a = Items[i];
                    var b = Items[i - 1];
                    if (Compare(a, b) == -1)
                    {
                        await Task.Delay(400);
                        CompareCount++;
                        Swap(i, i - 1);
                    }

                    await Task.Delay(400);
                    MakeColorsDefault(a, b);
                }

                left++;
            }
        }
    }
}