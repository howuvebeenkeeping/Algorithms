using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithms.SortingAlgorithms
{
    public class SortBase<T> where T : IComparable
    {
        public SortBase(IList<T> items)
        {
            Items = items;
        }

        public int SwapCount { get; set; } = 0;
        public int CompareCount { get; set; } = 0;
        internal IList<T> Items { get; set; }

        public event EventHandler<Tuple<T, T, ChangeColor>> ColorChanged;

        protected void Swap(int pos1, int pos2)
        {
            (Items[pos1], Items[pos2]) = (Items[pos2], Items[pos1]);
            SwapCount++;
            OnColorChanged(Items[pos1], Items[pos2], ChangeColor.Swap);
        }

        protected int Compare(T a, T b)
        {
            CompareCount++;
            OnColorChanged(a, b, ChangeColor.Compare);
            return a.CompareTo(b);
        }

        protected void MakeColorsDefault(T a, T b)
        {
            OnColorChanged(a, b, ChangeColor.Default);
        }

        protected void OnColorChanged(T a, T b, ChangeColor color)
        {
            ColorChanged?.Invoke(this, new Tuple<T, T, ChangeColor>(a, b, color));
        }

        public async Task<TimeSpan> Sort(bool visualizationOn)
        {
            SwapCount = CompareCount = 0;
            var itemsCopy = new List<T>(Items);
            if (visualizationOn)
            {
                await DoSortVisualization();
            }
            Items = itemsCopy;
            SwapCount = 0;
            var timer = Stopwatch.StartNew();
            DoSort();
            timer.Stop();
            return timer.Elapsed;
        }

        protected virtual void DoSort()
        {
            Items = Items.OrderBy(x => x).ToList();
        }

        protected virtual Task DoSortVisualization() 
        {
            return Task.CompletedTask;
        }

        public enum ChangeColor
        {
            Swap,
            Compare,
            Default
        }
    }
}