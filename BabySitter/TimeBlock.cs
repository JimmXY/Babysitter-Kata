using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySitter
{
    /// <summary>
    /// Defines a time block of payment separation.
    /// </summary>
    public class TimeBlock
    {
        /// <summary>
        /// The starting time of this block
        /// </summary>
        public DateTime Start { get; }

        /// <summary>
        /// The ending time of this block
        /// </summary>
        public DateTime End { get; }

        /// <summary>
        /// The per hour rate in this block
        /// </summary>
        public decimal CostPerHour { get; }

        public TimeBlock(DateTime baseDay, int startHour, int startMinute, int endHour, int endMinute, int dayAdvances, decimal costPerHour)
        {
            Start = baseDay.GetTimeMerged(startHour, startMinute);
            End = baseDay.AddDays(dayAdvances).GetTimeMerged(endHour, endMinute);
            CostPerHour = costPerHour;
        }

        public TimeBlock(int startHour, int startMinute, int endHour, int endMinute, int dayAdvances, decimal costPerHour) : this(DateTime.Today, startHour, startMinute, endHour, endMinute, dayAdvances, costPerHour)
        {

        }

        public TimeBlock(int startHour, int endHour, int dayAdvances, decimal costPerHour) : this(startHour, 0, endHour, 0, dayAdvances, costPerHour)
        {

        }

        public TimeBlock(DateTime baseDay, int startHour, int endHour, int dayAdvances, decimal costPerHour) : this(baseDay, startHour, 0, endHour, 0, dayAdvances, costPerHour)
        {

        }

        /// <summary>
        /// Determines if the given start and end time overlaps or is within this time block
        /// </summary>
        /// <param name="start">The starting time of the period to test</param>
        /// <param name="end">The ending time of the period to test</param>
        /// <returns></returns>
        public bool OverlapsOrIsWithin(DateTime start, DateTime end)
        {
            return start <= End && end >= Start;
        }

    }
}
