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

        [Test]
        public void GcdTest()
        {
            var test1 = GCD.FindGcd(12, (short)8);
            var test2 = GCD.FindGcd(12.0, 8f);
            var test3 = GCD.FindGcd(12L, 8d);
            var test4 = GCD.FindGcd(12.0, "4UL");
            var test5 = GCD.FindGcdRecursion(12d, 8UL);
            Assert.AreEqual(4.0, test1);
            Assert.AreEqual(4, test2);
            Assert.AreEqual(4f, test3);
            Assert.AreEqual(null, test4);
            Assert.AreEqual(4d, test5);
        }
    }
}