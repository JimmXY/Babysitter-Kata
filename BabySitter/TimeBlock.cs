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
    }
}
