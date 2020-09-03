using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.SearchingAlgorithms;
using NUnit.Framework;

namespace AlgorithmsTests
{
    [TestFixture]
    public class SearchTests
    {
        [Test]
        public void BinarySearchTest()
        {
            var array = new[] {-50, -10, -7, -1, 2, 22, 43, 67, 89, 123, 128};
            
            var results = array
                .Select(item =>
                    (Array.IndexOf(array, item), BinarySearch<int>.Find(array, item))
                )
                .ToList();
            results.Add((-1, BinarySearch<int>.Find(array, -60)));
            results.Add((-1, BinarySearch<int>.Find(array, 25)));
            results.Add((-1, BinarySearch<int>.Find(array, 300)));

            foreach (var (expected, actual) in results)
            {
                Assert.AreEqual(expected, actual);
            }
        }
    }
}