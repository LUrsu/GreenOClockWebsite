using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreenOClock.Data
{
    public partial class Progress
    {
        public static implicit operator TimeSpan(Progress vm)
        {
            var end = vm.EndTime.HasValue ? vm.EndTime.Value : DateTime.Now;
            return end - vm.StartTime;
        }
    }

    public partial class User
    {
        public string FullName { get { return LastName + ", " + FirstName; } }
    }
}
