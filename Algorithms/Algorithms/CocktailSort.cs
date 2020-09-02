using System;
using System.Threading.Tasks;

namespace Algorithms
{
    public class CocktailSort<T> : SortBase<T> where T : IComparable
    {
        // O(n) - в лучшем случае
        // O(n^2) - в худшем случае
        public override async void DoSort()
        {
            var swapCountPrev = SwapCount;
            var left = 0;
            var right = Items.Count - 1;
            while (left < right)
            {
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
