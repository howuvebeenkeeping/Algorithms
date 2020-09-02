using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithms
{
    public class SortBase<T> where T : IComparable
    {
        protected int SwapCount { get; set; } = 0;
        protected int CompareCount { get; set; } = 0;
        public ObservableCollection<T> Items { get; set; }
        public event EventHandler<Tuple<T, T>> CompareEvent; 
        public event EventHandler<Tuple<T, T>> SwapEvent; 
        public event EventHandler<Tuple<T, T>> ColorsDefaultEvent; 

        public SortBase() { }

        protected void Swap(int pos1, int pos2)
        {
            SwapCount++;
            (Items[pos1], Items[pos2]) = (Items[pos2], Items[pos1]);
            SwapEvent?.Invoke(this, new Tuple<T, T>(Items[pos1], Items[pos2]));
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

        public virtual void DoSort()
        {
            Items.ToList().Sort();
        }

        protected void MakeColorsDefault(T a, T b)
        {
            ColorsDefaultEvent?.Invoke(this, new Tuple<T, T>(a, b));
        }
        
        protected int Compare(T a, T b)
        {
            CompareEvent?.Invoke(this, new Tuple<T, T>(a, b));
            CompareCount++;
            return a.CompareTo(b);
        }
    }
}