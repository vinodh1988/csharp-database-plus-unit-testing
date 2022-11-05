using CSharpDatabaseAndTesting.Application;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpDatabaseAndTesting.Tests
{
    [TestFixture]
    internal class Fixture2
    {
        [Test]
        public void Test1() {
            Assert.AreEqual(Staticlass.square(4), 16);
        }
        [Test]
        public void Test2() {
            Assert.AreEqual(Staticlass.cube(4), 64);
        }  
    }
}
