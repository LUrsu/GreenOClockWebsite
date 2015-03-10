using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreenOClock.Data
{
    public class Class1
    {
    }

    public partial class Progress
    {
        public static TimeSpan operator +(TimeSpan a, Progress progress)
        {
            var end = progress.EndTime.HasValue ? progress.EndTime.Value : DateTime.Now;
            return a + (end - progress.StartTime);
        }

        public static TimeSpan operator +(Progress a, Progress b)
        {
            if (!(a.EndTime.HasValue && b.EndTime.HasValue))
                throw new ArgumentException("one or more of the arguments has no end time. speak to ryan r about what you want to happen.");
            return (a.EndTime.Value - a.StartTime) + (b.EndTime.Value - b.StartTime);
        }
    }
}
