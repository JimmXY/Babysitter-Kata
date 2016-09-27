using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BabySitter;

namespace BabySitterUnitTests
{
    [TestClass]
    public class BabySitterTests
    {

        /// <summary>
        /// Reference to the sitter class to be used for testing
        /// </summary>
        BabysitterChargeCalculator sitterCalculator;

        [TestInitialize]
        public void Setup()
        {
            sitterCalculator = new BabysitterChargeCalculator();
        }

        /// <summary>
        /// Helper function to create time of day DateTimes
        /// </summary>
        /// <param name="hour">The hour value of the time of day - in 24 hour format</param>
        /// <param name="minute">The minute value in the hour</param>
        /// <returns></returns>
        private DateTime GetTimeMerged(int hour, int minute)
        {
            DateTime timeSplicedDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, hour, minute, 0);
            return timeSplicedDate;
        }

        /// <summary>
        /// Simple first test to get things moving. Makes sure that the constructor is being called without any issues.
        /// This test is irrelevant in most cases - but is included for the first step.
        /// </summary>
        [TestMethod]
        public void IsBabySitterInitializedTest()
        {
            Assert.IsNotNull(sitterCalculator);
        }

        [TestMethod]
        public void WhenBabySitterWorksForOneHourBeforeBedtimeGetsPaid12USD()
        {
            DateTime startTime = GetTimeMerged(17, 0);
            DateTime endTime = GetTimeMerged(18, 0);
            // When starting at 5 PM, working for one hour till 6 PM, must get paid $12
            Assert.AreEqual(12, sitterCalculator.Calculate(startTime, endTime));
        }

        [TestMethod]
        public void WhenBabySitterWorksForTwoHoursBeforeBedTimeGetsPaid24USD()
        {
            // Starts working at 5 PM till 7 PM, must  get $24
            Assert.AreEqual(24, sitterCalculator.Calculate(GetTimeMerged(17, 0), GetTimeMerged(19, 0)));
        }
    }
}
