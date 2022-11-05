using CSharpDatabaseAndTesting.Application;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpDatabaseAndTesting.Tests
{
    [TestFixture]
    internal class FirstSuite
    {
        private DataHolder holder;

        [SetUp]
        public void set() { 
             holder = new DataHolder();
             holder.Data = 45;
        }

        [Test]
        public void IsPropertySet() {
            Assert.AreEqual(holder.getData(), 45);
        }

        [Test]
        public void IsPropertyChangeable() {
            holder.Data = 90;
            Assert.AreEqual(holder.getData(), 90);
            holder.setData(40);
            Assert.AreEqual(holder.getData(), 40);
        }
    }
}
