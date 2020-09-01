using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Algorithms
{
    public abstract class SortBase<T> where T : IComparable
    {
        protected int SwapCount { get; set; } = 0;
        protected int CompareCount { get; set; } = 0;
        public IList<T> Items { get; set; } = new List<T>();

        protected void Swap(int pos1, int pos2)
        {
            (Items[pos1], Items[pos2]) = (Items[pos2], Items[pos1]);
            SwapCount++;
        }

        public long Sort()
        {
            SwapCount = CompareCount = 0;
            var timer = new Stopwatch();
            timer.Start();
            DoSort();
            timer.Stop();
            return timer.ElapsedMilliseconds;
        }

        protected virtual void DoSort()
        {
            Items.ToList().Sort();
        }
    }
}