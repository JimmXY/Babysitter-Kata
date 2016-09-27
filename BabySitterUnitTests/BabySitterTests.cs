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
            TimeBlock[] paymentBlocks = new TimeBlock[2];
            // 5 PM to bed time
            paymentBlocks[0] = new TimeBlock(17, 20, 0, 12);
            paymentBlocks[1] = new TimeBlock(20, 0, 1, 8);
            sitterCalculator = new BabysitterChargeCalculator(paymentBlocks);
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
        public void ForOneHourBeforeBedtimeReturns12USD()
        {
            DateTime startTime = DateTime.Today.GetTimeMerged(17, 0);
            DateTime endTime = DateTime.Today.GetTimeMerged(18, 0);
            // When starting at 5 PM, working for one hour till 6 PM, must get paid $12
            Assert.AreEqual(12, sitterCalculator.Calculate(startTime, endTime));
        }

        [TestMethod]
        public void ForTwoHoursBeforeBedTimeReturns24USD()
        {
            // Starts working at 5 PM till 7 PM, must  get $24
            Assert.AreEqual(24, sitterCalculator.Calculate(DateTime.Today.GetTimeMerged(17, 0), DateTime.Today.GetTimeMerged(19, 0)));
        }

        [TestMethod]
        public void ForThreeHoursTillBedTimeReturns36USD()
        {
            // Starts working at 5 PM till 8 PM, must get $36
            Assert.AreEqual(36, sitterCalculator.Calculate(DateTime.Today.GetTimeMerged(17, 0), DateTime.Today.GetTimeMerged(20, 0)));
        }

        [TestMethod]
        public void ForFoursHoursPastBedTimeReturns44USD()
        {
            // Starts working at 5 PM, 3 hours till 8 PM bedtime and then for one hour till 9 PM
            // must get $36 (till bed time - defaults to 8PM) + $8 = $44
            Assert.AreEqual(44, sitterCalculator.Calculate(DateTime.Today.GetTimeMerged(17, 0), DateTime.Today.GetTimeMerged(21, 0)));
        }


    }
}
