using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithms
{
    public class BubbleSort<T> : SortBase<T> where T : IComparable
    {
        public BubbleSort() { }

        // O(n)
        public override async void DoSort()
        {
            var swapCountPrev = SwapCount;
            var count = Items.Count;
            // j можно принять за кол-во отсортированных элементов
            for (var j = 0; j < count; j++) 
            {
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