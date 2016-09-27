using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BabySitter;

namespace BabySitterUnitTests
{
    [TestClass]
    public class CaculatorExtensionsTests
    {
        [TestMethod]
        public void WhenHourIs1AndMinuteIs0Return1AM()
        {
            DateTime expected = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 1, 0, 0);
            DateTime actual = DateTime.Today.GetTimeMerged(1, 0);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenHourIs10AndMinuteIs50Return1050AM()
        {
            DateTime expected = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 10, 50, 0);
            DateTime actual = DateTime.Today.GetTimeMerged(10, 50);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenHourIs18AndMinuteIs0Return6PM()
        {
            DateTime expected = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 18, 0, 0);
            DateTime actual = DateTime.Today.GetTimeMerged(18, 0);
            Assert.AreEqual(expected, actual);
        }
    }
}
