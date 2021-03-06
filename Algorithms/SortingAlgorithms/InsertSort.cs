﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Algorithms.SortingAlgorithms
{
    public class InsertSort<T> : SortBase<T> where T : IComparable, new()
    {
        public InsertSort(IList<T> items) : base(items) { }
        
        // O(n)   - the best
        // O(n^2) - the average
        // O(n^2) - the worst
        protected override void DoSort()
        {
            for (var i = 1; i < Items.Count; i++)
            {
                var temp = Items[i];
                var j = i;
                while (j > 0 && temp.CompareTo(Items[j - 1]) == -1 && CompareCount == CompareCount++)
                {
                    Items[j] = Items[j - 1];
                    SwapCount++;
                    j--;
                }
                Items[j] = temp;
                SwapCount++;
            }
        }

        protected override async Task DoSortVisualization()
        {
            for (var i = 1; i < Items.Count; i++)
            {
                var temp = Items[i];
                OnColorChanged(temp, temp, ChangeColor.Compare);
                await Task.Delay(400);
                var j = i;
                while (j > 0 && Compare(temp, Items[j - 1]) == -1)
                {
                    OnColorChanged(temp, Items[j - 1], ChangeColor.Default);
                    Items[j] = Items[j - 1];
                    Items[j - 1] = default!;
                    j--;
                    await Task.Delay(400);
                }
                OnColorChanged(temp, Items[j - 1], ChangeColor.Default);
                Items[j] = temp;
                OnColorChanged(temp, temp, ChangeColor.Swap);
                await Task.Delay(400);
                OnColorChanged(temp, temp, ChangeColor.Default);
            }
        }
    }
}