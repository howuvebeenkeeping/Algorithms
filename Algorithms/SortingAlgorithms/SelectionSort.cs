using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.SortingAlgorithms
{
    public class SelectionSort<T> : SortBase<T> where T : IComparable
    {
        protected override void DoSort()
        {
            var newArr = new List<T>();
            var itemsCount = Items.Count;
            for (var i = 0; i < itemsCount; i++)
            {
                var smallest = Items.Min(); 
                newArr.Add(smallest);
                Items.Remove(smallest);
            }
            Items = newArr;
        }

        private static T FindSmallest(IList<T> arr) // Min работает быстрее FindSmallest
        {
            var smallest = arr[0];
            foreach (var item in arr)
            {
                if (item.CompareTo(smallest) == -1)
                {
                    smallest = item;
                }
            }
            return smallest;
        }
        
        protected override void DoSortVisualization()
        {
            throw new NotImplementedException();
        }
    }
}