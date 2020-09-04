using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Algorithms.SortingAlgorithms
{
    public class ShellSort<T> : SortBase<T> where T : IComparable
    {
        // TODO: O(?)
        public ShellSort(IList<T> items) : base(items) { }
        protected override void DoSort()
        {
            var gap = Items.Count / 2;
            while (gap > 0)
            {
                for (var i = gap; i < Items.Count; i++)
                {
                    var j = i;
                    while (j >= gap && Items[j - gap].CompareTo(Items[j]) == 1)
                    {
                        Swap(j, j - gap);
                        j -= gap;
                    }
                }
                gap /= 2;
            }
        }

        protected override async void DoSortVisualization()
        {
            var gap = Items.Count / 2;
            while (gap > 0)
            {
                for (var i = gap; i < Items.Count; i++)
                {
                    var j = i;
                    while (j >= gap && Compare(Items[j - gap], Items[j]) == 1)
                    {
                        await Task.Delay(400);
                        Swap(j, j - gap);
                        await Task.Delay(400);
                        MakeColorsDefault(Items[j], Items[j - gap]);
                        j -= gap;
                    }
                    if (j - gap < 0) continue;
                    await Task.Delay(400);
                    MakeColorsDefault(Items[j], Items[j - gap]);
                }
                gap /= 2;
            }
        }
    }
}