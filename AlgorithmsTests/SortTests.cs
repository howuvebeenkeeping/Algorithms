using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Algorithms;
using Algorithms.SortingAlgorithms;

namespace AlgorithmsTests
{
    [TestFixture]
    public class SortTests
    {
        private readonly Random _random = new Random();
        private readonly IList<int> _itemsForSorting = new List<int>();
        private readonly IList<int> _itemsSorted;
        private readonly int itemsCount = 8000;

        public SortTests()
        {
            // sorting collections are the same
            for (var i = 0; i < itemsCount; i++)
            {
                _itemsForSorting.Add(_random.Next(100));
            }

            _itemsSorted = _itemsForSorting.OrderBy(x => x).ToList();
        }

        [Test]
        public void BubbleSortTest()
        {
            // Arrange
            var bubbleSort = new BubbleSort<int> {Items = new List<int>(_itemsForSorting)};

            // Act
            bubbleSort.Sort(false);
            
            // Assert
            for (var i = 0; i < itemsCount; i++)
            {
                Assert.AreEqual(_itemsSorted[i], bubbleSort.Items[i]);    
            }
        }

        [Test]
        public void CocktailSortTest()
        {
            var cocktailSort = new CocktailSort<int> {Items = new List<int>(_itemsForSorting)};
            
            cocktailSort.Sort(false);

            for (var i = 0; i < itemsCount; i++)
            {
                Assert.AreEqual(_itemsSorted[i], cocktailSort.Items[i]);
            }
        }
        
        [Test]
        public void InsertSortTest()
        {
            var insertSort = new InsertSort<int> {Items = new List<int>(_itemsForSorting)};
            
            insertSort.Sort(false);

            for (var i = 0; i < itemsCount; i++)
            {
                Assert.AreEqual(_itemsSorted[i], insertSort.Items[i]);
            }
        }
    }
}