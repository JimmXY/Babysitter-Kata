﻿using System;
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

        public TimeBlock(int startHour, int startMinute, int endHour, int endMinute, int dayAdvances, decimal costPerHour)
        {
            Start = DateTime.Today.GetTimeMerged(startHour, startMinute);
            
            End = DateTime.Today.AddDays(dayAdvances).GetTimeMerged(endHour, endMinute);
            CostPerHour = costPerHour;
        }

        public TimeBlock(int startHour, int endHour, int dayAdvances, decimal costPerHour) : this(startHour, 0, endHour, 0,dayAdvances, costPerHour)
        {

        }
    }
}
