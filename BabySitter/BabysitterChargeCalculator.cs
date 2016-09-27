using System;
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
        /// The payment time blocks settings.
        /// Each time block corresponds to a different charge per hour within that block.
        /// </summary>
        public TimeBlock[] PaymentBlocks { get; }

        public BabysitterChargeCalculator(TimeBlock[] paymentBlocks)
        {
            PaymentBlocks = paymentBlocks;
        }

        public BabysitterChargeCalculator(): this(new TimeBlock[] { new TimeBlock(17, 20, 0, 12), new TimeBlock(20, 0, 1, 8) , new TimeBlock(DateTime.Today.AddDays(1), 0, 0, 4, 16) })
        {
            
        }

        /// <summary>
        /// Computes and returns the sitter charge based on the start and end time of the sitter's job.
        /// </summary>
        /// <param name="startTime">The time of day the sitter started job</param>
        /// <param name="endTime">The time of the day the stter's job ended</param>
        /// <returns>The calculated charge the customer owes the baby sitter for the job</returns>
        public decimal Calculate(DateTime startTime, DateTime endTime)
        {
            decimal calculatedCharge = 0.0M;
            // Take the overlapping blocks
            IEnumerable<TimeBlock> overlappingBlocks = PaymentBlocks.Where(b => b.OverlapsOrIsWithin(startTime, endTime));
            // calculate within the payment blocks
            foreach (TimeBlock timeBlock in overlappingBlocks)
            {
                DateTime useStart = startTime > timeBlock.Start ? startTime : timeBlock.Start;
                DateTime useStop = endTime > timeBlock.End ? timeBlock.End : endTime;

                // now calculate the overlap hours in this block - round to next hour
                int hoursInBlock = (int) Math.Ceiling(useStop.Subtract(useStart).TotalMinutes / 60);
                calculatedCharge += hoursInBlock * timeBlock.CostPerHour;
            }

            return calculatedCharge;
        }

    }
}
