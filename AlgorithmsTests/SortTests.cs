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
        private static readonly SortBase<int> SortBase = new SortBase<int>();
        
        static SortTests()
        {
            // сортируемые коллекции будут одинаковыми 
            for (var i = 0; i < 8_000; i++)
            {
                SortBase.Items.Add(Random.Next(0, 100));
            }
        }
        
        [Test]
        public void BubbleSortTest() // 1 min 51 sec (80_000 элементов) 
        {
            // Arrange
            var items = new List<int>(SortBase.Items);
            var bubbleSort = new BubbleSort<int> {Items = items};
            Debug.WriteLine(bubbleSort.Items[0] + bubbleSort.Items[10]);

            // Act
            bubbleSort.Sort();
            
            // Assert
            var expected = bubbleSort.Items.OrderBy(x => x).ToArray();
            var actual = bubbleSort.Items;

            for (var i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);    
            }
        }

        [Test]
        public void CocktailSortTest() // 1 min 45 sec (80_000 элементов)
        {
            var items = new List<int>(SortBase.Items);
            var cocktailSort = new CocktailSort<int> {Items = items};
            Debug.WriteLine(cocktailSort.Items[0] + cocktailSort.Items[10]);
            
            cocktailSort.Sort();

            var expected = cocktailSort.Items.OrderBy(x => x).ToArray();
            var actual = cocktailSort.Items;

            for (var i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}