using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithms.SortingAlgorithms
{
    public class BubbleSort<T> : SortBase<T> where T : IComparable
    {
        public BubbleSort(IList<T> items) : base(items) { }

        // O(n)   - the best
        // O(n^2) - the average
        // O(n^2) - the worst
        protected override void DoSort()
        {
            var count = Items.Count;
            // j можно принять за кол-во отсортированных элементов
            for (var j = 0; j < count; j++)
            {
                var swapCountPrev = SwapCount;
                for (var i = 0; i < count - j - 1; i++)
                {
                    if (Items[i].CompareTo(Items[i + 1]) == 1)
                    {
                        (Items[i], Items[i + 1]) = (Items[i + 1], Items[i]);
                        SwapCount++;
                    }
                }
                if (swapCountPrev == SwapCount) return;
            }
        }

        protected override async Task DoSortVisualization()
        {
            var count = Items.Count;
            for (var j = 0; j < count; j++)
            {
                var swapCountPrev = SwapCount;
                for (var i = 0; i < count - j - 1; i++)
                {
                    var a = Items[i];
                    var b = Items[i + 1];
                    if (Compare(a, b) == 1)
                    {
                        await Task.Delay(20);
                        Swap(i, i + 1);
                    }
                    await Task.Delay(20);
                    MakeColorsDefault(a, b);
                }

                if (swapCountPrev == SwapCount) return;
            }
        }
    }
}