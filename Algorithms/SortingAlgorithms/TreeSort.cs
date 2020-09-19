using System;
using System.Collections.Generic;
using Algorithms.SortingAlgorithms.DataStructure;

namespace Algorithms.SortingAlgorithms
{
    public class TreeSort<T> : SortBase<T> where T: IComparable
    {
        public TreeSort(IList<T> items) : base(items)
        {
            
        }

        protected override void DoSort()
        {
            var tree = new Tree<T>(Items);
            var sorted = tree.InOrder();
            Items = sorted;
        }
    }
}