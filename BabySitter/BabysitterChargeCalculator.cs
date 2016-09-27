﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySitter
{
    public class BabysitterChargeCalculator
    {

        /// <summary>
        /// The default bed time parameter
        /// </summary>
        public DateTime BedTime { get; }

        /// <summary>
        /// Constructor the baby sitter charge calculator
        /// </summary>
        /// <param name="bedTime">The bed time parameter for charge changes</param>
        public BabysitterChargeCalculator(DateTime bedTime)
        {
            this.BedTime = bedTime;
        }

        /// <summary>
        /// Constructor for the baby sitter charge calculator with 
        /// a default bedtime of 8 PM.
        /// </summary>
        public BabysitterChargeCalculator(): this(GetTimeMerged(20,0))
        {
            
        }


        /// <summary>
        /// Computes and returns the sitter charge based on the start and end time of the sitter's job.
        /// </summary>
        /// <param name="startTime">The time of day the sitter started job</param>
        /// <param name="endTime">The time of the day the stter's job ended</param>
        /// <returns>The calculated charge the customer owes the baby sitter for the job</returns>
        public int Calculate(DateTime startTime, DateTime endTime)
        {
            // compute the number of hours between end and start 
            int hourDiff = endTime.Subtract(startTime).Hours;
            Debug.Print("{0} to {1} = {2} hours", startTime, endTime, hourDiff);
            // calculated cost is the diff in hours multiplied by 12
            return 12 * hourDiff;
        }

        /// <summary>
        /// Helper function to create time of day DateTimes
        /// </summary>
        /// <param name="hour">The hour value of the time of day - in 24 hour format</param>
        /// <param name="minute">The minute value in the hour</param>
        /// <returns></returns>
        private static DateTime GetTimeMerged(int hour, int minute)
        {
            DateTime timeSplicedDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, hour, minute, 0);
            return timeSplicedDate;
        }
    }
}
