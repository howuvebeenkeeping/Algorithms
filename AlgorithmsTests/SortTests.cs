using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using Algorithms;

namespace AlgorithmsTests
{
    [TestFixture]
    public class SortTests
    {
        private static readonly Random Random = new Random();
        private static readonly IList<int> ItemsForSorting = new List<int>();
        private static readonly IList<int> ItemsSorted;
        private static int ItemsCount { get; } = 8_000;
        
        static SortTests()
        {
            // sorting collections are the same
            for (var i = 0; i < ItemsCount; i++)
            {
                ItemsForSorting.Add(Random.Next(0, 100));
            }
            ItemsSorted = ItemsForSorting.OrderBy(x => x).ToArray();
        }
        
        [Test]
        public void BubbleSortTest() // 2 min 29 sec (80_000)
        {
            // Arrange
            var bubbleSort = new BubbleSort<int> {Items = new List<int>(ItemsForSorting)};

            // Act
            bubbleSort.Sort();
            
            // Assert
            for (var i = 0; i < ItemsCount; i++)
            {
                Assert.AreEqual(ItemsSorted[i], bubbleSort.Items[i]);    
            }
        }

        [Test]
        public void CocktailSortTest() // 2 min 23 sec (80_000)
        {
            var cocktailSort = new CocktailSort<int> {Items = new List<int>(ItemsForSorting)};
            
            cocktailSort.Sort();

            for (var i = 0; i < ItemsCount; i++)
            {
                Assert.AreEqual(ItemsSorted[i], cocktailSort.Items[i]);
            }
        }
        
        [Test]
        public void InsertSortTest() // 40 sec (80_000)
        {
            var insertSort = new InsertSort<int> {Items = new List<int>(ItemsForSorting)};
            
            insertSort.Sort();

            for (var i = 0; i < ItemsCount; i++)
            {
                Assert.AreEqual(ItemsSorted[i], insertSort.Items[i]);
            }
        }
    }
}