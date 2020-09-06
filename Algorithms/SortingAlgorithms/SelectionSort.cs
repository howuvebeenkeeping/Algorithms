using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithms.SortingAlgorithms
{
    public class SelectionSort<T> : SortBase<T> where T : IComparable
    {
        // TODO: O(?)
        public SelectionSort(IList<T> items) : base(items) { }
        protected override void DoSort()
        {
            var newArr = new List<T>();
            var itemsCount = Items.Count;
            for (var i = 0; i < itemsCount; i++)
            {
                var smallest = FindSmallest(Items); 
                newArr.Add(smallest);
                Items.Remove(smallest);
            }
            Items = newArr;
        }

        private T FindSmallest(IList<T> arr) // Min работает быстрее FindSmallest
        {
            var smallest = arr[0];
            foreach (var item in arr)
            {
                if (item.CompareTo(smallest) == -1)
                {
                    smallest = item;
                }
                CompareCount++;
            }
            return smallest;
        }
        
        protected override Task DoSortVisualization()
        {
            return Task.CompletedTask;
        }
    }
}