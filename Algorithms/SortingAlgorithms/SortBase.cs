using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithms.SortingAlgorithms
{
    public abstract class SortBase<T> where T : IComparable
    {
        protected int SwapCount { get; set; } = 0;
        protected int CompareCount { get; set; } = 0;
        public IList<T> Items { get; set; }
        public event EventHandler<Tuple<T, T, ChangeColor>> ColorChanged;

        protected void Swap(int pos1, int pos2)
        {
            SwapCount++;
            (Items[pos1], Items[pos2]) = (Items[pos2], Items[pos1]);
            OnColorChanged(Items[pos1], Items[pos2], ChangeColor.Swap);
        }

        protected int Compare(T a, T b)
        {
            OnColorChanged(a, b, ChangeColor.Compare);
            CompareCount++;
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

        public long Sort(bool visualizationOn)
        {
            if (visualizationOn)
            {
                DoSortVisualization();
                return 0;
            }
            SwapCount = CompareCount = 0;
            var timer = new Stopwatch();
            timer.Start();
            DoSort();
            timer.Stop();
            return timer.ElapsedMilliseconds;
        }

        protected abstract void DoSort();

        protected abstract void DoSortVisualization();

        public enum ChangeColor
        {
            Swap,
            Compare,
            Default
        }
    }
}