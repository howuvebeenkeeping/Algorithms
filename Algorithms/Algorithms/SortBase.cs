using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class SortBase<T> where T : IComparable
    {
        public IList<T> Items { get; set;  } = new List<T>();

        public virtual void Sort()
        {
            Items.ToList().Sort();
        }
    }
}