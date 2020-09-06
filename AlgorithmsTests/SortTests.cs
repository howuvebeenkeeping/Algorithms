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
        private readonly int ItemsCount = 10_000;

        public SortTests()
        {
            // sorting collections are the same
            for (var i = 0; i < ItemsCount; i++)
            {
                _itemsForSorting.Add(_random.Next(10, 100));
            }

            _itemsSorted = _itemsForSorting.OrderBy(x => x).ToList();
        }

        [Test]
        public void BaseSortTest()
        {
            var baseSort = new SortBase<int>(new List<int>(_itemsForSorting));
            
            baseSort.Sort(false);

            for (var i = 0; i < ItemsCount; i++)
            {
                Assert.AreEqual(_itemsSorted[i], baseSort.Items[i]);
            }
        }
        
        [Test]
        public void BubbleSortTest()
        {
            // Arrange
            var bubbleSort = new BubbleSort<int>(new List<int>(_itemsForSorting));

            // Act
            bubbleSort.Sort(false);
            
            // Assert
            for (var i = 0; i < ItemsCount; i++)
            {
                Assert.AreEqual(_itemsSorted[i], bubbleSort.Items[i]);    
            }
        }

        [Test]
        public void CocktailSortTest()
        {
            var cocktailSort = new CocktailSort<int>(new List<int>(_itemsForSorting));
            
            cocktailSort.Sort(false);

            for (var i = 0; i < ItemsCount; i++)
            {
                Assert.AreEqual(_itemsSorted[i], cocktailSort.Items[i]);
            }
        }
        
        [Test]
        public void InsertSortTest()
        {
            var insertSort = new InsertSort<int>(new List<int>(_itemsForSorting));
            
            insertSort.Sort(false);

            for (var i = 0; i < ItemsCount; i++)
            {
                Assert.AreEqual(_itemsSorted[i], insertSort.Items[i]);
            }
        }
        
        [Test]
        public void SelectionSortTest()
        {
            var selectionSort = new SelectionSort<int>(new List<int>(_itemsForSorting));
            
            selectionSort.Sort(false);

            for (var i = 0; i < ItemsCount; i++)
            {
                Assert.AreEqual(_itemsSorted[i], selectionSort.Items[i]);
            }
        }
        
        [Test]
        public void ShellSortTest()
        {
            var shellSort = new ShellSort<int>(new List<int>(_itemsForSorting));
            
            shellSort.Sort(false);

            for (var i = 0; i < ItemsCount; i++)
            {
                Assert.AreEqual(_itemsSorted[i], shellSort.Items[i]);
            }
        }
    }
}