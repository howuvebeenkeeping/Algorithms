using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithms.SortingAlgorithms
{
    public class BubbleSort<T> : SortBase<T> where T : IComparable
    {
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
                    var a = Items[i];
                    var b = Items[i + 1];
                    if (Compare(a, b) == 1)
                    {
                        Swap(i, i + 1);
                    }
                }

                if (swapCountPrev == SwapCount) return;
            }
        }

        protected override async void DoSortVisualization()
        {
            var count = Items.Count;
            // j можно принять за кол-во отсортированных элементов
            for (var j = 0; j < count; j++)
            {
                var swapCountPrev = SwapCount;
                for (var i = 0; i < count - j - 1; i++)
                {
                    var a = Items[i];
                    var b = Items[i + 1];
                    if (Compare(a, b) == 1)
                    {
                        await Task.Delay(400);
                        Swap(i, i + 1);
                    }

                    await Task.Delay(400);
                    MakeColorsDefault(a, b);
                }

                if (swapCountPrev == SwapCount) return;
            }
        }
    }
}