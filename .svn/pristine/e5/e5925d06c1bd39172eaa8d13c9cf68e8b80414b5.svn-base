using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GreenOClock.Data;

namespace GreenOClock.Mvc.Models.Progresses
{
    public class ProgressesViewModel
    {
        public List<ProgressViewModel> ProgressViewModels { get; set; }
        public TimeSpan TotalTime
        {
            get { return ProgressViewModels.Aggregate(new TimeSpan(0), (current, x) => current + (TimeSpan) x); }
        }

        public ProgressesViewModel() : this(new List<Progress>())
        {
        }

        public ProgressesViewModel(IEnumerable<Progress> progresses)
        {
            ProgressViewModels = progresses.ToList().ConvertAll(p => new ProgressViewModel(p));
        }
    }
}