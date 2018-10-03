﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meziantou.Framework.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.Framework.Tests.Utilities
{
    [TestClass]
    public class EnumerableTests
    {
        [TestMethod]
        public void ReplaceTests_01()
        {
            // Arrange
            var list = new List<int>() { 1, 2, 3 };

            // Act
            list.Replace(2, 5);

            // Assert
            CollectionAssert.AreEqual(new List<int> { 1, 5, 3 }, list);
        }

        [TestMethod]
        public void ReplaceTests_02()
        {
            // Arrange
            var list = new List<int>() { 1, 2, 3 };

            // Act
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.Replace(10, 5));
        }

        [TestMethod]
        public async Task ForEachAsync()
        {
            var bag = new ConcurrentBag<int>();
            await Enumerable.Range(1, 100).ForEachAsync(async i =>
            {
                await Task.Yield();
                bag.Add(i);
            });

            Assert.AreEqual(100, bag.Count);
        }
    }
}
