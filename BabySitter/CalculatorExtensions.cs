using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySitter
{
    
    public static class CalculatorExtensions
    {
        /// <summary>
        /// Helper function to create time of day DateTimes
        /// </summary>
        /// <param name="hour">The hour value of the time of day - in 24 hour format</param>
        /// <param name="minute">The minute value in the hour</param>
        /// <returns></returns>
        public static DateTime GetTimeMerged(this DateTime day, int hour, int minute)
        {
            DateTime timeSplicedDate = new DateTime(day.Year, day.Month, day.Day, hour, minute, 0);
            return timeSplicedDate;
        }



    }
}
